using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaDataGenerator.SrcGenerator.Const;

public class IConstant(string name, string? summary = null, params ConstantEntity[] entities) 
    : ISrc<ConstantEntity>(name, summary, entities)
{
    public ClassDeclarationSyntax ToSource()
    {
        var declaration = SyntaxFactory.ClassDeclaration(Name)
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.PartialKeyword))
            .AddMembers(Entities.Select(p => p.ToSource()).ToArray());

        if (false == string.IsNullOrEmpty(Summary))
        {
            declaration = Extensions.AddSummary(ref declaration, Summary);
        }

        return declaration;
    }
}
