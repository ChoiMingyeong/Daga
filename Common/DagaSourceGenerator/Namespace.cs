using System.Reflection;

namespace DagaSourceGenerator
{
    public class Namespace
    {
        private static string? _default = null;
        public static Namespace Default
        {
            get
            {
                if (null == _default)
                {
                    var assemblyNamespace = Assembly.GetExecutingAssembly().GetTypes()
                                                .Select(t => t.Namespace)
                                                .First(ns => !string.IsNullOrEmpty(ns));
                    _default = assemblyNamespace ?? string.Empty;
                }

                return _default;
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

        public static Namespace operator +(Namespace a, Namespace b)
        {
            return new Namespace() { Value = $"{a.Value}.{b.Value}" };
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
