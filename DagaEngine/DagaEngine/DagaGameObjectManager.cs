namespace DagaEngine
{
    public class DagaGameObjectManager : DagaManager<DagaGameObject>
    {
        public void Stop()
        {
            // Clean up resources
            foreach (var obj in _objects.Values)
            {
                obj.Stop();
            }
        }
    }
}
