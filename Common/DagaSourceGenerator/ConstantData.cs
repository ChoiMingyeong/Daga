using DagaUtility;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;

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

    public class SheetData<T> where T : ISheetLine
    {
        public required string SheetName { get; init; }

        public Namespace Namespace { get; init; }

        public string ClassName { get; init; }

        public List<T> DataList { get; init; } = [];

        public SheetData()
        {
            Debug.Assert(false == string.IsNullOrWhiteSpace(SheetName));

            SheetName = SheetName.Trim();
            var tokens = SheetName.Split('.');
            var namespaceTokens = SheetName.Take(tokens.Length - 1);
            var classNameToken = tokens[^1];

            Namespace = Namespace.Default;

            if (namespaceTokens.Any())
            {
                Namespace += string.Join('.', namespaceTokens);
            }

            ClassName = classNameToken;


        }


    }
}
