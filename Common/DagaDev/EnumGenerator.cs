
using System.Text;

namespace DagaDev
{
    public class EnumGenerator
    {
        public void Execute()
        {
            // 예시 데이터: 스프레드시트에서 받은 데이터를 대신함
            var enumData = new[] {
            new { Name = "Apple", Value = 1 },
            new { Name = "Banana", Value = 2 },
            new { Name = "Cherry", Value = 3 }
        };

            // Enum 생성 코드 작성
            var sb = new StringBuilder();
            sb.AppendLine("public enum GeneratedEnum");
            sb.AppendLine("{");
            foreach (var data in enumData)
            {
                sb.AppendLine($"    {data.Name} = {data.Value},");
            }
            sb.AppendLine("}");
        }
    }
}
