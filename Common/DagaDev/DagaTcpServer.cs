using MemoryPack;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.Json;

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
            int lengthSize = sizeof(ushort);
            byte[] buffer = new byte[lengthSize];
            try
            {
                while (client.Connected)
                {
                    await stream.ReadAsync(buffer.AsMemory(0, sizeof(byte)));

                    byte typeNameLen = buffer[0];
                    byte[] typeNameBuffer = new byte[typeNameLen];
                    await stream.ReadAsync(typeNameBuffer.AsMemory(0, typeNameLen));

                    string typeName = Encoding.UTF8.GetString(typeNameBuffer, 0, typeNameLen);
                    var type = assembly.GetTypes().Single(p => p.Name == typeName);
                    await stream.ReadAsync(buffer.AsMemory(0, lengthSize));

                    ushort packetLength = BitConverter.ToUInt16(buffer);
                    byte[] packetBuffer = new byte[packetLength];
                    await stream.ReadAsync(packetBuffer.AsMemory(0, packetLength));
                    if (MemoryPackSerializer.Deserialize(type, packetBuffer) is IPacket aa)
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
