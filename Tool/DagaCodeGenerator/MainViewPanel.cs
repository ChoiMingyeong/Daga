using DagaCodeGenerator.CodeBuilder;
using DagaCodeGenerator.FileReader;
using System.Text.RegularExpressions;

namespace DagaCodeGenerator;

public partial class ViewPanelBase : UserControl
{
    protected static readonly string _pattern = @"^(?!.*~\$).*$";
    protected static readonly Regex _regex = new(_pattern, RegexOptions.IgnoreCase);

    protected virtual CodeBuilderType _codeBuilderType { get; init; } = CodeBuilderType.None;

    public ViewPanelBase()
    {
        // ExcelDataReader 초기화
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

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

            IEnumerable<string[]>? readLines;
            using (IFileReader? reader = FileReaderFactory.Create(filePath))
            {
                readLines = reader?.ReadLines(filePath);
            }

            if (null == readLines || false == readLines.Any())
            {
                continue;
            }

            using (ICodeBuilder? builder = CodeBuilderFactory.Create(_codeBuilderType, Path.GetFileNameWithoutExtension(filePath), readLines))
            {
                builder.Build();
            }
        }
    }
}
