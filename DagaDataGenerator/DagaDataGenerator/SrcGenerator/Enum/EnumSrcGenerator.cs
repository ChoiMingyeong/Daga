using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaDataGenerator.SrcGenerator.Enum;

public class EnumSrcGenerator : ISrcGenerator
{
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

    public bool ToSource()
    {
        List<EnumDeclarationSyntax> declarations = [];
        foreach (var @enum in Enums.Values)
        {
            if (@enum.ToSource() is EnumDeclarationSyntax enumDeclaration)
            {
                declarations.Add(@enumDeclaration);
            }
        }

        var compilationUnit = SyntaxFactory.CompilationUnit()
            .AddMembers(
                SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("MyNamespace"))
                .AddMembers([.. declarations])
            ).NormalizeWhitespace();

        return false;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}