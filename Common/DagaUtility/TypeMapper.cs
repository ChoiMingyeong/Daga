using System.Diagnostics;
namespace DagaUtility;

public class TypeMapper : Singleton<TypeMapper>
{
    private readonly Dictionary<string, Type> _nameMap = [];
    private readonly Dictionary<string, string> _aliasDictionary = [];

    public Type? this[string typeName]
    {
        get
        {
            if(_aliasDictionary.TryGetValue(typeName, out string? fullName))
            {
                return _nameMap[fullName];
            }

            if (_nameMap.TryGetValue(typeName, out Type? type))
            {
                return type;
            }
            else
            {
                return null;
            }
        }
    }

    public string this[Type type]
    {
        get
        {
            Debug.Assert(null != type.FullName);

            if (_aliasDictionary.ContainsValue(type.FullName))
            {
                return _aliasDictionary.Single(p => p.Value == type.FullName).Key;
            }

            return type.Name;
        }
    }

    public TypeMapper()
    {
        InitDefaultTypes();
    }

    private void InitDefaultTypes()
    {
        TryAddType(type: typeof(byte), alias: "byte");
        TryAddType(type: typeof(sbyte), alias: "sbyte");
        TryAddType(type: typeof(short), alias: "short");
        TryAddType(type: typeof(ushort), alias: "ushort");
        TryAddType(type: typeof(int), alias: "int");
        TryAddType(type: typeof(uint), alias: "uint");
        TryAddType(type: typeof(long), alias: "long");
        TryAddType(type: typeof(ulong), alias: "ulong");
        TryAddType(type: typeof(float), alias: "float");
        TryAddType(type: typeof(double), alias: "double");
        TryAddType(type: typeof(decimal), alias: "decimal");
        TryAddType(type: typeof(char), alias: "char");
        TryAddType(type: typeof(bool), alias: "bool");
        TryAddType(type: typeof(object), alias: "object");
        TryAddType(type: typeof(string), alias: "string");
    }

    public bool TryAddType(Type type, string alias = "")
    {
        Debug.Assert(null != type.FullName);

        string trimAlias = alias.Trim();
        if (false == string.IsNullOrEmpty(trimAlias))
        {
            _aliasDictionary.TryAdd(key: alias, value: type.FullName);
        }
        return _nameMap.TryAdd(key: type.FullName, value: type);
    }
}
