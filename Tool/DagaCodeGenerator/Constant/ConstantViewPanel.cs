using System.Configuration;

namespace DagaCodeGenerator;

public partial class ConstantViewPanel : ViewPanelBase
{
    protected override CodeBuilderType _codeBuilderType { get; init; } = CodeBuilderType.Constant;

    public ConstantViewPanel()
    {
        InitializeComponent();
    }

}
