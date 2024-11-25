using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace DagaCodeGenerator.Code;

public abstract class ICode
{
    public required string Namespace { get; init; }

    public required string ClassName { get; init; }

    public required IEnumerable<string[]> ReadLines
    {
        init
        {
            InitDeclarations(value);
        }
    }

    protected NamespaceDeclarationSyntax? _namespaceDeclaration;
    protected ClassDeclarationSyntax? _classDeclaration;

    public abstract bool CreateFile();

    protected abstract void InitDeclarations(in IEnumerable<string[]> readLines);
}
