using DagaCodeGenerator.Code;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;

namespace DagaCodeGenerator.CodeBuilder
{
    public class ConstantCodeBuilder : ICodeBuilder
    {
        public ConstantCodeBuilder(string fileName, IEnumerable<string[]> readLines)
        {
            foreach (var readLine in readLines)
            {
                if(readLines.First() == readLine)
                {
                    continue;
                }

                var namespaceDeclarartion = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(Program.DefaultNamespace))
                    .WithNamespaceKeyword(SyntaxFactory.Token(SyntaxKind.NamespaceKeyword));

                var classDeclaration = SyntaxFactory.ClassDeclaration(fileName)
                    .WithModifiers(SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                        SyntaxFactory.Token(SyntaxKind.StaticKeyword)));

                var fieldDeclaration = SyntaxFactory.FieldDeclaration(
                    SyntaxFactory.VariableDeclaration(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.IntKeyword)))
                        .AddVariables(SyntaxFactory.VariableDeclarator(readLine[0])
                            .WithInitializer(SyntaxFactory.EqualsValueClause(
                                SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(50))))))
                .WithModifiers(SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                    SyntaxFactory.Token(SyntaxKind.StaticKeyword),
                    SyntaxFactory.Token(SyntaxKind.ConstKeyword)))
                // Adding comment as leading trivia
                .WithLeadingTrivia(SyntaxFactory.TriviaList(
                    SyntaxFactory.Comment($"// {readLine[3]}")));

                classDeclaration = classDeclaration.AddMembers(fieldDeclaration);
                namespaceDeclarartion = namespaceDeclarartion.AddMembers(classDeclaration);

                var str = namespaceDeclarartion.NormalizeWhitespace().ToFullString();
            }
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