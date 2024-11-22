namespace DagaCodeGenerator
{
    public class ConstantCodeBuilder : ICodeBuilderBase
    {
        public ConstantCodeBuilder(IEnumerable<string[]> readLines)
        {
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}