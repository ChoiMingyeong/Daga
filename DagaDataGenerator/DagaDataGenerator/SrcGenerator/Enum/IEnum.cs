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
