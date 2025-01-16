using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaDataGenerator.SrcGenerator.Const;

public class ConstSrcGenerator(string @namespace) : ISrcGenerator
{
    public string Namespace { get; set; } = @namespace;

    public Dictionary<string, IConstant> Constants { get; private set; } = [];

    public IConstant? this[string enumName]
    {
        get
        {
            if (false == Constants.TryGetValue(enumName, out var @enum))
            {
                return null;
            }

            return @enum;
        }
    }

    public bool TryAddEntity(string name, string? summary = null, params ConstantEntity[] entities)
    {
        IConstant entity;
        try
        {
            entity = new IConstant(name, summary, entities);
        }
        catch
        {
            return false;
        }

        return Constants.TryAdd(entity.Name, entity);
    }

    public bool CreateSource(params string[] strs)
    {
        if (strs.Length <= 1 ||
            strs[0] is not string filePath)
        {
            return false;
        }

        if (false == Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        List<ClassDeclarationSyntax> classDeclarations = [];
        foreach (var (className, constant) in Constants)
        {
            classDeclarations.Add(constant.ToSource());
            var compilationUnit = SyntaxFactory.CompilationUnit()
                .AddMembers(Extensions.CreateNamespace(Namespace).AddMembers([.. classDeclarations]));
            var sourceCode = compilationUnit.NormalizeWhitespace(elasticTrivia: true).ToFullString();

            try
            {
                File.WriteAllText(Path.Combine(filePath, $"{className}.cs"), sourceCode);
            }
            catch
            {
                return false;
            }
        }

        return true;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}