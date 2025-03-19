using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DagaCommon.Utility
{
    public static partial class CommonUtility
    {
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _keyPropertyCache = new();

        public static Key? GetOrAddKey<T>(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var type = typeof(T);
            var keyProperties = _keyPropertyCache.GetOrAdd(type, t =>
                t.GetProperties()
                 .Where(p => p.GetCustomAttribute<KeyAttribute>() != null)
                 .ToArray());

            if (keyProperties.Length == 0)
            {
                return null;
            }

            var keyValues = keyProperties.Select(p => p.GetValue(entity)).ToArray();
            return new Key(keyValues);
        }
    }
}
