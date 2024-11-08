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

        public async Task<WebSocket?> GetConnectionAsync(long accountID)
        {
            if(false == _connections.TryGetValue(accountID, out WebSocket? ws))
            {
                return null;
            }

            if(ws.State != WebSocketState.Connecting)
            {
                return null;
            }

            return ws;
        }
    }
}
