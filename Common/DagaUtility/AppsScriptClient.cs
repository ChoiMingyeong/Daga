namespace DagaUtility
{
    public class AppsScriptClient(string url) : IDisposable
    {
        private readonly string _url = url;
        private readonly HttpClient _httpClient = new();

        public void Dispose()
        {
            _httpClient.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<bool> PostAsync(HttpContent content)
        {
            await _httpClient.PostAsync(_url, content);

            return true;
        }
    }
}
