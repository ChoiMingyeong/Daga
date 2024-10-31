using System.Text;

namespace DagaSourceGenerator
{
    public class ConstantSheet : ISheet<ConstantSheetLine>
    {
        public string Name { get; init; } = string.Empty;

        public Namespace Namespace { get; init; } = Namespace.Default;

        public ClassName ClassName { get; init; }

        public List<ConstantSheetLine> Values { get; init; } = [];

        public ConstantSheet(string name)
        {
            Name = name;

            var nameToken = Name.Split('.');
            if (nameToken.Length <= 1)
            {
                Namespace = Namespace.Default;
                ClassName = nameToken.LastOrDefault() ?? "Constant";
            }
            else
            {
                Namespace = string.Join('.', nameToken.Take(nameToken.Length - 1));
                ClassName = nameToken.Last();
            }
        }

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
