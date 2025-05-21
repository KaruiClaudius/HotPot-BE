using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SocketIOClient;
using System;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.ChatService
{
    public class SocketIOClientService : IDisposable
    {
        private readonly SocketIOClient.SocketIO _client;
        private readonly ILogger<SocketIOClientService> _logger;
        private bool _isDisposed;

        public SocketIOClientService(IConfiguration configuration, ILogger<SocketIOClientService> logger)
        {
            _logger = logger;
            var serverUrl = configuration["SocketIO:ServerUrl"] ?? "https://chat-server-production-9950.up.railway.app/";

            _logger.LogInformation($"Initializing Socket.IO client with URL: {serverUrl}");

            _client = new SocketIOClient.SocketIO(serverUrl, new SocketIOOptions
            {
                Reconnection = true,
                ReconnectionAttempts = 3,
                ReconnectionDelay = 1000
            });

            SetupEventHandlers();
            ConnectAsync().Wait();
        }

        private void SetupEventHandlers()
        {
            _client.OnConnected += (sender, e) =>
            {
                _logger.LogInformation("Connected to Socket.IO server");
            };

            _client.OnDisconnected += (sender, e) =>
            {
                _logger.LogInformation($"Disconnected from Socket.IO server: {e}");
            };

            _client.OnError += (sender, e) =>
            {
                _logger.LogError($"Socket.IO Error: {e}");
            };
        }

        private async Task ConnectAsync()
        {
            try
            {
                await _client.ConnectAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to connect to Socket.IO server");
            }
        }

        public async Task NotifyEvent(string eventName, object data)
        {
            if (_isDisposed)
            {
                _logger.LogWarning($"Attempted to emit event '{eventName}' with disposed Socket.IO client");
                return;
            }

            try
            {
                if (!_client.Connected)
                {
                    _logger.LogInformation("Reconnecting to Socket.IO server before sending event");
                    await ConnectAsync();
                }

                await _client.EmitAsync(eventName, data);
                _logger.LogInformation($"Emitted event '{eventName}'");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error emitting event '{eventName}'");
            }
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
                    _client.DisconnectAsync().Wait(TimeSpan.FromSeconds(3));
                }
                _client?.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Socket.IO client disposal");
            }
        }
    }
}