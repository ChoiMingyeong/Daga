namespace DagaDev
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            DagaTcpServer server = new DagaTcpServer();
            await server.ListenAsync(5080);
            while (true)
            {
                await Task.Delay(10);
            }
            //DagaTcpClient client = new DagaTcpClient();
            //Console.WriteLine(await client.ConnectAsync("127.0.0.1", 5080));
            //await client.SendAsync(new TestPacket { AA = 1234 });
            //Console.ReadLine();
        }
    }
}
