using DagaCodeGenerator.Code;

namespace DagaCodeGenerator.CodeBuilder
{
    public class DataTableCodeBuilder : ICodeBuilder
    {
        public DataTableCodeBuilder(IEnumerable<string[]> readLines)
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