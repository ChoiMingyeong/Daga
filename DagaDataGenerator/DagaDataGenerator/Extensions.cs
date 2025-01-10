using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaDataGenerator
{
    internal static class Extensions
    {
        internal static SyntaxTrivia CreateComment(string comment)
        {
            return SyntaxFactory.Comment($"// {comment}");
        }

        internal static SyntaxTriviaList CreateSummary(string summary)
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
                                SyntaxFactory.XmlText($"\n\t///{summary}\n\t///")
                            ])
                        ),
                        SyntaxFactory.XmlText("\n\t")
                        }))
                )
            );
        }

        internal static T AddLeadingComment<T>(T memberDeclaration, string comment) where T : MemberDeclarationSyntax
        {
            return memberDeclaration.WithLeadingTrivia(CreateComment(comment));
        }

        internal static T AddTrailingComment<T>(T memberDeclaration, string comment) where T : MemberDeclarationSyntax
        {
            return memberDeclaration.WithTrailingTrivia(CreateComment(comment));
        }

        internal static T AddSummary<T>(T memberDeclaration, string summary) where T : MemberDeclarationSyntax
        {
            return memberDeclaration.WithLeadingTrivia(CreateSummary(summary));
        }
    }
}
