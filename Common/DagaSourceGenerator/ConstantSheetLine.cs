using DagaUtility;
using System.Diagnostics;

namespace DagaSourceGenerator
{
    public class ConstantSheetLine : ISheetLine
    {
        public required string Name { get; init; }

        public required string Type { get; init; }

        public required string Value { get; init; }

        public override string ToString()
        {
            var findType = TypeMapper.Instance[Type];
            Debug.Assert(null != findType);

            string format = Value;
            if(findType == typeof(string))
            {
                format = $"\"{Value}\"";
            }

            return $"public const {TypeMapper.Instance[findType]} {Name} = {format};";
        }
    }
}
