
using CommandLine;
using OpsCommon;
using OpsDBApi.DB;

namespace OpsDBApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = Parser.Default.ParseArguments<OpsDBAPIOptions>(args).Value;

            var builder = WebApplication.CreateBuilder(args);

            if (options.HttpPort > 0)
            {
                builder.WebHost.UseKestrel(p => p.ListenAnyIP(options.HttpPort));
            }
            if (options.HttpsPort > 0)
            {
                builder.WebHost.UseKestrel(p => p.ListenAnyIP(options.HttpsPort, p => p.UseHttps()));
            }

            builder.WebHost.UseConfiguration(builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddCors(p =>
            {
                p.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<OpsDbContext>(p => new(options.DBConnetcionString));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                // Swagger : https://localhost:9102/swagger
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors("AllowAll");
            app.UseRouting();

            app.UseSwagger();

            app.Run();
        }
    }
}
