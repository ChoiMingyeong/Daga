using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaDataGenerator.SrcGenerator.Enum;

public class EnumEntity : IEntity
{
    public string Name { get; set; }

    public double? Value { get; set; }

    public string? Comment { get; set; }

    public EnumEntity(string name, double? value = null, string? comment = null)
    {
        Name = name;
        Value = value;
        Comment = comment;
    }

    public EnumMemberDeclarationSyntax ToSource()
    {
        var memberDeclaration = SyntaxFactory.EnumMemberDeclaration(Name);
        if (null != Value)
        {
            memberDeclaration = memberDeclaration
                .WithEqualsValue(SyntaxFactory.EqualsValueClause(
                    SyntaxFactory.LiteralExpression(
                        SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(Value.Value))));
        }
        if(false == string.IsNullOrEmpty(Comment))
        {
            memberDeclaration = Extensions.AddLeadingComment(ref memberDeclaration, Comment);
        }
        return memberDeclaration;
    }
}