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
                    prop.SetValue(target, Convert.ChangeType(targetValue + sourceValue, prop.PropertyType));
                }
            }
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
