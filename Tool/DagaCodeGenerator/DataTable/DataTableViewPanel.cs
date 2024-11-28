namespace DagaCodeGenerator;

public partial class DataTableViewPanel : ViewPanelBase
{
    protected override CodeBuilderType _codeBuilderType { get; init; } = CodeBuilderType.DataTable;

    public DataTableViewPanel()
    {
        InitializeComponent();
    }

}
