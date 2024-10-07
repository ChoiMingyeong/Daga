using DagaDev;
using MemoryPack;

namespace DagaClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            DagaTcpClient client = new DagaTcpClient();
            Console.WriteLine(await client.ConnectAsync("127.0.0.1", 5080));

            var packet = new TestPacket { AA = 5555 };
            await client.SendAsync(packet);
            Console.ReadLine();
        }
    }
}
