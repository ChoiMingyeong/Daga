using System.Net.WebSockets;

namespace DagaServer
{
    public class ConnectionService
    {
        private Dictionary<long, WebSocket> _connections = [];

        public ConnectionService()
        {

        }

        public async Task<bool> AddConnectionAsync(WebSocket ws)
        {
            return true;
        }
    }
}
