using DagaSourceGenerator;
using System.Security.Cryptography.X509Certificates;

namespace DagaDev
{
    public class TestLock
    {
        private static int _uid = 0;

        private static int Uid { get => Interlocked.Increment(ref _uid); }

        public readonly int Id = Uid;

        public readonly object Lock = new();

        public static void TestLockFunc(TestLock testLock1, TestLock testLock2)
        {
            var (firstLock, secondLock) = testLock1.Id < testLock2.Id ?
                (testLock1, testLock2) : (testLock2, testLock1);


            lock (firstLock)
            {
                lock (secondLock)
                {
                    Thread.Sleep(100);
                }
            }
        }

        private static readonly object _lock = new();
        public static void TestNormalFunc(TestLock testLock1, TestLock testLock2)
        {
            lock (_lock)
            {
                Thread.Sleep(100);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 개별 lock Test
            List<TestLock> testLocks = [];
            int count = 100000;
            for (int i = 0; i < count; i++)
            {
                testLocks.Add(new TestLock());
            }

            Random random = new Random();
            TimeSpan lockTime = TimeSpan.Zero;
            Parallel.For(0, 1000, (i, CancellationToken) =>
            {
                int l1 = random.Next(0, count);
                int l2;
                do
                {
                    l2 = random.Next(0, count);
                } while (l1 == l2);

                DateTime start = DateTime.Now;
                //Console.WriteLine($"[{testLocks[l1].Id}, {testLocks[l2].Id}] Selected.");
                TestLock.TestLockFunc(testLocks[l1], testLocks[l2]);
                lockTime += DateTime.Now.Subtract(start);
                //Console.WriteLine($"[{testLocks[l1].Id}, {testLocks[l2].Id}] Completed! Time: {DateTime.Now - start}");
            });

            TimeSpan normalTime = TimeSpan.Zero;
            for (int i = 0; i < 1000; i++)
            {
                int l1 = random.Next(0, count);
                int l2;
                do
                {
                    l2 = random.Next(0, count);
                } while (l1 == l2);

                DateTime start = DateTime.Now;
                //Console.WriteLine($"[{testLocks[l1].Id}, {testLocks[l2].Id}] Selected.");
                TestLock.TestNormalFunc(testLocks[l1], testLocks[l2]);
                normalTime += DateTime.Now.Subtract(start);
                //Console.WriteLine($"[{testLocks[l1].Id}, {testLocks[l2].Id}] Completed! Time: {DateTime.Now - start}");
            }

            Console.WriteLine(lockTime);
            Console.WriteLine(normalTime);

            //List<ConstantSheetLine> constantSheetLines = [];
            //constantSheetLines.Add(new ConstantSheetLine()
            //{
            //    Name = "constant_string",
            //    Type = "string",
            //    Value = "test_token",
            //});

            //constantSheetLines.Add(new ConstantSheetLine()
            //{
            //    Name = "constant_int",
            //    Type = "int",
            //    Value = "1000",
            //});

            //constantSheetLines.Add(new ConstantSheetLine()
            //{
            //    Name = "constant_float",
            //    Type = "int",
            //    Value = "10.83",
            //});

            //constantSheetLines.Add(new ConstantSheetLine()
            //{
            //    Name = "constant_byte",
            //    Type = "byte",
            //    Value = "155",
            //});

            //ConstantSheet constantSheet = new("TestConstant.Constant")
            //{
            //    Values = constantSheetLines,
            //};

            //Console.WriteLine(constantSheet);

            //List<EnumSheetLine> enumSheetLines = [];
            //enumSheetLines.Add(new EnumSheetLine()
            //{
            //    Name = "None",
            //    Value = "0",
            //});
            //enumSheetLines.Add(new EnumSheetLine()
            //{
            //    Name = "One",
            //});
            //enumSheetLines.Add(new EnumSheetLine()
            //{
            //    Name = "Two",
            //});
            //enumSheetLines.Add(new EnumSheetLine()
            //{
            //    Name = "Four",
            //    Value = "4",
            //});

            //EnumSheet enumSheet = new()
            //{
            //    Name = "TestEnum",
            //    Type = "byte",
            //    Values = enumSheetLines,
            //};

            //Console.WriteLine(enumSheet);

            //    string code = @"
            //using System;

            //public class HelloWorld        {
            //    public void SayHello()            {
            //        Console.WriteLine(""Hello, World!"");            }
            //}";

            //    // 코드 문자열을 구문 트리로 변환
            //    var syntaxTree = CSharpSyntaxTree.ParseText(code);

            //    // 구문 트리의 루트 노드 가져오기
            //    var root = syntaxTree.GetRoot();

            //    // 루트 노드 출력
            //    Console.WriteLine(root.ToString());

            //TypeMapper.Instance.ToString();
            //var type = TypeMapper.Instance["string"];
            //var type2 = TypeMapper.Instance["System.String"];
            //var typeName = TypeMapper.Instance[typeof(string)];
            //var assembly = Assembly.GetExecutingAssembly().GetTypes()
            //                            .Select(t => t.Namespace)
            //                            .FirstOrDefault(ns => !string.IsNullOrEmpty(ns)); ;

            //var a = Type.GetType("EnumA");

            //ConstantSourceGenerator srcGen = new();
            //var dataList = new List<ConstantData>
            //{
            //    new()
            //    {
            //        ClassName = "Constant",
            //        Type = "int",
            //        Name = "MAX_COUNT",
            //        Value = "500",
            //    },
            //    new()
            //    {
            //        ClassName = "Constant",
            //        Type = "double",
            //        Name = "TEST_COUNT",
            //        Value = "100.83",
            //    },
            //    new()
            //    {
            //        ClassName = "Constant",
            //        Type = "ushort",
            //        Name = "SUCCESS",
            //        Value = "0",
            //    },
            //    new()
            //    {
            //        ClassName = "Constant",
            //        Type = "ushort",
            //        Name = "FAIL",
            //        Value = "1",
            //    },
            //    new()
            //    {
            //        ClassName = "Constant",
            //        Type = "ushort",
            //        Name = "FAIL",
            //        Value = "1",
            //    },
            //    new()
            //    {
            //        ClassName = "Constant",
            //        Type = "ushort",
            //        Name = "SUCCESS",
            //        Value = "0",
            //    },
            //};
            //srcGen.Initialize(dataList);
            //srcGen.Generate();
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
