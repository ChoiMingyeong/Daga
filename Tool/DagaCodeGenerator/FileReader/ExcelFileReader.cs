namespace DagaCodeGenerator.FileReader
{
    public class ExcelFileReader : IFileReaderBase
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}