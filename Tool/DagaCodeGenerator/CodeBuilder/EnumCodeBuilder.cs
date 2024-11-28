using DagaCodeGenerator.Code;

namespace DagaCodeGenerator.CodeBuilder
{
    public class EnumCodeBuilder : ICodeBuilder
    {
        public EnumCodeBuilder(IEnumerable<string[]> readLines)
        {
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}