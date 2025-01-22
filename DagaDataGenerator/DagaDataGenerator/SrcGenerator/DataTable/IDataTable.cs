using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaDataGenerator.SrcGenerator.DataTable;

public class IDataTable(string name, string? summary = null, params DataTableProperty[] entities)
    : ISrc<DataTableProperty>(name, summary, entities)
{
    private uint _dataTableIndex = 1;
    public uint DataTableIndex
    {
        get
        {
            return Interlocked.Increment(ref _dataTableIndex);
        }
    }

    public bool TryAddEntities(DataTableProperty property)
    {
        if( Entities.Any(p=> p.Name.Equals(name)))
        {
            return false;
        }

        Entities.Add(property);
        return true;
    }

    public ClassDeclarationSyntax ToSource()
    {
        var declaration = SyntaxFactory.ClassDeclaration(Name)
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            .AddMembers(Entities.Select(p=>p.ToSource()).ToArray());

        return declaration;
    }
}
