using MemoryPack;
using System.Net.Sockets;
using System.Text;

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

        public async Task<bool> SendAsync<T>(T packet) where T : IPacket
        {
            if (null == _client || false == _client.Connected)
            {
                return false;
            }

            NetworkStream stream = _client.GetStream();

            var jsonPacket = MemoryPackSerializer.Serialize(packet);
            if (null == jsonPacket)
            {
                return false;
            }

            var packetTypeNameBytes = Encoding.UTF8.GetBytes(packet.GetType().Name);

            byte[] packetTypeNameLength = [(byte)packetTypeNameBytes.Length];
            await stream.WriteAsync(packetTypeNameLength);
            await stream.WriteAsync(packetTypeNameBytes);

            ushort packetLength = (ushort)jsonPacket.Length;
            var lengthBytes = BitConverter.GetBytes(packetLength);
            await stream.WriteAsync(lengthBytes.AsMemory());
            await stream.WriteAsync(jsonPacket.AsMemory());

            return true;
        }
    }
}
