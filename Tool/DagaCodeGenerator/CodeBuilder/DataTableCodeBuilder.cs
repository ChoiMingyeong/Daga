using DagaCodeGenerator.Code;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaCodeGenerator.CodeBuilder
{
    public class DataTableCodeBuilder : ICodeBuilder
    {
        public DataTableCodeBuilder(IEnumerable<string[]> readLines)
        {
        }

        NamespaceDeclarationSyntax ICodeBuilder.NamespaceDeclaration { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        Dictionary<string, ClassDeclarationSyntax> ICodeBuilder.ClassDeclaration { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        public void Build()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        void ICodeBuilder.Build()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}