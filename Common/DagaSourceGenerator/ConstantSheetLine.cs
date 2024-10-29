using DagaUtility;

namespace DagaSourceGenerator
{
    public class ConstantSheetLine : ISheetLine
    {
        public required string Name { get; init; }

        public required string Type { get; init; }

        public required string Value { get; init; }

        public override string ToString()
        {
            return $"public const {TypeMapper.Instance[Type]} {Name} = {Value};";
        }
    }
}
