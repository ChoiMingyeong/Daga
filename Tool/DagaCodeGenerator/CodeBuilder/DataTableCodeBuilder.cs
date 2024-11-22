namespace DagaCodeGenerator.CodeBuilder
{
    public class DataTableCodeBuilder : ICodeBuilderBase
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