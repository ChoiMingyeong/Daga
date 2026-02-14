namespace DagaDataTableEditor
{
    public class IdGenerator
    {
        private readonly Dictionary<Type, uint> _IdCounters = [];

        public uint Next<T>()
        {
            Type type = typeof(T);

            // 아직 해당 타입의 키가 없으면 0으로 초기화
            if (!_IdCounters.ContainsKey(type))
            {
                _IdCounters[type] = 0;
            }

            return ++_IdCounters[type];
        }

        public void Reset<T>()
        {
            Type type = typeof(T);
            _IdCounters[type] = 0;
        }

        public void ResetAll()
        {
            _IdCounters.Clear();
        }
    }
}
