using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaCodeGenerator.CodeBuilder;

public interface ICodeBuilder : IDisposable
{
    protected NamespaceDeclarationSyntax NamespaceDeclaration { get; init; }

    protected Dictionary<string, ClassDeclarationSyntax> ClassDeclaration { get; init; }

    public void Build();
}
