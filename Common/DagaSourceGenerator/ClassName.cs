namespace DagaSourceGenerator
{
    public class ClassName
    {
        public required string Value { get; set; }

        public static implicit operator string(ClassName className)
        {
            return className.Value;
        }

        public static implicit operator ClassName(string className)
        {
            return new ClassName() { Value = className };
        }
    }
}
