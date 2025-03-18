using System.Reflection;
using System.Collections.Concurrent;

namespace DagaCommon
{
    public static class CalculatorHelper
    {
        public static readonly Dictionary<Type, Action<PropertyInfo, object, object>> _customMergeActions = new();

        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _propertyCache = new();

        public static bool TryAdd(Type propertyType, Action<PropertyInfo, object, object> action)
        {
            return _customMergeActions.TryAdd(propertyType, action);
        }

        public static bool Remove(Type propertyType)
        {
            return _customMergeActions.Remove(propertyType);
        }

        public static void AddProperties<T>(T target, T source)
        {
            if (target == null) throw new ArgumentNullException(nameof(target), "Target 객체가 null입니다.");
            if (source == null) throw new ArgumentNullException(nameof(source), "Source 객체가 null입니다.");

            var properties = GetPropertiesWithCalculateAttribute<T>();

            foreach (var prop in properties)
            {
                if (_customMergeActions.TryGetValue(prop.PropertyType, out var action))
                {
                    action(prop, target, source);
                }
                else if (typeof(string) == prop.PropertyType)
                {
                    var targetValue = Convert.ToString(prop.GetValue(target) ?? string.Empty);
                    var sourceValue = Convert.ToString(prop.GetValue(source) ?? string.Empty);

                    if (string.IsNullOrEmpty(sourceValue))
                    {
                        continue;
                    }

                    prop.SetValue(target, targetValue + sourceValue);
                }
                else if (NumericUtils.IsNumericType(prop.PropertyType))
                {
                    var targetValue = Convert.ToDouble(prop.GetValue(target) ?? 0);
                    var sourceValue = Convert.ToDouble(prop.GetValue(source) ?? 0);

                    double addValue;
                    if (sourceValue < 0)
                    {
                        var typeMinValue = NumericUtils.GetMinValue(prop.PropertyType);
                        addValue = (targetValue >= typeMinValue - sourceValue) ? targetValue + sourceValue : typeMinValue;

                    }
                    else
                    {
                        var typeMaxValue = NumericUtils.GetMaxValue(prop.PropertyType);
                        addValue = (targetValue <= typeMaxValue - sourceValue) ? targetValue + sourceValue : typeMaxValue;
                    }

                    prop.SetValue(target, Convert.ChangeType(addValue, prop.PropertyType));
                }
            }
        }

        private static PropertyInfo[] GetPropertiesWithCalculateAttribute<T>()
        {
            var type = typeof(T);
            return _propertyCache.GetOrAdd(type, t =>
                t.GetProperties()
                 .Where(p => p.CanWrite && p.CanRead && p.GetCustomAttribute<CalculateAttribute>() != null)
                 .ToArray());
        }
    }
}
