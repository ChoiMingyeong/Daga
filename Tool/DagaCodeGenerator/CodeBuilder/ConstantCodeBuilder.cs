using DagaCodeGenerator.Code;

namespace DagaCodeGenerator.CodeBuilder
{
    public class ConstantCodeBuilder : ICodeBuilder
    {
        public ConstantCodeBuilder(IEnumerable<string[]> readLines)
        {
        }

        public ICode Build()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}