namespace DagaCodeGenerator;

public partial class EnumViewPanel : ViewPanelBase
{
    protected override CodeBuilderType _codeBuilderType { get; init; } = CodeBuilderType.Enum;

    public EnumViewPanel()
    {
        InitializeComponent();
    }
}
