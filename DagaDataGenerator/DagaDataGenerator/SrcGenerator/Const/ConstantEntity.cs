using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;

namespace DagaDataGenerator.SrcGenerator.Const;

public class ConstantEntity : IEntity
{
    public string Name { get; private set; }

    public string TypeName { get; set; }

    public string Value { get; set; }

    public string? Comment { get; set; }

    public ConstantEntity(object?[]? objects)
    {
        ArgumentNullException.ThrowIfNull(objects);

        if (objects[0] is not string name || string.IsNullOrWhiteSpace(name) ||
            objects[1] is not string typeName || string.IsNullOrWhiteSpace(typeName) ||
            objects[2] is not string value)
        {
            throw new InvalidCastException(nameof(objects));
        }

        Name = name;
        TypeName = typeName;
        Value = value;

        if (SyntaxFactory.ParseTypeName(TypeName) is TypeSyntax type)
        {
            if("string" == type.ToFullString())
            {
                Value = $"\"{value}\"";
            }
        }

        if (objects.Length == 4 && objects[3] is string comment)
        {
            Comment = comment;
        }
    }

    public FieldDeclarationSyntax ToSource()
    {
        var declaration = SyntaxFactory.FieldDeclaration(
            SyntaxFactory.VariableDeclaration(
                Extensions.GetTypeSyntax(TypeName))
            .AddVariables(
                SyntaxFactory.VariableDeclarator(Name)
                .WithInitializer(
                    SyntaxFactory.EqualsValueClause(
                        SyntaxFactory.ParseExpression(Value)))))
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.ConstKeyword));

        if (false == string.IsNullOrWhiteSpace(Comment))
        {
            declaration = Extensions.AddLeadingComment(ref declaration, Comment);
        }

        return declaration;
    }
}
