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

        ushort index = 0;
        if (objects[index++] is not string className
            || string.IsNullOrWhiteSpace(className))
        {
            throw new InvalidCastException(nameof(objects));
        }
        else
        {
            ClassName = className;
        }

        while (objects.Length > index)
        {
            if (objects[index] is ConstantEntity entity)
            {
                Entities.Add(entity);
            }
            else if ( objects[index] is string summary)
            {
                Summary = summary;
                break;
            }

            ++index;
        }
    }


    public ClassDeclarationSyntax ToSource()
    {
        var declaration = SyntaxFactory.ClassDeclaration(ClassName)
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PartialKeyword), SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            .AddMembers(Entities.Select(p => p.ToSource()).ToArray());

        if (false == string.IsNullOrEmpty(Summary))
        {
            declaration = Extensions.AddSummary(declaration, Summary);
        }

        return declaration;
    }
}
