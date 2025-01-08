using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace DagaDataGenerator.SrcGenerator;

public class SrcGeneratorFactory
{
    public static SyntaxTriviaList CreateSummaryComment(string summaryText)
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
                                SyntaxFactory.XmlText($"\n\t///{summaryText}\n\t///")
                            ])
                        ),
                        SyntaxFactory.XmlText("\n\t")
                    }))
            )
        );
    }
}