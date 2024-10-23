using System.Text;
using System.Text.Json;

namespace DagaDev
{
    public class EnumDataLoader
    {
        private readonly string _url;

        public EnumDataLoader(string url)
        {
            _url = url;
        }

        public async Task<bool> LoadAsync()
        {
            var content = new StringContent("load", Encoding.UTF8, "application/json");
            using HttpClient client = new();
            var response = await client.PostAsync(_url, content);
            if (false == response.IsSuccessStatusCode)
            {
                return false;
            }

            var body = await response.Content.ReadAsStringAsync();
            var enumDataArray = JsonSerializer.Deserialize<EnumData[]>(body);
            if (null == enumDataArray)
            {
                return false;
            }



            return true;
        }
    }
}
