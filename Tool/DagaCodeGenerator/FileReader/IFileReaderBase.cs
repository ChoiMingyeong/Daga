namespace DagaCodeGenerator.FileReader
{
    public interface IFileReaderBase : IDisposable
    {
        public IEnumerable<string[]>? ReadLines(string filePath); 
    }
}