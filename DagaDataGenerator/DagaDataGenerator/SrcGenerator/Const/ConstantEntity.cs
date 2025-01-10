using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace DagaDataGenerator.SrcGenerator.Const;

public class ConstantEntity
{
    public string Name { get; private set; }

    public Type Type { get; set; }

    public string Value { get; set; }

    public string? Comment { get; set; }

    public ConstantEntity(object?[]? objects)
    {
        ArgumentNullException.ThrowIfNull(objects);

        if (objects[0] is not string name || string.IsNullOrWhiteSpace(name) ||
            objects[1] is not Type type || null == type.FullName ||
            objects[2] is not string value)
        {
            throw new InvalidCastException(nameof(objects));
        }

        Name = name;
        Type = type;
        Value = value;

        if (objects.Length > 4 && objects[3] is string comment)
        {
            Comment = comment;
        }
    }

    public FieldDeclarationSyntax ToSource()
    {
        var declaration = SyntaxFactory.FieldDeclaration(
            SyntaxFactory.VariableDeclaration(
                SyntaxFactory.ParseTypeName(Type.FullName!))
            .AddVariables(
                SyntaxFactory.VariableDeclarator(Name)
                .WithInitializer(
                    SyntaxFactory.EqualsValueClause(
                        SyntaxFactory.ParseExpression(Value)))))
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.ConstKeyword));

        if (false == string.IsNullOrWhiteSpace(Comment))
        {
            declaration = Extensions.AddLeadingComment(declaration, Comment);
        }

        return declaration;
    }
}
