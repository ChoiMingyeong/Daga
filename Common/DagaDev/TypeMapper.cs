using DagaUtility;
using System.Reflection;

namespace DagaDev
{
    public class TypeMapper : Singleton<TypeMapper>
    {
        private readonly Dictionary<string, Type> _typeNameMapping;

        public Type? this[string typeName]
        {
            get
            {
                if (_typeNameMapping.TryGetValue(typeName, out var type))
                {
                    return type;
                }
                else
                {
                    return null;
                }
            }
        }

        public TypeMapper()
        {
            _typeNameMapping = [];

            InitDefaultTypes();
            InitCustomEnumTypes();
        }

        private void InitDefaultTypes()
        {
            MapTypeWithName(type: typeof(string));
            MapTypeWithName(type: typeof(string), typeName: "string");
            MapTypeWithName(type: typeof(byte));
            MapTypeWithName(type: typeof(byte), typeName: "byte");
            MapTypeWithName(type: typeof(short));
            MapTypeWithName(type: typeof(short), typeName: "short");
            MapTypeWithName(type: typeof(int));
            MapTypeWithName(type: typeof(int), typeName: "int");
            MapTypeWithName(type: typeof(long));
            MapTypeWithName(type: typeof(long), typeName: "long");
            MapTypeWithName(type: typeof(float));
            MapTypeWithName(type: typeof(float), typeName: "float");
            MapTypeWithName(type: typeof(double));
            MapTypeWithName(type: typeof(double), typeName: "double");
            MapTypeWithName(type: typeof(bool));
            MapTypeWithName(type: typeof(bool), typeName: "bool");
            MapTypeWithName(type: typeof(char));
            MapTypeWithName(type: typeof(char), typeName: "char");
        }

        private void InitCustomEnumTypes()
        {
            var enumType = Assembly
                .GetExecutingAssembly()
                .GetTypes();
        }

        private bool MapTypeWithName(Type type)
        {
            return MapTypeWithName(typeName: type.Name, type: type);
        }

        private bool MapTypeWithName(string typeName, Type type)
        {
            return _typeNameMapping.TryAdd(key: typeName, value: type);
        }
    }
}
