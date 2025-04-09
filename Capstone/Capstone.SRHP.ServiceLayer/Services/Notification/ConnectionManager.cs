using System.Collections.Concurrent;

namespace Capstone.HPTY.API.SideServices
{
    public interface IConnectionManager
    {
        void AddConnection(int userId, string connectionId, string role);
        void RemoveConnection(string connectionId);
        string GetConnectionId(int userId);
        List<string> GetConnectionsByRole(string role);
        bool IsUserConnected(int userId);
    }

    public class ConnectionManager : IConnectionManager
    {
        private readonly ConcurrentDictionary<int, UserConnection> _connections = new();

        public void AddConnection(int userId, string connectionId, string role)
        {
            _connections.AddOrUpdate(userId,
                new UserConnection { ConnectionId = connectionId, Role = role },
                (_, existing) => { existing.ConnectionId = connectionId; return existing; });
        }

        public void RemoveConnection(string connectionId)
        {
            var userToRemove = _connections.FirstOrDefault(x => x.Value.ConnectionId == connectionId);
            if (userToRemove.Key != 0)
                _connections.TryRemove(userToRemove.Key, out _);
        }

        public string GetConnectionId(int userId)
        {
            return _connections.TryGetValue(userId, out var connection) ? connection.ConnectionId : null;
        }

        public List<string> GetConnectionsByRole(string role)
        {
            return _connections.Where(x => x.Value.Role.Equals(role, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.Value.ConnectionId)
                .ToList();
        }

        public bool IsUserConnected(int userId)
        {
            return _connections.ContainsKey(userId);
        }

        private class UserConnection
        {
            public string ConnectionId { get; set; }
            public string Role { get; set; }
        }
    }
}
