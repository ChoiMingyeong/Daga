namespace DagaDataGenerator.SrcGenerator.Enum;

public class EnumSrcGenerator : ISrcGenerator
{
    public Dictionary<string, IEnum> Enums { get; private set; } = [];

    public IEnum? this[string enumName]
    {
        get
        {
            if (false == Enums.TryGetValue(enumName, out var @enum))
            {
                return null;
            }

            return @enum;
        }
    }

    public bool TryAddEntity(params object?[]? objects)
    {
        IEnum entity;
        try
        {
            entity = new IEnum(objects);
        }
        catch
        {
            return false;
        }

        return Enums.TryAdd(entity.Name, entity);
    }

    public bool ToSource()
    {
        return false;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}