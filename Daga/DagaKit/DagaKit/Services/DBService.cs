namespace DagaKit.Services
{
    public partial class DBService
    {
        private readonly HttpClient _httpClient;

        public DBService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
