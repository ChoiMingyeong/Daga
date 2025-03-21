using DagaCommon;
using DagaDB.DB;

namespace DagaDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bool @bool = new([true, false, false, true]);
            @bool.RemoveAt(1);
            @bool[1] = true;

            Bools bools1 = new();
            bools1.Add(true);
            bools1[150] = true;
            Bools bools2 = new(bools1);
            bools1[3] = true;
            Bools bools3 = new(12, [170, 5]);

            var size = bools1.Count();
            var bytes = bools1.ToBytes();
            var ushorts = bools1.ToUShorts();
            var uints = bools1.ToUInts();
            var ulongs = bools1.ToULongs();

            Bools bools4 = new(size, bytes);
            Bools bools5 = new(size, ushorts);
            Bools bools6 = new(size, uints);
            Bools bools7 = new(size, ulongs);

            CalculatorTest calculatorTest = new CalculatorTest();
            calculatorTest.AddEntity(new TestTable() { Id = 1, Value = 1, Value2 = 5 });
            calculatorTest.AddEntity(new TestTable() { Id = 1, Value = 1, Value2 = 5, Value3 = "Test" });
            calculatorTest.AddEntity(new TestTable() { Id = 2, Value = 20 });
            calculatorTest.AddEntity(new TestTable() { Id = 2, Value = 2 });
            calculatorTest.AddEntity(new TestTable() { Id = 3, Value = 3, Value3 = "Test" });
            calculatorTest.AddEntity(new TestTable() { Id = 3, Value = 3, Value3 = "String" });

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
