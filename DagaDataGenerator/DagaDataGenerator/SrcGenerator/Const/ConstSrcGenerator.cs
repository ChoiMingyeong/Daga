using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaDataGenerator.SrcGenerator.Const;

public class ConstSrcGenerator(string @namespace) : ISrcGenerator
{
    public string Namespace { get; set; } = @namespace;

    public Dictionary<string, IConstant> Constants { get; private set; } = [];

    public bool TryAddEntity(params object?[]? objects)
    {
        IConstant entity;
        try
        {
            entity = new IConstant(objects);
        }
        catch
        {
            return false;
        }

        return Constants.TryAdd(entity.ClassName, entity);
    }

    public bool CreateSource(string filePath, string fileName)
    {
        List<ClassDeclarationSyntax> classDeclarations = [];
        foreach (var (className, constant) in Constants)
        {
            var partialClass = SyntaxFactory.ClassDeclaration(className)
            .AddModifiers(SyntaxFactory.Token(SyntaxFactory.TriviaList(), SyntaxKind.PartialKeyword, SyntaxFactory.TokenList(), SyntaxFactory.Token(SyntaxFactory.TriviaList())))
            .AddMembers(
                SyntaxFactory.MethodDeclaration(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)), "Method1")
                .AddModifiers(SyntaxFactory.Token(SyntaxFactory.SyntaxTriviaList(), SyntaxKind.PublicKeyword, SyntaxFactory.TokenList(), SyntaxFactory.Token(SyntaxFactory.SyntaxTriviaList())))
                .WithBody(SyntaxFactory.Block())
            );
            constant.ToSource();
        }

        // 전체 파일을 만들기 위해 네임스페이스 선언을 포함한 소스 트리 생성
        var compilationUnit = SyntaxFactory.CompilationUnit()
            .AddMembers(SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(Namespace))
                .AddMembers([.. classDeclarations]))
            .NormalizeWhitespace(); 
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