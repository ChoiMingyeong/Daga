using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Diagnostics;
using System.Text;

namespace DagaCodeGenerator.Code;

public class DataTableCode : ICode
{
    public override bool CreateFile()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        Debug.Assert(null != _namespaceDeclaration);
        return _namespaceDeclaration.NormalizeWhitespace().ToFullString();
    }

    protected override void InitDeclarations(in IEnumerable<string[]> readLines)
    {
    }
}