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

    }
}
