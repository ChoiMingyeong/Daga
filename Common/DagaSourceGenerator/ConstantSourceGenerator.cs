using System.Text;

namespace DagaSourceGenerator
{
    public class ConstantSourceGenerator : ISourceGenerator<ConstantDataTemplate>
    {
        private List<ConstantDataTemplate> _dataList = [];

        public ConstantSourceGenerator()
        {
        }

        public void Initialize(IEnumerable<ConstantDataTemplate> data)
        {
            _dataList.Clear();
            _dataList.AddRange(data);
        }

        public void Generate()
        {
            Dictionary<string, List<int>> dataByNamespace = [];
            for (int i = 0; i < _dataList.Count; ++i)
            {
                if (false == dataByNamespace.ContainsKey(_dataList[i].Namespace))
                {
                    dataByNamespace[_dataList[i].Namespace] = [];
                }

                dataByNamespace[_dataList[i].Namespace].Add(i);
            }

            foreach (var (ns, index) in dataByNamespace)
            {
                Console.WriteLine($"FileName: {ns.Replace($"{Namespace.Default.Value}.","")}");
                StringBuilder sb = new();
                sb.AppendLine(((Namespace)ns).ToString());
                sb.AppendLine();
                index.ForEach(x => sb.AppendLine(_dataList[x].ToString()));
                Console.Write(sb);
                Console.WriteLine("*********");
                Console.WriteLine("*********");
                Console.WriteLine("*********");
            }
        }
    }
}
