using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace DagaCommon.Utility
{
    public static class PropertyAccessor
    {
        private static readonly ConcurrentDictionary<string, PropertyInfo> _propertyInfoCache = [];
        private static readonly ConcurrentDictionary<PropertyInfo, Delegate> _getterCache = [];
        private static readonly ConcurrentDictionary<PropertyInfo, Delegate> _setterCache = [];

        private static string Key<TDeclaring, TProperty>(string propertyName)
            => $"{typeof(TDeclaring).FullName}.{propertyName}<{typeof(TProperty).FullName}>";

        public static Func<TDeclaring, TProperty> GetGetter<TDeclaring, TProperty>(string propertyName)
            => (Func<TDeclaring, TProperty>)_getterCache.GetOrAdd(
                GetCachedPropertyInfo<TDeclaring, TProperty>(propertyName), CreateGetter<TDeclaring, TProperty>);

        public static Action<TDeclaring, TProperty> GetSetter<TDeclaring, TProperty>(string propertyName)
            => (Action<TDeclaring, TProperty>)_setterCache.GetOrAdd(
                GetCachedPropertyInfo<TDeclaring, TProperty>(propertyName), CreateSetter<TDeclaring, TProperty>);

        private static PropertyInfo GetCachedPropertyInfo<TDeclaring, TProperty>(string propertyName)
        {
            if (_propertyInfoCache.TryGetValue(Key<TDeclaring, TProperty>(propertyName), out var propertyInfo))
            {
                return propertyInfo;
            }

            propertyInfo = CreateCachedPropertyInfo<TDeclaring>(propertyName);
            _propertyInfoCache.TryAdd(Key<TDeclaring, TProperty>(propertyName), propertyInfo);
            return propertyInfo;
        }

        private static PropertyInfo CreateCachedPropertyInfo<TDeclaring>(string propertyName)
        {
            var type = typeof(TDeclaring);
            if (type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                is not PropertyInfo propertyInfo)
            {
                throw new ArgumentException($"Property '{propertyName}' not found on '{type.FullName}'. Ensure the property exists and is accessible.");
            }

            return propertyInfo;
        }

        private static Func<TDeclaring, TProperty> CreateGetter<TDeclaring, TProperty>(PropertyInfo propertyInfo)
        {
            var instance = Expression.Parameter(typeof(TDeclaring), "instance");
            var propertyAccess = Expression.Property(instance, propertyInfo);
            var lambda = Expression.Lambda<Func<TDeclaring, TProperty>>(propertyAccess, instance);
            return lambda.Compile();
        }

        private static Action<TDeclaring, TProperty> CreateSetter<TDeclaring, TProperty>(PropertyInfo property)
        {
            if (!property.CanWrite)
            {
                throw new InvalidOperationException($"Property '{property.Name}' is read-only or does not have a setter.");
            }

            var instance = Expression.Parameter(typeof(TDeclaring), "instance");
            var value = Expression.Parameter(typeof(TProperty), "value");
            var propertyAccess = Expression.Property(instance, property);
            var assign = Expression.Assign(propertyAccess, value);
            var lambda = Expression.Lambda<Action<TDeclaring, TProperty>>(assign, instance, value);
            return lambda.Compile();
        }
    }
}
