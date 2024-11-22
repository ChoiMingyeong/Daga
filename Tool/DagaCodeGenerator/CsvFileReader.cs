namespace DagaCodeGenerator
{
    public class CsvFileReader : IFileReaderBase
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}