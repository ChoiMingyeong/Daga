using System.Reflection;

namespace DagaDev
{



    internal class Program
    {
        static void Main(string[] args)
        {
            TypeMapper.Instance.ToString();
            var type = TypeMapper.Instance["string"];
            var type2 = TypeMapper.Instance["System.String"];
            var typeName = TypeMapper.Instance[typeof(string)];
            var assembly = Assembly.GetExecutingAssembly().GetTypes()
                                        .Select(t => t.Namespace)
                                        .FirstOrDefault(ns => !string.IsNullOrEmpty(ns)); ;

            var a = Type.GetType("EnumA");
            var a2 = typeof(EnumA);
            Console.WriteLine(DagaDev.Constant.A);
            //string url = "https://script.google.com/macros/s/AKfycbxVBoEEgN7E11tNwN3t_zKSrxULh6zo60hLoQ_oM5cK6waOFUhOwTKES8Ad4Co4si5l7g/exec";
            //AccountData accountData = new AccountData()
            //{
            //    action = ActionType.Register,
            //    id = "test1",
            //    pwd = "1111",
            //    nickname = "tttt",
            //};
            //HttpClient httpClient = new();
            //var content = new StringContent(JsonSerializer.Serialize(accountData), Encoding.UTF8, "application/json");

            //try
            //{
            //    var response = await httpClient.PostAsync(url, content);
            //    response.EnsureSuccessStatusCode(); // 응답 코드가 성공(200~299) 범위인지 확인

            //    var responseBody = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine($"서버 응답: {responseBody}");
            //}
            //catch (HttpRequestException e)
            //{
            //    Console.WriteLine($"요청 오류: {e.Message}");
            //}
            // Console.WriteLine(GeneratedEnum.Apple); 
        }
    }
}
