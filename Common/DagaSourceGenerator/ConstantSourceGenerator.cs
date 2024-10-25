using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DagaSourceGenerator
{
    public class ConstantSourceGenerator : ISourceGenerator<ConstantData>
    {
        private List<ConstantData> _dataList = [];

        public ConstantSourceGenerator()
        {
        }

        public void Initialize(IEnumerable<ConstantData> data)
        {
            _dataList.Clear();
            _dataList.AddRange(data);
        }

        public void Generate()
        {
            Dictionary<string, List<int>> dataByNamespace = [];
            for (int i = 0; i < _dataList.Count; ++i)
            {
                if (false == dataByNamespace.ContainsKey(_dataList[i].ClassName))
                {
                    dataByNamespace[_dataList[i].ClassName] = [];
                }

                dataByNamespace[_dataList[i].ClassName].Add(i);
            }

            DirectoryInfo binDirectory = new(AppDomain.CurrentDomain.BaseDirectory);
            var solutionPath = binDirectory.Parent?.Parent?.Parent?.FullName ?? "";

            foreach (var (@class, indexList) in dataByNamespace)
            {
                var pathTokens = ((Namespace)@class).Value.Split('.').ToList();
                if (pathTokens[0] == Namespace.Default)
                {
                    pathTokens.Remove(pathTokens[0]);
                }
                if (pathTokens.Count <= 0)
                {
                    pathTokens.Add("Constant");
                }

                var className = pathTokens.Last();
                var fileName = string.Join('.', className, "cs");
                var filePath = Path.Combine(solutionPath, fileName);

                StringBuilder sb = new();
                sb.AppendLine(((Namespace)@class).ToString());
                sb.Append($"\npublic class {className}\n{{");
                indexList.ForEach(x => sb.AppendLine($"\n\t{_dataList[x].ToString()}"));
                sb.AppendLine("}");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, sb.ToString());
            }
        }
    }
}
