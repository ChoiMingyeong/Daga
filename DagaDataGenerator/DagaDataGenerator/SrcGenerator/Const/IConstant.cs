using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaDataGenerator.SrcGenerator.Const;

public class IConstant
{
    public string ClassName { get; private set; }

    public List<ConstantEntity> Entities { get; private set; } = [];

    public string? Summary { get; private set; }

    public IConstant(object?[]? objects)
    {
        ArgumentNullException.ThrowIfNull(objects);

        if (objects[0] is not string className || string.IsNullOrWhiteSpace(className))
        {
            throw new InvalidCastException(nameof(objects));
        }

        ClassName = className;

        if (objects.Length > 1 && objects[1] is string summary)
        {
            Summary = summary;
        }
    }

    public ClassDeclarationSyntax ToSource()
    {
        var declaration = SyntaxFactory.ClassDeclaration(ClassName)
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            .AddMembers(Entities.Select(p => p.ToSource()).ToArray()); 
        
        if (false == string.IsNullOrEmpty(Summary))
        {
            declaration = Extensions.AddSummary(declaration, Summary);
        }

        return declaration;
    }
}
