using DagaCodeGenerator.Code;

namespace DagaCodeGenerator.CodeBuilder
{
    public class DataTableCodeBuilder : ICodeBuilder
    {
        public DataTableCodeBuilder(IEnumerable<string[]> readLines)
        {
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}