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
           
        }

        private void outputSearchBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
