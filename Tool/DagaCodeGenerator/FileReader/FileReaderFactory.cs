namespace DagaCodeGenerator.FileReader
{
    public static class FileReaderFactory
    {
        public static IFileReader? Create(string filePath)
        {
            if (false == File.Exists(filePath))
            {
                return null;
            }
            
            string extension = Path.GetExtension(filePath);
            return extension switch
            {
                ".csv" => new CsvFileReader(),
                ".xlsx" or ".xls" => new ExcelFileReader(),
                _ => null,
            };
        }
    }
}