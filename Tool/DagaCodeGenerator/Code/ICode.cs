namespace DagaCodeGenerator.Code;

public abstract class ICode
{
    public ICode(IEnumerable<string[]> readLines);
    public abstract bool CreateFile();
}
