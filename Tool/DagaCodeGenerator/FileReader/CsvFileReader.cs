
namespace DagaCodeGenerator.FileReader
{
    public class CsvFileReader : IFileReader
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<string[]>? ReadLines(string filePath)
        {
            using StreamReader reader = new(filePath);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line.Split(',');
            }
        }
    }
}