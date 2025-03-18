namespace DagaCommon.Utility
{
    public static class NumericUtils
    {
        public static bool IsNumericType(Type type)
        {
            return type == typeof(byte) || type == typeof(sbyte) ||
                   type == typeof(short) || type == typeof(ushort) ||
                   type == typeof(int) || type == typeof(uint) ||
                   type == typeof(long) || type == typeof(ulong) ||
                   type == typeof(float) || type == typeof(double) ||
                   type == typeof(decimal);
        }

        public static double GetMinValue(Type type)
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

        public static double GetMaxValue(Type type)
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
    }
}
