using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SocketIOClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.ChatService
{
    public class SocketIOClientService : IDisposable
    {
        private readonly SocketIOClient.SocketIO _client;
        private readonly ILogger<SocketIOClientService> _logger;
        private readonly SemaphoreSlim _connectionLock = new SemaphoreSlim(1, 1);
        private bool _isDisposed;
        private bool _isConnecting;
        private readonly string _serverUrl;

        public SocketIOClientService(IConfiguration configuration, ILogger<SocketIOClientService> logger)
        {
            _logger = logger;
            _serverUrl = configuration["SocketIO:ServerUrl"] ?? "https://chat-server-production-9950.up.railway.app/";

            _logger.LogInformation($"Initializing Socket.IO client with URL: {_serverUrl}");

            _client = new SocketIOClient.SocketIO(_serverUrl, new SocketIOOptions
            {
                Reconnection = true,
                ReconnectionAttempts = 5,
                ReconnectionDelay = 2000,
                Transport = SocketIOClient.Transport.TransportProtocol.WebSocket,
            });

            SetupEventHandlers();

            // Don't block constructor with Wait() - instead use fire-and-forget with error handling
            Task.Run(async () =>
            {
                try
                {
                    await ConnectAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to connect to Socket.IO server during initialization");
                }
            });
        }

        private void SetupEventHandlers()
        {
            _client.OnConnected += (sender, e) =>
            {
                _logger.LogInformation("Connected to Socket.IO server");
                _isConnecting = false;
            };

            _client.OnDisconnected += (sender, e) =>
            {
                _logger.LogInformation($"Disconnected from Socket.IO server: {e}");
            };

            _client.OnError += (sender, e) =>
            {
                _logger.LogError($"Socket.IO Error: {e}");
            };

            _client.OnReconnectAttempt += (sender, e) =>
            {
                _logger.LogInformation($"Attempting to reconnect to Socket.IO server (attempt {e})");
            };

            _client.OnReconnectError += (sender, e) =>
            {
                _logger.LogError($"Socket.IO Reconnection Error: {e}");
            };

            _client.OnReconnected += (sender, e) =>
            {
                _logger.LogInformation("Successfully reconnected to Socket.IO server");
            };
        }

        public async Task ConnectAsync()
        {
            if (_isDisposed)
            {
                _logger.LogWarning("Attempted to connect with disposed Socket.IO client");
                return;
            }

            // Prevent multiple simultaneous connection attempts
            if (_isConnecting)
            {
                _logger.LogInformation("Connection attempt already in progress");
                return;
            }

            await _connectionLock.WaitAsync();
            try
            {
                // Double-check after acquiring lock
                if (_client.Connected || _isConnecting)
                {
                    _logger.LogDebug("Socket already connected or connecting");
                    return;
                }

                _isConnecting = true;
                _logger.LogInformation("Connecting to Socket.IO server...");

                // Set a timeout for the connection attempt
                var connectionTask = _client.ConnectAsync();
                var timeoutTask = Task.Delay(15000); // 15 second timeout

                var completedTask = await Task.WhenAny(connectionTask, timeoutTask);

                if (completedTask == timeoutTask)
                {
                    _logger.LogWarning("Connection attempt timed out after 15 seconds");
                    _isConnecting = false;
                    throw new TimeoutException("Connection to Socket.IO server timed out");
                }

                // Wait for the connection task to complete (it should be done already)
                await connectionTask;

                _logger.LogInformation("Successfully connected to Socket.IO server");
            }
            catch (Exception ex)
            {
                _isConnecting = false;
                _logger.LogError(ex, "Failed to connect to Socket.IO server");
                throw;
            }
            finally
            {
                _connectionLock.Release();
            }
        }

        public async Task NotifyEvent(string eventName, object data)
        {
            if (_isDisposed)
            {
                _logger.LogWarning($"Attempted to emit event '{eventName}' with disposed Socket.IO client");
                return;
            }

            await _connectionLock.WaitAsync();
            try
            {
                // Check if we need to reconnect
                if (!_client.Connected && !_isConnecting)
                {
                    _logger.LogInformation("Reconnecting to Socket.IO server before sending event");
                    try
                    {
                        _isConnecting = true;
                        await _client.ConnectAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to reconnect before sending event");
                        _isConnecting = false;
                        return; // Don't try to emit if we couldn't connect
                    }
                    finally
                    {
                        _isConnecting = false;
                    }
                }

                // Only emit if connected
                if (_client.Connected)
                {
                    // Set a timeout for the emit operation
                    var emitTask = _client.EmitAsync(eventName, data);
                    var timeoutTask = Task.Delay(5000); // 5 second timeout

                    var completedTask = await Task.WhenAny(emitTask, timeoutTask);

                    if (completedTask == timeoutTask)
                    {
                        _logger.LogWarning($"Emit operation for '{eventName}' timed out after 5 seconds");
                        throw new TimeoutException($"Emit operation for '{eventName}' timed out");
                    }

                    // Wait for the emit task to complete (it should be done already)
                    await emitTask;

                    _logger.LogInformation($"Successfully emitted event '{eventName}'");
                }
                else
                {
                    _logger.LogWarning($"Could not emit event '{eventName}' - not connected to Socket.IO server");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error emitting event '{eventName}'");
                // Don't rethrow - we don't want to fail the API call if socket notification fails
            }
            finally
            {
                _connectionLock.Release();
            }
        }

        public void Dispose()
        {
            if (_isDisposed)
                return;

            _isDisposed = true;

            try
            {
                _connectionLock.Dispose();

                if (_client != null && _client.Connected)
                {
                    // Use a timeout to prevent hanging on disconnect
                    var disconnectTask = _client.DisconnectAsync();
                    var timeoutTask = Task.Delay(3000); // 3 second timeout

                    Task.WhenAny(disconnectTask, timeoutTask).Wait();
                }

                _client?.Dispose();

                _logger.LogInformation("Socket.IO client successfully disposed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Socket.IO client disposal");
            }
        }
    }
}