using DagaNetwork;

namespace DagaClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            DagaTcpClient client = new DagaTcpClient();
            while (true)
            {
                while (await client.ConnectAsync("127.0.0.1", 5080)) ;

                var packet = new TestPacket { AA = 5555 };
                await client.SendAsync(packet);
                while (false == client.IsConnected) ;
            }
        }
    }
}
