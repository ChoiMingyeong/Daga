namespace DagaDataGenerator.SrcGenerator.Enum;

public class IEnum
{
    public string Name { get; private set; }

    public List<EnumEntity> Entities { get; private set; } = [];

    public string? Summary { get; private set; }

    public IEnum(object?[]? objects)
    {
        ArgumentNullException.ThrowIfNull(objects);

        if (objects[0] is not string name)
        {
            throw new InvalidCastException(nameof(objects));
        }
        Name = name;

        if (objects.Length > 1 && objects[1] is string summary)
        {
            Summary = summary;
        }
    }

    public EnumEntity? this[string entityName]
    {
        get
        {
            var entity = Entities.SingleOrDefault(p => p.Name == entityName);
            if (null == entity)
            {
                return null;
            }

            return new(entity.Name, GetEntityValue(entity), entity.Comment);
        }
    }

    public EnumEntity? this[ushort entityIndex]
    {
        get
        {
            if (Entities.Count <= entityIndex)
            {
                return null;
            }

            var entity = Entities[entityIndex];
            return new(entity.Name, GetEntityValue(entity), entity.Comment);
        }
    }

    private double GetEntityValue(EnumEntity entity)
    {
        if (null != entity.Value)
        {
            return entity.Value.Value;
        }

        int index = Entities.IndexOf(entity);
        if (index == 0)
        {
            return 0;
        }
        else if (Entities.Where(p => Entities.IndexOf(p) < index).All(p => null == p.Value))
        {
            return index;
        }
        else
        {
            var standard = Entities.Where(p => p.Value != null && Entities.IndexOf(p) < index).Last();
            return standard.Value!.Value + (index - Entities.IndexOf(standard));
        }
    }

    public bool TryAddEntity(EnumEntity entity)
    {
        if (Entities.Any(p => p.Name.Equals(entity.Name)))
        {
            return false;
        }

        Entities.Add(entity);

        return true;
    }
}
