namespace DagaEngine
{
    public static class DagaTime
    {
        public static float DeltaTime { get; private set; }

        private static DateTime _previousUpdate = DateTime.UtcNow;

        public static void Update()
        {
            var currentTime = DateTime.UtcNow;
            DeltaTime = (float)(currentTime - _previousUpdate).TotalSeconds / 1000f;
            _previousUpdate = currentTime;
        }
    }
}
