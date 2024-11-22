namespace DagaCodeGenerator
{
    public class EnumCodeBuilder : ICodeBuilderBase
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