using DagaCodeGenerator.FileReader;
using ExcelDataReader;
using System.Text.RegularExpressions;

namespace DagaCodeGenerator;

public partial class ViewPanelBase : UserControl
{
    protected static readonly string _pattern = @"^(?!.*~\$).*$";
    protected static readonly Regex _regex = new(_pattern, RegexOptions.IgnoreCase);

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
            using (IFileReaderBase? reader = FileReaderFactory.Create(filePath))
            {
                readLines = reader?.ReadLines(filePath);
            }


            if (null == readLines || false == readLines.Any())
            {
                continue;
            }
        }
    }

    protected virtual IEnumerable<string[]> ReadCsvLines(string filePath)
    {
        using StreamReader reader = new(filePath);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            yield return line.Split(',');
        }
    }

    protected virtual IEnumerable<string[]> ReadExcelLines(string filePath)
    {
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        using (var reader = ExcelReaderFactory.CreateReader(stream))
        {
            do
            {
                while (reader.Read()) // 현재 워크시트의 행을 한 줄씩 읽음
                {
                    var row = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader.GetValue(i)?.ToString() ?? string.Empty; // 각 셀의 값을 읽음
                    }
                    yield return row;
                }
            } while (reader.NextResult()); // 다음 워크시트로 이동
        }
    }
}
