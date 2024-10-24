using System.Text;

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

        public async Task<string> PostAsync(string content)
        {
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_url, stringContent);
            if (false == response.IsSuccessStatusCode)
            {
                return string.Empty;
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
