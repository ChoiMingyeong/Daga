using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DagaDataGenerator.SrcGenerator.Enum;

public class IEnum : ISrc<EnumEntity>
{
    public BaseListSyntax? BaseType { get; set; }

    public IEnum(string name, string? summary = null, string? typeName = null, params EnumEntity[] entities)
        : base(name, summary, entities)
    {
        if (false == string.IsNullOrEmpty(typeName) &&
            Extensions.GetTypeSyntax(typeName) is TypeSyntax typeSyntax &&
            typeSyntax.IsNotNull)
        {
            BaseType = Extensions.CreateBaseListSyntax(typeSyntax);
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
          .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
          .AddMembers(Entities.Select(p => p.ToSource()).ToArray());

        if(null != BaseType)
        {
            declaration = declaration.WithBaseList(BaseType);
        }

        if (false == string.IsNullOrEmpty(Summary))
        {
            declaration = Extensions.AddSummary(ref declaration, Summary);
        }

        return declaration;
    }
}
