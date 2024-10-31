namespace DagaSourceGenerator
{
    public class SourceGenerator
    {
        private Dictionary<Namespace, string> _sheets = [];

        public bool CombineCode { get; set; } = false;
    }
}
