using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DagaSourceGenerator
{
    public static class ExcelReader
    {
        private static readonly string _pattern = @"^(?!~\$).*\.(xlsx|csv)$";

        private static readonly Regex _regex = new(_pattern, RegexOptions.IgnoreCase);

        private static bool CanRead(string fileName)
        {
            return _regex.IsMatch(fileName);
        }

        public static string[] GetReadableFilePaths(string folderPath)
        {
            Debug.Assert(Directory.Exists(folderPath));

            return Directory.GetFiles(folderPath).Where(p=>CanRead(Path.GetFileName(p))).ToArray();
        }


    }
}
