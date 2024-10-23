using DagaUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DagaDev
{
    public class TypeMapper : Singleton<TypeMapper>
    {
        private readonly Dictionary<string, Type> _typeNameMapping;

        public Type? this[string typeName]
        {
            get
            {
                if (_typeNameMapping.TryGetValue(typeName.Trim().ToLower(), out var type))
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

            MapTypeWithName(typeof(string));
            MapTypeWithName(typeof(string), "string");
            MapTypeWithName(typeof(byte));
            MapTypeWithName(typeof(byte), "byte");
            MapTypeWithName(typeof(short));
            MapTypeWithName(typeof(short), "short");
            MapTypeWithName(typeof(int));
            MapTypeWithName(typeof(int), "int");
            MapTypeWithName(typeof(long));
            MapTypeWithName(typeof(long), "long");
            MapTypeWithName(typeof(float));
            MapTypeWithName(typeof(float), "float");
            MapTypeWithName(typeof(double));
            MapTypeWithName(typeof(double), "double");
            MapTypeWithName(typeof(bool));
            MapTypeWithName(typeof(bool), "bool");
            MapTypeWithName(typeof(char));
            MapTypeWithName(typeof(char), "char");
        }

        private bool MapTypeWithName(Type type)
        {
            return MapTypeWithName(type, type.Name);
        }

        private bool MapTypeWithName(Type type, string typeName)
        {
            return _typeNameMapping.TryAdd(typeName.Trim().ToLower(), type);
        }
    }
}
