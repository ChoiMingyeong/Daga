namespace DagaEngine
{
    public class Singleton<T> where T : class, new()
    {
        public static T Instance
        {
            get
            {
                _instance ??= new();
                return _instance.Value;
            }
        }

        private static Lazy<T>? _instance = null;
    }
}
