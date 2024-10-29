using DagaUtility;
using System.Text;

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

    public interface ISheet<T> where T : ISheetLine
    {
        public string Name { get; init; }

        public List<T> Values { get; init; }
    }

    public class ConstantSheet : ISheet<ConstantSheetLine>
    {
        public required string Name { get; init; }

        public Namespace Namespace { get; init; }

        public ClassName ClassName { get; init; }

        public List<ConstantSheetLine> Values { get; init; } = [];

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(Namespace.ToString());
            sb.AppendLine(ClassName.ToString());
            sb.Append('{');
            foreach (var value in Values)
            {
                sb.Append('\t');
                sb.AppendLine(value.ToString());
            }
            sb.Append('}');
            return sb.ToString();
        }
    }
}
