using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DagaDev
{
    public class DataTableManager
    {
        private readonly HttpClient _httpClient = new();
        private readonly string _url;

        public DataTableManager(string url)
        {
            _url = url;
        }

        public async Task GetDataTablesAsync()
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(_url, content);
        }


    }
}
