using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace DagaDataGenerator.SrcGenerator.Enum;

public class EnumSrcGenerator(string @namespace) : ISrcGenerator
{
    public string Namespace { get; set; } = @namespace;

    public Dictionary<string, IEnum> Enums { get; private set; } = [];

    public IEnum? this[string enumName]
    {
        get
        {
            if (false == Enums.TryGetValue(enumName, out var @enum))
            {
                return null;
            }

            return @enum;
        }
    }

    public bool TryAddEntity(params object?[]? objects)
    {
        IEnum entity;
        try
        {
            entity = new IEnum(objects);
        }
        catch
        {
            return false;
        }
        
        return Enums.TryAdd(entity.Name, entity);
    }

    public bool CreateSource(params string[] strs)
    {
        if (strs.Length <= 2 ||
            strs[0] is not string filePath ||
            strs[1] is not string fileName ||
            string.IsNullOrWhiteSpace(fileName))
        {
            return false;
        }

        var compilationUnit = SyntaxFactory.CompilationUnit()
            .AddMembers(
                SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(Namespace))
                .AddMembers(Enums.Values.Select(p => p.ToSource()).ToArray())
            ).NormalizeWhitespace(elasticTrivia: true);
        var sourceCode = compilationUnit.ToFullString();

        if (false == Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        try
        {
            File.WriteAllText(Path.Combine(filePath, $"{fileName}.cs"), sourceCode);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}