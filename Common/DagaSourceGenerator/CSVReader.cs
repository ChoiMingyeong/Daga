using System.Diagnostics;

namespace DagaSourceGenerator
{
    public static class CSVReader
    {
        public static List<List<string>> CSVSeperator(string filePath)
        {
            Debug.Assert(false == string.IsNullOrEmpty(filePath));
            Debug.Assert(Directory.Exists(filePath));

            List<List<string>> result = [];

            return result;
        }
    }
}
