using DagaUtility;
using System.Text;

namespace DagaSourceGenerator
{
    public class EnumSheet : ISheet<EnumSheetLine>
    {
        public required string Name { get; init; }

        public Namespace Namespace { get; init; } = Namespace.Default;

        public string Type { get; init; } = string.Empty;

        public List<EnumSheetLine> Values { get; init; } = [];

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(Namespace.ToString());
            sb.Append($"public enum {Name}");
            if (false == string.IsNullOrWhiteSpace(Type) &&
                TypeMapper.Instance[Type] is Type type)
            {
                sb.Append($" : {TypeMapper.Instance[type]}");
            }
            sb.AppendLine("\n{");
            foreach (var value in Values)
            {
                sb.Append('\t');
                sb.AppendLine(value.ToString());
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
