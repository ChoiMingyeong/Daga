using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Diagnostics;
using System.Text;

namespace DagaCodeGenerator.Code;

public class ConstantCode : ICode
{
    public override bool CreateFile()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        Debug.Assert(null != _namespaceDeclaration);
        return _namespaceDeclaration.NormalizeWhitespace().ToFullString();
    }

    protected override void InitDeclarations(in IEnumerable<string[]> readLines)
    {
        _namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(Program.DefaultNamespace))
            .WithNamespaceKeyword(SyntaxFactory.Token(SyntaxKind.NamespaceKeyword))
            .NormalizeWhitespace();

        _classDeclaration = SyntaxFactory.ClassDeclaration(ClassName)
            .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword)))
            .NormalizeWhitespace();

        _namespaceDeclaration = _namespaceDeclaration.AddMembers(_classDeclaration);
    }
}
