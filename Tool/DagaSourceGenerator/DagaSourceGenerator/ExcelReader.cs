using ExcelDataReader;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DagaSourceGenerator
{
    public static class ExcelReader
    {
        static ExcelReader()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        private static readonly string _pattern = @"^(?!~\$).*\.(xlsx|csv|xls)$";

        private static readonly Regex _regex = new(_pattern, RegexOptions.IgnoreCase);

        private static bool CanRead(string fileName)
        {
            return _regex.IsMatch(fileName);
        }

        public static string[] GetReadableFilePaths(string folderPath)
        {
            Debug.Assert(Directory.Exists(folderPath));

            return Directory.GetFiles(folderPath).Where(p => CanRead(Path.GetFileName(p))).ToArray();
        }

        public static void ReadFiles(string folderPath)
        {
            var filePaths = GetReadableFilePaths(folderPath);
            foreach (var filePath in filePaths)
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            while (reader.Read())
                            {
                                for (int column = 0; column < reader.FieldCount; column++)
                                {
                                    Console.Write($"{reader.GetValue(column)},");
                                }
                                Console.WriteLine();
                            }
                        } while (reader.NextResult());
                    }
                }
            }
        }
    }
}
