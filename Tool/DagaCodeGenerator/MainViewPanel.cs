using System.Text.RegularExpressions;

namespace DagaCodeGenerator;

public partial class ViewPanelBase : UserControl
{
    protected static readonly string _pattern = @"^(?!.*\\~\$).*\.((xlsx)|(csv)|(xls))$";
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
            var filePaths = Directory.GetFiles(dialog.SelectedPath).Where(p => _regex.IsMatch(p)).ToArray();
            checkedListView.AddFilePaths(true, filePaths);
        }
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
