namespace DagaDataTableEditor
{
    public static class DataTypeConverter
    {
        public static bool IsTypeUnsigned(Type type)
        {
            return type == typeof(byte) || type == typeof(ushort) || type == typeof(uint) || type == typeof(ulong);
        }

        /// <summary>
        /// 사용자 정의 데이터 타입을 시스템 Type으로 변환합니다.
        /// </summary>
        /// <param name="dataType">변환할 데이터 타입</param>
        /// <param name="isUnsigned">Unsigned 여부</param>
        /// <returns>매핑된 시스템 Type</returns>
        /// <exception cref="ArgumentOutOfRangeException">지원하지 않는 데이터 타입일 경우 발생합니다.</exception>
        public static Type ConvertDataType(DataTypes dataType, bool isUnsigned)
        {
            return dataType switch
            {
                DataTypes.String => typeof(string),
                DataTypes.Bool => typeof(bool),
                DataTypes.Byte => isUnsigned ? typeof(byte) : typeof(sbyte),
                DataTypes.Short => isUnsigned ? typeof(ushort) : typeof(short),
                DataTypes.Int => isUnsigned ? typeof(uint) : typeof(int),
                DataTypes.Long => isUnsigned ? typeof(ulong) : typeof(long),
                DataTypes.Float => typeof(float),
                DataTypes.Enum => typeof(Enum),
                _ => throw new ArgumentOutOfRangeException(nameof(dataType), $"Unsupported data type: {dataType}"),
            };
        }

        public static string GetDefaultValue(Type type)
        {
            if (type == typeof(string))
            {
                return string.Empty;
            }
            else if (type == typeof(bool))
            {
                return "false";
            }
            else if (type == typeof(byte) || type == typeof(sbyte) ||
                     type == typeof(short) || type == typeof(ushort) ||
                     type == typeof(int) || type == typeof(uint) ||
                     type == typeof(long) || type == typeof(ulong) ||
                     type == typeof(float))
            {
                return "0";
            }
            else if (type.IsEnum)
            {
                return Enum.GetNames(type).FirstOrDefault() ?? "0";
            }
            else
            {
                throw new ArgumentException($"Unsupported type: {type}", nameof(type));
            }
        }
    }
}
