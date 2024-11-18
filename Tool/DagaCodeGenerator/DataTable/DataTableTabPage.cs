namespace DagaCodeGenerator;

public partial class DataTableTabPage : TabPage
{
    public DataTableTabPage()
    {
        Name = "dataTablePage";
        Text = "DataTable";
        UseVisualStyleBackColor = true;
        Controls.Add(new DataTableViewPanel()
        {
            Dock = DockStyle.Fill,
        });

        InitializeComponent();
    }
}
