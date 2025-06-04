namespace DagaBlazorEngine.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class JSHelperAttribute(string modulePath) : Attribute
    {
        public string ModulePath { get; } = modulePath;
    }
}
