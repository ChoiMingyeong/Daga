using DagaCodeGenerator.Code;

namespace DagaCodeGenerator.CodeBuilder;

public interface ICodeBuilder : IDisposable
{
    public ICode Build();
}
