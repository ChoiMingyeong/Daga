namespace DagaCodeGenerator.Code;

public abstract class ICode
{
    public required IEnumerable<string[]> ReadLines { get; init; }

    public abstract bool CreateFile();
}
