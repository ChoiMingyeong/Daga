using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DagaCommon
{
    public static partial class CommonUtility
    {
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _keyPropertyCache = new();

        public static object? GetOrAddKey<T>(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var type = typeof(T);
            var keyProperties = _keyPropertyCache.GetOrAdd(type, t =>
                t.GetProperties()
                 .Where(p => p.GetCustomAttribute<KeyAttribute>() != null)
                 .ToArray());

            if (keyProperties.Length == 0)
                throw new InvalidOperationException($"클래스 {type.Name}에 [Key] 속성이 없습니다.");

            // 단일 키일 경우, 해당 값 반환
            if (keyProperties.Length == 1)
            {
                return keyProperties[0].GetValue(entity);
            }

            // 복합 키일 경우, Tuple 생성
            return Tuple.Create(keyProperties.Select(p => p.GetValue(entity)).ToArray());
        }
    }
}
