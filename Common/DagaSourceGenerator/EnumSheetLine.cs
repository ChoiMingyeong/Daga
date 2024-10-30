using System.Text;

namespace DagaSourceGenerator
{
    public class EnumSheetLine : ISheetLine
    {
        public required string Name { get; init; }

        public string Value { get; init; } = string.Empty;

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(Name);
            if(false == string.IsNullOrEmpty(Value))
            {
                sb.Append($" = {Value}");
            }
            sb.Append(',');
            return sb.ToString();
        }
    }
}
