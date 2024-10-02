namespace DagaUtility
{
    public class Singleton<T> where T : class, new()
    {
        private static Lazy<T>? _instance = null;
        public static T Instance
        {
            get
            {
                _instance ??= new();
                return _instance.Value;
            }
        }
    }
}
