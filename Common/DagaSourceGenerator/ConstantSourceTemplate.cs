namespace DagaSourceGenerator
{
    public class ConstantSourceTemplate
    {
        public string Namespace { get; set; } = string.Empty;

        public List<ConstantDataTemplate> DataList { get; set; } = [];
    }
}
