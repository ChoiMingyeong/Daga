namespace DagaDataGenerator.SrcGenerator.Enum;

public class EnumEntity
{
    public string Name { get; set; }

    public double? Value { get; set; }

    public string? Comment { get; set; }

    public EnumEntity(string name, double? value = null, string? comment = null)
    {
        Name = name;
        Value = value;
        Comment = comment;
    }
}