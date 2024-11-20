using System.Text.RegularExpressions;

namespace DagaCodeGenerator;

public partial class ViewPanelBase : UserControl
{
    protected static readonly string _pattern = @"^(?!.*~\$).*$";
    protected static readonly Regex _regex = new(_pattern, RegexOptions.IgnoreCase);

    public ViewPanelBase()
    {
        InitializeComponent();
    }

    protected virtual void SrcPathSelectBtnClick(object sender, EventArgs e)
    {
        using FolderBrowserDialog dialog = new();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            srcPathTextBox.Text = dialog.SelectedPath;
            if (string.IsNullOrEmpty(outputPathTextBox.Text))
            {
                outputPathTextBox.Text = dialog.SelectedPath;
            }
            var filePaths = Directory.GetFiles(dialog.SelectedPath).Where(IsMyExtension).ToArray();
            checkedListView.AddFilePaths(true, filePaths);
        }
    }

    private bool IsMyExtension(string filePath)
    {
        if (false == _regex.IsMatch(filePath))
        {
            return false;
        }

        string extension = Path.GetExtension(filePath);
        return extension.Equals(".csv", StringComparison.CurrentCultureIgnoreCase) ||
           extension.Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase) ||
           extension.Equals(".xls", StringComparison.CurrentCultureIgnoreCase);
    }

    protected virtual void OutputPathSelectBtnClick(object sender, EventArgs e)
    {
        using FolderBrowserDialog dialog = new();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            outputPathTextBox.Text = dialog.SelectedPath;
        }
    }

    protected virtual void GenBtnClick(object sender, EventArgs e)
    {
        foreach (ListViewItem listViewItem in checkedListView.CheckedItems)
        {
            string filePath = listViewItem.SubItems[1].Text;
            if (false == File.Exists(filePath))
            {
                continue;
            }

            string extension = Path.GetExtension(filePath);

            if (extension.Equals(".csv", StringComparison.CurrentCultureIgnoreCase))
            {
                ReadCSVFile(filePath);
            }
            else if (extension.Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase) ||
                extension.Equals(".xls", StringComparison.CurrentCultureIgnoreCase))
            {
                ReadExcelFile(filePath);
            }
        }
    }

    protected virtual string[] ReadCSVFile(string filePath)
    {

        return [];
    }

    protected virtual string[] ReadExcelFile(string filePath)
    {
        return [];
    }
}
