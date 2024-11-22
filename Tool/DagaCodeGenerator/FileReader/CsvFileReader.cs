namespace DagaCodeGenerator.FileReader
{
    public class CsvFileReader : IFileReaderBase
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}