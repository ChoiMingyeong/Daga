using System.Text;

namespace DagaUtility
{
    public interface IAppsScriptPostRequest
    {
        public Encoding Encoding { get; set; }

        public string MediaType { get; set; }

        public StringContent ToStringContent();
    }
}
