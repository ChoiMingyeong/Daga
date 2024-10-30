using DagaUtility;
using System.Text;

namespace DagaSourceGenerator
{
    public class EnumSheet : ISheet<EnumSheetLine>
    {
        public required string Name { get; init; }

        public Namespace Namespace { get; init; } = Namespace.Default;

        public Type Type { get; init; } = typeof(int);

        public List<EnumSheetLine> Values { get; init; } = [];

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(Namespace.ToString());
            sb.Append($"public enum {Name}");
            if (Type != typeof(int))
            {
                sb.Append($" : {TypeMapper.Instance[Type]}");
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
