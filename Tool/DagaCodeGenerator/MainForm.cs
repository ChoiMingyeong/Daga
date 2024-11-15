using System.Text.RegularExpressions;

namespace DagaCodeGenerator
{
    public partial class MainForm : Form
    {
        private static readonly string _pattern = @"^(?!~\$).*\.(xlsx|csv|xls)$";

        private static readonly Regex _regex = new(_pattern, RegexOptions.IgnoreCase);

        public MainForm()
        {
            InitializeComponent();
        }

        private void srcSearchBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    srcPathTextBox.Text = dialog.SelectedPath;

                    var files = Directory.GetFiles(dialog.SelectedPath)
                        .Where(p => _regex.IsMatch(Path.GetFileName(p)))
                        .ToArray();

                    srcCheckedListBox.Items.Clear();
                    srcCheckedListBox.Items.AddRange(files);
                    for (int i = 0; i < srcCheckedListBox.Items.Count; i++)
                    {
                        srcCheckedListBox.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void outputSearchBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
