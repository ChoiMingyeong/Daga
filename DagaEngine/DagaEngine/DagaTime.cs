using System.Collections.Concurrent;

namespace DagaEngine
{
    public static class DagaTime
    {
        public static byte FPS { get; private set; }

        public static float DeltaTime { get; private set; }

        private static DateTime _previousUpdate = DateTime.UtcNow;

        private static byte _frameCount = 0;
        private static float _timeAccumulator = 0f;

        public static void Update()
        {
            var currentTime = DateTime.UtcNow;
            DeltaTime = (float)(currentTime - _previousUpdate).TotalMilliseconds / 1000f;
            _previousUpdate = currentTime;

            ++_frameCount;
            _timeAccumulator += DeltaTime;

            if(_timeAccumulator >= 1f)
            {
                FPS = _frameCount;
                _frameCount = 0;
                _timeAccumulator = 0f;
            }
        }
    }
}
