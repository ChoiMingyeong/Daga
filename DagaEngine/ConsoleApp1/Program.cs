namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await DagaEngine.DagaEngine.Instance.InitializeAsync();

            DagaEngine.DagaEngine.Instance.SceneMgr.AddScene(new() { Name = "Scene1" });
            DagaEngine.DagaEngine.Instance.SceneMgr.NowScene!.AddGameObject(new TestObject() { Name = "TestObject1" });


            await DagaEngine.DagaEngine.Instance.RunAsync();
        }
    }
}
