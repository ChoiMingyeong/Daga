namespace DagaCodeGenerator.FileReader
{
    public interface IFileReader : IDisposable
    {
        public IEnumerable<string[]>? ReadLines(string filePath); 
    }
}