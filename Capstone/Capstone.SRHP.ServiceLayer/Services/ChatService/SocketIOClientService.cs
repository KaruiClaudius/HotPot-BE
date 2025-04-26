using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public bool _isConnected;
        private readonly string _serverUrl;


        public SocketIOClientService(IConfiguration configuration, ILogger<SocketIOClientService> logger)
        {
            _logger = logger;
            _serverUrl = configuration["SocketIO:ServerUrl"] ?? "http://localhost:3000";

            _logger.LogInformation($"Initializing Socket.IO client with URL: {_serverUrl}");

            _client = new SocketIOClient.SocketIO(_serverUrl, new SocketIOOptions
            {
                EIO = EngineIO.V4,
                Reconnection = true,
                ReconnectionAttempts = 3,
                ReconnectionDelay = 1000,
                Transport = TransportProtocol.WebSocket,
                ConnectionTimeout = TimeSpan.FromSeconds(10)
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
                _logger.LogInformation($"Disconnected from Socket.IO server at {_serverUrl}");
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
        }

        public async Task<bool> ConnectAsync()
        {
            if (_isConnected)
            {
                _logger.LogInformation("Already connected to Socket.IO server");
                return true;
            }

            try
            {
                _logger.LogInformation($"Attempting to connect to Socket.IO server at {_serverUrl}...");

                // Try to ping the server first to check if it's reachable
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(5);
                    try
                    {
                        var response = await httpClient.GetAsync(_serverUrl);
                        _logger.LogInformation($"Socket.IO server ping result: {response.StatusCode}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning($"Socket.IO server ping failed: {ex.Message}. Will still try to connect.");
                    }
                }

                await _client.ConnectAsync();
                _logger.LogInformation("Connection attempt completed successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error connecting to Socket.IO server at {_serverUrl}");
                return false;
            }
        }

        public async Task AuthenticateAsync(int userId, string role)
        {
            if (!_isConnected)
                await ConnectAsync();

            await _client.EmitAsync("authenticate", new { userId, role });
        }

        // New chat request (from customer)
        public async Task SendNewChatRequestAsync(int sessionId, int customerId, string customerName, string topic, DateTime createdAt)
        {
            if (!_isConnected)
                await ConnectAsync();

            await _client.EmitAsync("newChatRequest", new
            {
                chatSessionId = sessionId,
                customerId,
                customerName,
                topic,
                createdAt
            });

            _logger.LogInformation($"Sent new chat request: Session {sessionId}, Customer {customerId}");
        }

        // Chat accepted (from manager)
        public async Task SendChatAcceptedAsync(int sessionId, int managerId, string managerName, int customerId)
        {
            if (!_isConnected)
                await ConnectAsync();

            await _client.EmitAsync("acceptChat", new
            {
                sessionId,
                managerId,
                managerName,
                customerId
            });

            _logger.LogInformation($"Sent chat accepted: Session {sessionId}, Manager {managerId}, Customer {customerId}");
        }

        // Send message
        public async Task SendMessageAsync(int messageId, int senderId, int receiverId, string message, DateTime createdAt)
        {
            if (!_isConnected)
                await ConnectAsync();

            await _client.EmitAsync("sendMessage", new
            {
                messageId,
                senderId,
                receiverId,
                message,
                createdAt
            });

            _logger.LogInformation($"Sent message: ID {messageId}, From {senderId} to {receiverId}");
        }

        // Mark message as read
        public async Task MarkMessageAsReadAsync(int messageId, int senderId)
        {
            if (!_isConnected)
                await ConnectAsync();

            await _client.EmitAsync("markMessageRead", new
            {
                messageId,
                senderId
            });

            _logger.LogInformation($"Marked message as read: ID {messageId}");
        }

        // End chat session
        public async Task EndChatSessionAsync(int sessionId, int customerId, int? managerId)
        {
            if (!_isConnected)
                await ConnectAsync();

            await _client.EmitAsync("endChat", new
            {
                sessionId,
                customerId,
                managerId
            });

            _logger.LogInformation($"Ended chat session: ID {sessionId}");
        }

        public string GetServerUrl()
        {
            return _serverUrl;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

    }
}