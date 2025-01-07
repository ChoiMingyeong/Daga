using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaDataGenerator.SrcGenerator.Enum;

public class IEnum
{
    public string Name { get; private set; }

    public List<EnumEntity> Entities { get; private set; } = [];

    public string? Summary { get; private set; }

    public IEnum(object?[]? objects)
    {
        ArgumentNullException.ThrowIfNull(objects);

        if (objects[0] is not string name || string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidCastException(nameof(objects));
        }

        Name = name;

        if (objects.Length > 1 && objects[1] is string summary)
        {
            Summary = summary;
        }
    }

    public bool TryAddEntity(EnumEntity entity)
    {
        if (Entities.Any(p => p.Name.Equals(entity.Name)))
        {
            return false;
        }

        Entities.Add(entity);

        return true;
    }

    public EnumDeclarationSyntax ToSource()
    {
        var declaration = SyntaxFactory.EnumDeclaration(Name)
          .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword)) // public 접근 제한자
          .AddMembers(Entities.Select(p => p.ToSource()).ToArray());

        if(false == string.IsNullOrEmpty(Summary))
        {
            declaration = declaration.WithLeadingTrivia(CreateSummaryComment(Summary));
        }

        return declaration;
    }
    static SyntaxTriviaList CreateSummaryComment(string summaryText)
    {
        return SyntaxFactory.TriviaList(
            SyntaxFactory.Trivia(
                SyntaxFactory.DocumentationCommentTrivia(SyntaxKind.SingleLineDocumentationCommentTrivia)
                    .WithContent(SyntaxFactory.List(new XmlNodeSyntax[]
                    {
                        SyntaxFactory.XmlText("/// "),
                        SyntaxFactory.XmlElement(
                            SyntaxFactory.XmlElementStartTag(SyntaxFactory.XmlName("summary")),
                            SyntaxFactory.XmlElementEndTag(SyntaxFactory.XmlName("summary"))
                        ).WithContent(
                             SyntaxFactory.List<XmlNodeSyntax>(
                            [
                                SyntaxFactory.XmlText("\n"),
                                SyntaxFactory.XmlText($"\t/// {summaryText}\n"),
                                SyntaxFactory.XmlText("\t/// ")
                            ])
                        ),
                        SyntaxFactory.XmlText("\n\t")
                    }))
            )
        );
    }
}
