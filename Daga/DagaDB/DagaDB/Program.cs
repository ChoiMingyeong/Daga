namespace DagaDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (builder.Configuration["Port"] is not string portConfig
                || true == string.IsNullOrWhiteSpace(portConfig)
                || false == int.TryParse(portConfig, out int port))
            {
                throw new Exception("Invalid config");
            }

            builder.WebHost.UseKestrel(p => p.ListenAnyIP(port));

            builder.Services.AddCors(p =>
            {
                p.AddDefaultPolicy(p =>
                {
                    p.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
