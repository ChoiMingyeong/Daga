using System.Reflection;

namespace DagaCommon
{
    public static class CalculatorHelper
    {
        /// <summary>
        /// <see cref="typeof(T)"/>가 숫자타입일 때, target의 값을 source의 값과 합산합니다.
        /// </summary>
        /// <exception cref="ArgumentNullException">target이나 source가 null이면 발생</exception>
        public static void AddProperties<T>(T target, T source)
        {
            if (target == null || source == null)
            {
                throw new ArgumentNullException();
            }

            // T 타입의 속성(Property) 중 CalculateAttribute가 붙은 속성만 가져오기
            var properties = typeof(T).GetProperties()
                .Where(p => p.CanWrite && p.CanRead && p.GetCustomAttribute<CalculateAttribute>() != null);

            foreach (var prop in properties)
            {
                if (target == null || source == null)
                {
                    throw new ArgumentNullException();
                }

                if (IsNumericType(prop.PropertyType))
                {
                    var targetValue = Convert.ToDouble(prop.GetValue(target) ?? 0);
                    var sourceValue = Convert.ToDouble(prop.GetValue(source) ?? 0);
                    
                    double addValue;
                    if (sourceValue < 0)
                    {
                        var typeMinValue = GetMinValue(prop.PropertyType);
                        addValue = (targetValue >= typeMinValue - sourceValue)? targetValue + sourceValue : typeMinValue;

                    }
                    else
                    {
                        var typeMaxValue = GetMaxValue(prop.PropertyType);
                        addValue = (targetValue <= typeMaxValue - sourceValue) ? targetValue + sourceValue : typeMaxValue;
                    }

                    prop.SetValue(target, Convert.ChangeType(addValue, prop.PropertyType));
                }
            }
        }

        private static double GetMinValue(Type type)
        {
            if (type == typeof(int)) return int.MinValue;
            if (type == typeof(uint)) return uint.MinValue;
            if (type == typeof(long)) return long.MinValue;
            if (type == typeof(ulong)) return ulong.MinValue;
            if (type == typeof(short)) return short.MinValue;
            if (type == typeof(ushort)) return ushort.MinValue;
            if (type == typeof(byte)) return byte.MinValue;
            if (type == typeof(sbyte)) return sbyte.MinValue;
            if (type == typeof(double)) return double.MinValue;
            if (type == typeof(float)) return float.MinValue;

            throw new ArgumentException("지원되지 않는 숫자 타입입니다.", nameof(type));
        }

        private static double GetMaxValue(Type type)
        {
            if (type == typeof(int)) return int.MaxValue;
            if (type == typeof(uint)) return uint.MaxValue;
            if (type == typeof(long)) return long.MaxValue;
            if (type == typeof(ulong)) return ulong.MaxValue;
            if (type == typeof(short)) return short.MaxValue;
            if (type == typeof(ushort)) return ushort.MaxValue;
            if (type == typeof(byte)) return byte.MaxValue;
            if (type == typeof(sbyte)) return sbyte.MaxValue;
            if (type == typeof(double)) return double.MaxValue;
            if (type == typeof(float)) return float.MaxValue;

            throw new ArgumentException("지원되지 않는 숫자 타입입니다.", nameof(type));
        }

        private static bool IsNumericType(Type type)
        {
            return type == typeof(byte) || type == typeof(sbyte) ||
                   type == typeof(short) || type == typeof(ushort) ||
                   type == typeof(int) || type == typeof(uint) ||
                   type == typeof(long) || type == typeof(ulong) ||
                   type == typeof(float) || type == typeof(double) ||
                   type == typeof(decimal);
        }
    }
}
