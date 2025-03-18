
using DagaCommon;
using DagaDB.DB;
using System.Numerics;

namespace DagaDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CalculatorTest calculatorTest = new CalculatorTest();
            calculatorTest.AddEntity(new TestTable() { Id = 1, Value = -1 });
            calculatorTest.AddEntity(new TestTable() { Id = 2, Value = 20 });
            calculatorTest.AddEntity(new TestTable() { Id = 1, Value = int.MinValue, Value2 = 5 });
            calculatorTest.AddEntity(new TestTable() { Id = 3, Value = 30, Value3 = "Test" });
            calculatorTest.AddEntity(new TestTable() { Id = 2, Value = 2 });
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
