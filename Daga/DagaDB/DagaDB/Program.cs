
using DagaDB.DB;

namespace DagaDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CalculatorTest calculatorTest = new CalculatorTest();
            calculatorTest.AddEntity(new TestTable() { Id = 1, Value = 1 });
            calculatorTest.AddEntity(new TestTable() { Id = 2, Value = 20 });
            calculatorTest.AddEntity(new TestTable() { Id = 1, Value = 10 });
            calculatorTest.AddEntity(new TestTable() { Id = 3, Value = 30 });
            calculatorTest.AddEntity(new TestTable() { Id = 2, Value = 2 });
            calculatorTest.AddEntity(new TestTable() { Id = 3, Value = 3 });


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
