using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SocketIO.Core;
using SocketIOClient;
using SocketIOClient.Transport;

namespace Capstone.HPTY.ServiceLayer.Services.ChatService
{
    public class SocketIOClientService : IDisposable
    {
        private readonly SocketIOClient.SocketIO _client;
        private readonly ILogger<SocketIOClientService> _logger;
        private readonly string _serverUrl;
        private readonly SemaphoreSlim _connectionLock = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim _operationLock = new SemaphoreSlim(1, 1);
        private DateTime _lastConnectionAttempt = DateTime.MinValue;
        private readonly TimeSpan _reconnectCooldown = TimeSpan.FromSeconds(5);
        private readonly int _maxRetries = 3;
        private bool _isConnected;
        private bool _isDisposed;
        public bool IsConnected => _isConnected && !_isDisposed;

        public SocketIOClientService(IConfiguration configuration, ILogger<SocketIOClientService> logger)
        {
            _logger = logger;
            _serverUrl = configuration["SocketIO:ServerUrl"] ?? "https://chat-server-lc4m.onrender.com";

            _logger.LogInformation($"Initializing Socket.IO client with URL: {_serverUrl}");

            _client = new SocketIOClient.SocketIO(_serverUrl, new SocketIOOptions
            {
                EIO = EngineIO.V4,
                Reconnection = true,
                ReconnectionAttempts = 5,
                ReconnectionDelay = 1000,
                Transport = TransportProtocol.WebSocket,
                ConnectionTimeout = TimeSpan.FromSeconds(10),
                RandomizationFactor = 0.5,
                Path = "/socket.io"
            });

            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            _client.OnConnected += (sender, e) =>
            {
                _isConnected = true;
                _logger.LogInformation($"Connected to Socket.IO server at {_serverUrl}");
            };

            _client.OnDisconnected += (sender, e) =>
            {
                _isConnected = false;
                _logger.LogInformation($"Disconnected from Socket.IO server at {_serverUrl}: {e}");
            };

            _client.OnError += (sender, e) =>
            {
                _logger.LogError($"Socket.IO Error: {e}");
            };

            _client.OnReconnectAttempt += (sender, e) =>
            {
                _logger.LogInformation($"Reconnecting to Socket.IO server, attempt {e}");
            };

            _client.OnReconnectError += (sender, e) =>
            {
                _logger.LogError($"Reconnection error: {e}");
            };

            _client.OnReconnectFailed += (sender, e) =>
            {
                _logger.LogError("Reconnection failed after all attempts");
            };

            _client.OnPing += (sender, e) =>
            {
                _logger.LogDebug("Ping sent to server");
            };

            _client.OnPong += (sender, e) =>
            {
                _logger.LogDebug($"Pong received from server: {e}ms");
            };
        }

        private async Task<bool> EnsureConnectedAsync(CancellationToken cancellationToken = default)
        {
            if (_isDisposed)
            {
                _logger.LogWarning("Attempted to use disposed Socket.IO client");
                return false;
            }

            if (_isConnected && _client.Connected)
                return true;

            bool lockAcquired = false;
            try
            {
                // Try to acquire the lock with a timeout to prevent deadlocks
                lockAcquired = await _connectionLock.WaitAsync(TimeSpan.FromSeconds(30), cancellationToken);
                if (!lockAcquired)
                {
                    _logger.LogWarning("Timed out waiting for connection lock");
                    return false;
                }

                // Double-check after acquiring lock
                if (_isConnected && _client.Connected)
                    return true;

                // Avoid rapid reconnection attempts
                var timeSinceLastAttempt = DateTime.UtcNow - _lastConnectionAttempt;
                if (timeSinceLastAttempt < _reconnectCooldown)
                {
                    var delay = _reconnectCooldown - timeSinceLastAttempt;
                    _logger.LogDebug($"Cooling down before reconnection attempt. Waiting {delay.TotalSeconds:F1} seconds");
                    await Task.Delay(delay, cancellationToken);
                }

                _lastConnectionAttempt = DateTime.UtcNow;

                try
                {
                    _logger.LogInformation($"Attempting to connect to Socket.IO server at {_serverUrl}...");

                    // Try to ping the server first to check if it's reachable
                    bool serverReachable = await PingServerAsync();
                    if (!serverReachable)
                    {
                        _logger.LogWarning("Socket.IO server is not reachable. Connection may fail.");
                    }

                    // Use a timeout for the connection attempt
                    using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
                    using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(timeoutCts.Token, cancellationToken);

                    await _client.ConnectAsync(linkedCts.Token);

                    if (_client.Connected)
                    {
                        _isConnected = true;
                        _logger.LogInformation("Successfully connected to Socket.IO server");
                        return true;
                    }
                    else
                    {
                        _logger.LogWarning("Socket.IO client reports not connected after ConnectAsync completed");
                        return false;
                    }
                }
                catch (OperationCanceledException)
                {
                    _isConnected = false;
                    _logger.LogWarning("Connection attempt to Socket.IO server timed out");
                    return false;
                }
                catch (Exception ex)
                {
                    _isConnected = false;
                    _logger.LogError(ex, $"Error connecting to Socket.IO server at {_serverUrl}");
                    return false;
                }
            }
            finally
            {
                if (lockAcquired)
                {
                    _connectionLock.Release();
                }
            }
        }

        public async Task<bool> PingServerAsync()
        {
            try
            {
                using var httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromSeconds(5);

                var response = await httpClient.GetAsync(_serverUrl);
                _logger.LogInformation($"Socket.IO server ping result: {response.StatusCode}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Socket.IO server ping failed: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ConnectAsync()
        {
            return await EnsureConnectedAsync();
        }

        public async Task AuthenticateAsync(int userId, string role)
        {
            await ExecuteWithRetryAsync(async () =>
            {
                _logger.LogInformation($"Authenticating user {userId} with role {role}");
                await _client.EmitAsync("authenticate", new { userId, role });
                _logger.LogInformation($"Authentication request sent for user {userId}");
            }, $"authenticate user {userId}");
        }

        // New chat request (from customer)
        public async Task SendNewChatRequestAsync(int sessionId, int customerId, string customerName, string topic, DateTime createdAt)
        {
            await ExecuteWithRetryAsync(async () =>
            {
                await _client.EmitAsync("newChatRequest", new { sessionId, customerId, customerName, topic, createdAt });
                _logger.LogInformation($"Sent new chat request: Session {sessionId}, Customer {customerId}, Topic: {topic}");
            }, $"send new chat request for session {sessionId}");
        }

        // Chat accepted (from manager)
        public async Task SendChatAcceptedAsync(int sessionId, int managerId, string managerName, int customerId)
        {
            await ExecuteWithRetryAsync(async () =>
            {
                await _client.EmitAsync("acceptChat", new
                {
                    sessionId,
                    managerId,
                    managerName,
                    customerId
                });
                _logger.LogInformation($"Sent chat accepted: Session {sessionId}, Manager {managerId}, Customer {customerId}");
            }, $"send chat accepted for session {sessionId}");
        }

        // Send message
        public async Task SendMessageAsync(int messageId, int senderId, int receiverId, string message, DateTime createdAt)
        {
            await ExecuteWithRetryAsync(async () =>
            {
                await _client.EmitAsync("sendMessage", new
                {
                    messageId,
                    senderId,
                    receiverId,
                    message,
                    createdAt
                });
                _logger.LogInformation($"Sent message: ID {messageId}, From {senderId} to {receiverId}");
            }, $"send message {messageId}");
        }

        // Mark message as read
        public async Task MarkMessageAsReadAsync(int messageId, int senderId)
        {
            await ExecuteWithRetryAsync(async () =>
            {
                await _client.EmitAsync("markMessageRead", new
                {
                    messageId,
                    senderId
                });
                _logger.LogInformation($"Marked message as read: ID {messageId}");
            }, $"mark message {messageId} as read");
        }

        // End chat session
        public async Task EndChatSessionAsync(int sessionId, int customerId, int? managerId)
        {
            await ExecuteWithRetryAsync(async () =>
            {
                await _client.EmitAsync("endChat", new
                {
                    sessionId,
                    customerId,
                    managerId
                });
                _logger.LogInformation($"Ended chat session: ID {sessionId}");
            }, $"end chat session {sessionId}");
        }

        private async Task ExecuteWithRetryAsync(Func<Task> action, string operationName, CancellationToken cancellationToken = default)
        {
            if (_isDisposed)
            {
                _logger.LogWarning($"Attempted to {operationName} with disposed Socket.IO client");
                return;
            }

            bool lockAcquired = false;
            try
            {
                // Acquire operation lock to prevent concurrent operations that might interfere with each other
                lockAcquired = await _operationLock.WaitAsync(TimeSpan.FromSeconds(30), cancellationToken);
                if (!lockAcquired)
                {
                    _logger.LogWarning($"Timed out waiting for operation lock while trying to {operationName}");
                    throw new TimeoutException($"Timed out waiting for operation lock while trying to {operationName}");
                }

                int retryCount = 0;
                bool success = false;
                Exception lastException = null;

                while (retryCount < _maxRetries && !success)
                {
                    try
                    {
                        // Ensure we're connected before each attempt
                        bool connected = await EnsureConnectedAsync(cancellationToken);
                        if (!connected)
                        {
                            _logger.LogWarning($"Failed to connect to Socket.IO server before {operationName}. Retry {retryCount + 1}/{_maxRetries}");
                            retryCount++;
                            if (retryCount < _maxRetries)
                            {
                                await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, retryCount)), cancellationToken); // Exponential backoff
                            }
                            continue;
                        }

                        // Execute the action with a timeout
                        using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                        using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(timeoutCts.Token, cancellationToken);

                        await action();
                        success = true;
                    }
                    catch (OperationCanceledException)
                    {
                        _logger.LogWarning($"Operation timed out while trying to {operationName}. Retry {retryCount + 1}/{_maxRetries}");
                        _isConnected = false; // Force reconnection
                        lastException = new TimeoutException($"Operation timed out while trying to {operationName}");
                    }
                    catch (Exception ex) when (ex.Message.Contains("closed the WebSocket connection") ||
                                              ex.Message.Contains("WebSocket closed") ||
                                              ex.Message.Contains("not connected"))
                    {
                        _logger.LogWarning($"WebSocket connection issue while trying to {operationName}: {ex.Message}. Retry {retryCount + 1}/{_maxRetries}");
                        _isConnected = false; // Force reconnection
                        lastException = ex;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Error while trying to {operationName}");
                        lastException = ex;
                        // For unexpected errors, don't retry
                        throw;
                    }

                    retryCount++;
                    if (!success && retryCount < _maxRetries)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, retryCount)), cancellationToken); // Exponential backoff
                    }
                }

                if (!success)
                {
                    _logger.LogError($"Failed to {operationName} after {_maxRetries} attempts");
                    throw lastException ?? new Exception($"Failed to {operationName} after {_maxRetries} attempts");
                }
            }
            finally
            {
                if (lockAcquired)
                {
                    _operationLock.Release();
                }
            }
        }

        public string GetServerUrl()
        {
            return _serverUrl;
        }

        public void Dispose()
        {
            if (_isDisposed)
                return;

            _isDisposed = true;

            try
            {
                if (_client != null && _client.Connected)
                {
                    _client.DisconnectAsync().Wait(TimeSpan.FromSeconds(5));
                }
                _client?.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Socket.IO client disposal");
            }

            _connectionLock.Dispose();
            _operationLock.Dispose();
        }
    }
}