using DagaUtility;

namespace DagaSourceGenerator
{
    public class ConstantData : IDataTempltate
    {
        public Namespace Namespace { get; set; } = Namespace.Default;

        public required ClassName ClassName { get; set; } = "Constant";

        public required string Type { get; set; }

        public required string Name { get; set; }

        public required string Value { get; set; }

        public override string ToString()
        {
            Type = Type.Trim();
            Name = Name.Trim();
            Value = Value.Trim();

            if (string.IsNullOrEmpty(Type))
            {
                throw new ArgumentException("Type is empty.");
            }
            else if (TypeMapper.Instance[Type] is Type type)
            {
                Type = TypeMapper.Instance[type];
            }

            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("Name is empty.");
            }

            if (string.IsNullOrEmpty(Value))
            {
                throw new ArgumentException("Value is empty.");
            }

            return $"public const {Type} {Name} = {Value};";
        }
    }
}
