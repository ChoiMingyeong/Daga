using DagaCodeGenerator.Code;

namespace DagaCodeGenerator.CodeBuilder
{
    public class EnumCodeBuilder : ICodeBuilder
    {
        public EnumCodeBuilder(IEnumerable<string[]> readLines)
        {
        }

        public ICode Build()
        {
            return new EnumCode();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}