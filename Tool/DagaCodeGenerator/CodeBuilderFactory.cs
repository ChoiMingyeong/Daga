namespace DagaCodeGenerator
{
    public static class CodeBuilderFactory
    {
        public static CodeBuilderBase Create(CodeBuilderType codeBuilderType, IEnumerable<string[]> readLines)
        {
            return codeBuilderType switch
            {
                CodeBuilderType.Constant => new ConstantCodeBuilder(readLines),
                CodeBuilderType.Enum => new EnumCodeBuilder(readLines),
                CodeBuilderType.DataTable => new DataTableCodeBuilder(readLines),
                _ => throw new ArgumentOutOfRangeException(nameof(codeBuilderType)),
            };
        }
    }
}