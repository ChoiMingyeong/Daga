namespace DagaDataGenerator.SrcGenerator;

public class ISrc<T> where T : IEntity
{
    public virtual string Name { get; protected set; } = string.Empty;

    public virtual List<T> Entities { get; protected set; } = [];

    public virtual string? Summary { get; protected set; }

    public ISrc(string name, string? summary = null, params T[] entities)
    {
        Name = name;
        Entities = [.. entities];
        Summary = summary;
    }
}
