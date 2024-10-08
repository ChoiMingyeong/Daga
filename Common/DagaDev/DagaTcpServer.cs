using MemoryPack;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace DagaDev
{
    public class DagaTcpServer : IDisposable
    {
        private TcpListener? _listener = null;

        private List<TcpClient>? _clients = null;

        public ConcurrentQueue<IPacket> PacketQueue { get; private set; } = [];

        private bool _isRunning = false;

        public void Dispose()
        {
            _isRunning = false;

            _listener?.Dispose();

            if (null != _clients)
            {
                foreach (var client in _clients)
                {
                    client.Close();
                    client.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }

        public async Task ListenAsync(int port)
        {
            if (_isRunning)
            {
                return;
            }

            _isRunning = true;

            _listener = new(IPAddress.Any, port);
            _listener.Start();

            await AcceptAsync();
        }

        public void Stop()
        {
            _isRunning = false;
            _listener?.Stop();

            if (null == _clients)
            {
                return;
            }

            foreach (var client in _clients)
            {
                if (client.Connected)
                {
                    client.Close();
                }
            }

            _clients.Clear();
        }

        private async Task AcceptAsync()
        {
            Debug.Assert(_listener != null);

            while (_isRunning)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();
                if (null == _clients)
                {
                    _clients = [];
                }
                _clients.Add(client);

                Task task = Task.Run(async () =>
                {
                    await HandleClientAsync(client);
                });
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            NetworkStream stream = client.GetStream();

            byte[] idBuffer = new byte[sizeof(uint)];
            byte[] lengthBuffer = new byte[sizeof(ushort)];
            try
            {
                while (client.Connected)
                {
                    await stream.ReadAsync(idBuffer.AsMemory(0, idBuffer.Length));
                    if(DagaPacketHandler.Instance.GetPacketType(BitConverter.ToUInt32(idBuffer, 0)) is not Type packetType)
                    {
                        await stream.FlushAsync();
                        continue;
                    }

                    await stream.ReadAsync(lengthBuffer.AsMemory(0, lengthBuffer.Length));
                    byte[] packetBuffer = new byte[BitConverter.ToUInt16(lengthBuffer, 0)];
                    await stream.ReadAsync(packetBuffer.AsMemory(0, packetBuffer.Length));

                    if (MemoryPackSerializer.Deserialize(packetType, packetBuffer) is IPacket aa)
                    {
                        PacketQueue.Enqueue(aa);
                    }

                    await Task.Delay(1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
