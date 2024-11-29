using DagaCodeGenerator.Code;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection;

namespace DagaCodeGenerator.CodeBuilder
{
    public class ConstantCodeBuilder : ICodeBuilder
    {
        NamespaceDeclarationSyntax ICodeBuilder.NamespaceDeclaration { get; init; } = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(Program.DefaultNamespace))
                .WithNamespaceKeyword(SyntaxFactory.Token(SyntaxKind.NamespaceKeyword));
        Dictionary<string, ClassDeclarationSyntax> ICodeBuilder.ClassDeclaration { get; init; } = [];

        public ConstantCodeBuilder(string fileName, IEnumerable<string[]> readLines)
        {
            var namespaceDeclarartion = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(Program.DefaultNamespace))
                .WithNamespaceKeyword(SyntaxFactory.Token(SyntaxKind.NamespaceKeyword));

            var classDeclaration = SyntaxFactory.ClassDeclaration(fileName)
                .WithModifiers(SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                    SyntaxFactory.Token(SyntaxKind.StaticKeyword)));

            foreach (var readLine in readLines)
            {
                // 헤더 제거
                if (readLines.First() == readLine)
                {
                    if(readLines.Count() != 4)
                    {
                        throw new FormatException();
                    }

                    continue;
                }

                var fieldDeclaration = SyntaxFactory.FieldDeclaration(
                    SyntaxFactory.VariableDeclaration(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.IntKeyword)))
                        .AddVariables(SyntaxFactory.VariableDeclarator(readLine[0])
                            .WithInitializer(SyntaxFactory.EqualsValueClause(
                                SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(50))))))
                .WithModifiers(SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                    SyntaxFactory.Token(SyntaxKind.StaticKeyword),
                    SyntaxFactory.Token(SyntaxKind.ConstKeyword)));

                if (false == string.IsNullOrEmpty(readLine[3]))
                {
                    fieldDeclaration = fieldDeclaration.WithLeadingTrivia(SyntaxFactory.TriviaList(SyntaxFactory.Comment($"// {readLine[3]}")));
                }

                classDeclaration = classDeclaration.AddMembers(fieldDeclaration);
            }

            namespaceDeclarartion = namespaceDeclarartion.AddMembers(classDeclaration);
            var str = namespaceDeclarartion.NormalizeWhitespace().ToFullString();
        }
        public void Build()
        {
            throw new NotImplementedException();
        }


        //public ICode Build()
        //{

        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}