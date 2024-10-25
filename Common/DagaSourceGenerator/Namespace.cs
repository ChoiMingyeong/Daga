using System.Reflection;

namespace DagaSourceGenerator
{
    public class Namespace
    {
        private static string? _defaultNamespace = null;
        public static Namespace DefaultNamespace
        {
            get
            {
                if (null == _defaultNamespace)
                {
                    var assemblyNamespace = Assembly.GetExecutingAssembly().GetTypes()
                                                .Select(t => t.Namespace)
                                                .First(ns => !string.IsNullOrEmpty(ns));
                    _defaultNamespace = assemblyNamespace ?? string.Empty;
                }

                return _defaultNamespace;
            }
        }

        public string Value { get; set; } = string.Empty;

        public static implicit operator string(Namespace @namespace)
        {
            return @namespace.Value;
        }

        public static implicit operator Namespace(string @namespace)
        {
            return new Namespace { Value = @namespace };
        }

        public override string ToString()
        {
            Value = Value.Trim();
            if (string.IsNullOrEmpty(Value))
            {
                return string.Empty;
            }

            return $"namespace {Value};";
        }
    }
}
