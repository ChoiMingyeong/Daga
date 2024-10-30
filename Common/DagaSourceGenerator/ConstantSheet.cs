using System.Text;

namespace DagaSourceGenerator
{
    public class ConstantSheet : ISheet<ConstantSheetLine>
    {
        public required string Name { get; init; }

        public Namespace Namespace { get; init; } = Namespace.Default;

        public ClassName ClassName { get; init; } = "Constant";

        public List<ConstantSheetLine> Values { get; init; } = [];

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(Namespace.ToString());
            sb.AppendLine(ClassName.ToString());
            sb.AppendLine("{");
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
