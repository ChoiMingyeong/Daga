namespace DagaDataGenerator;

public static class ObjectConverter
{
    public static object? ConvertObject(object obj, Type type)
    {
        if (null == obj)
        {
            return null;
        }

        if (type.IsEnum)
        {
            if (obj is not string str ||
                false == Enum.IsDefined(type, obj) ||
                false == Enum.TryParse(type, str, out var result))
            {
                return null;
            }

            return result;
        }
        else if (type.IsGenericType && typeof(Tuple<>).GetGenericTypeDefinition() == type.GetGenericTypeDefinition())
        {
            return null;
        }
        else if (type == typeof(Guid))
        {
            if (obj is not string str ||
                false == Guid.TryParse(str, out var result))
            {
                return null;
            }

            return result;
        }
        else
        {
            return Convert.ChangeType(obj, type);
        }
    }
}