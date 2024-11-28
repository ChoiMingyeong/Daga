using ExcelDataReader;

namespace DagaCodeGenerator.FileReader
{
    public class ExcelFileReader : IFileReader
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<string[]>? ReadLines(string filePath)
        {
            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);

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

            stream.Close();
        }
    }
}