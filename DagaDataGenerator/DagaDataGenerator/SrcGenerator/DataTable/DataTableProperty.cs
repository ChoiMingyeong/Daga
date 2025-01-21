using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaDataGenerator.SrcGenerator.DataTable
{
    public class DataTableProperty : IEntity
    {
        public readonly uint Index;

        public required string TypeName { get; set; }

        public required string Name { get; set; }

        public string? Comment { get; set; }

        public DataTableProperty(uint index)
        {
            Index = index;
        }
    }
}