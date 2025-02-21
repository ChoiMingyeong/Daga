using Microsoft.AspNetCore.Mvc;
using OpsCommon;
using StackExchange.Redis;
using System.Collections.Concurrent;

namespace GateHub
{
    public class Program
    {
        private static Lazy<ConcurrentDictionary<string, string>>? _gates = null;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseKestrel();
            builder.WebHost.UseConfiguration(builder.Configuration);

            var redisConfig = builder.Configuration.GetSection("Redis:ConnectionString").Value;
            if (null != redisConfig)
            {
                builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConfig));
            }
            builder.Services.AddSingleton<RedisService>();

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();
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
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                // Swagger : https://localhost:9002/swagger
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
