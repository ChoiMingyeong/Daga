using System.Text;

namespace DagaUtility
{
    public class TestPostRequest<T> : IAppsScriptPostRequest
    {
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public string MediaType { get; set; } = "application/json";

        public StringContent ToStringContent()
        {
            string content = string.Empty;
            return new StringContent(content, Encoding, MediaType);
        }
    }
}
