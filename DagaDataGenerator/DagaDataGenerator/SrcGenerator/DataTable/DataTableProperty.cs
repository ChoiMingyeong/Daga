using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaDataGenerator.SrcGenerator.DataTable
{
    public class DataTableProperty : IEntity
    {
        public required string TypeName { get; set; }

        public required string Name { get; set; }

        public string? Comment { get; set; }

        public DataTableProperty()
        {
        }

        public PropertyDeclarationSyntax ToSource()
        {
            var declaration = SyntaxFactory.PropertyDeclaration();

            return declaration;
        }
    }
}