using DagaDev;
using MemoryPack;
using System.Text;
using System.Text.Json;

namespace DagaServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            DagaTcpServer server = new DagaTcpServer();
            Task task = Task.Run(async () =>
            {
                while (true)
                {
                    while (false == server.PacketQueue.IsEmpty)
                    {
                        if (server.PacketQueue.TryDequeue(out IPacket? packet) && packet is not null)
                        {
                            var stringBuilder = new StringBuilder();
                            stringBuilder.Append($"[{packet.GetType().Name}]");

                            var properties = packet.GetType().GetProperties();
                            foreach (var property in properties)
                            {
                                stringBuilder.Append($"{property.Name}:{property.GetValue(packet)},");
                            }

                            Console.WriteLine(stringBuilder.ToString());
                        }

                    }

                    await Task.Delay(10);
                }
            });

            await server.ListenAsync(5080);
        }
    }
}
