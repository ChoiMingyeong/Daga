namespace DagaSourceGenerator
{
    public class EnumData : IDataTempltate
    {
        public Namespace Namespace { get; set; } = Namespace.Default;

        public required ClassName ClassName { get; set; } = "Enum";
    }
}
