using System.Net.Sockets;
using System.Text.Json;

namespace DagaDev
{
    public class DagaTcpClient : IDisposable
    {
        private TcpClient? _client = null;

        public void Dispose()
        {
            _client?.Close();
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<bool> ConnectAsync(string host, int port, int timeout = 0)
        {
            _client ??= new();

            try
            {
                Task connectTask = _client.ConnectAsync(host, port);
                return await Task.WhenAny(connectTask, Task.Delay(timeout)) == connectTask;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SendAsync(IPacket packet)
        {
            if (null == _client || false == _client.Connected)
            {
                return false;
            }

            NetworkStream stream = _client.GetStream();

            var jsonPacket = JsonSerializer.Serialize(packet);
            if (null == jsonPacket)
            {
                return false;
            }

            ushort packetLength = (ushort)jsonPacket.Length;
            var lengthBytes = BitConverter.GetBytes(packetLength);
            await stream.WriteAsync(lengthBytes.AsMemory());
            return true;
        }
    }
}
