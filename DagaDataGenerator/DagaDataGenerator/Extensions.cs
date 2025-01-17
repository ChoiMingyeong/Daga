using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace DagaDataGenerator
{
    internal static class Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static SyntaxTrivia CreateComment(string comment)
        {
            return SyntaxFactory.Comment($"// {comment}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
                                SyntaxFactory.XmlText($"\n\t/// "),
                                SyntaxFactory.XmlText($"{summary}\n\t///"),
                            ])
                        ),
                        SyntaxFactory.XmlText("\n\t")
                        }))
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T AddLeadingComment<T>(ref T memberDeclaration, string comment) where T : MemberDeclarationSyntax
        {
            return memberDeclaration.WithLeadingTrivia(CreateComment(comment));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T AddTrailingComment<T>(T memberDeclaration, string comment) where T : MemberDeclarationSyntax
        {
            return memberDeclaration.WithTrailingTrivia(CreateComment(comment));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T AddSummary<T>(ref T memberDeclaration, string summary) where T : MemberDeclarationSyntax
        {
            return memberDeclaration.WithLeadingTrivia(CreateSummary(summary));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static NamespaceDeclarationSyntax CreateNamespace(string @namespace)
        {
            return SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(@namespace));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TypeSyntax GetTypeSyntax(string typeName)
        {
            return SyntaxFactory.ParseTypeName(typeName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static BaseListSyntax CreateBaseListSyntax(TypeSyntax typeSyntax)
        {
            return SyntaxFactory.BaseList(SyntaxFactory.SingletonSeparatedList<BaseTypeSyntax>(SyntaxFactory.SimpleBaseType(typeSyntax)));
        }
    }
}
