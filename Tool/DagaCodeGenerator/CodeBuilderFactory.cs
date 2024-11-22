namespace DagaCodeGenerator
{
    public static class CodeBuilderFactory
    {
        public static CodeBuilderBase Create(CodeBuilderType codeBuilderType, IEnumerable<string[]> readLines)
        {
            switch (codeBuilderType)
            {
                case CodeBuilderType.Constant:
                    return new ConstantCodeBuilder(readLines);
                case CodeBuilderType.Enum:
                    return new EnumCodeBuilder(readLines);
                case CodeBuilderType.DataTable:
                    return new DataTableCodeBuilder(readLines);
            }

            throw new ArgumentOutOfRangeException(nameof(codeBuilderType));
        }
    }
}