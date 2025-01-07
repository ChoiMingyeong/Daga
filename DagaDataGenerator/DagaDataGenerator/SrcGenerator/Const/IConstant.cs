using System.Diagnostics.Eventing.Reader;

namespace DagaDataGenerator.SrcGenerator.Const;

public class IConstant
{
    public string Name { get; private set; }

    public Type Type { get; set; }

    public object Value { get; set; }

    public string? Comment { get; set; }

    public IConstant(object?[]? objects)
    {
        ArgumentNullException.ThrowIfNull(objects);

        if (objects[0] is not string name || string.IsNullOrWhiteSpace(name) ||
            objects[1] is not Type type ||
            objects[2] is not object obj || ObjectConverter.ConvertObject(obj, type) is not object value)
        {
            throw new InvalidCastException(nameof(objects));
        }

        Name = name;
        Type = type;
        Value = value;

        if (objects.Length > 4 && objects[3] is string comment)
        {
            Comment = comment;
        }
    }
}
