using System.Text;

namespace DagaSourceGenerator
{
    public class ConstantSourceGenerator : ISourceGenerator
    {
        private List<ConstantDataTemplate> _dataList = [];

        public ConstantSourceGenerator()
        {
        }

        public void Initialize()
        {

        }

        public void Generate()
        {
            Dictionary<Namespace, List<int>> dataByNamespace = [];
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
                StringBuilder sb = new();
                sb.AppendLine(ns);
                sb.AppendLine();
                index.ForEach(x => sb.AppendLine(_dataList[x].ToString()));
            }
        }
    }
}
