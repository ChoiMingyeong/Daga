using DagaCodeGenerator.Code;

namespace DagaCodeGenerator.CodeBuilder
{
    public class EnumCodeBuilder : ICodeBuilder
    {
        public EnumCodeBuilder(IEnumerable<string[]> readLines)
        {
        }

        public void Build()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}