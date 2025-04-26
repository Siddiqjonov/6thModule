using TaskManager.Api.Configurations;
using TaskManager.Api.Filters;
using TaskManager.Api.Middleware;

namespace TaskManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.ConfigureSerilog();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExeptionFilter>();
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            builder.ConfigureDatabase();
            builder.RegisterServices();

            var app = builder.Build();

            //app.UseMiddleware<RequestDurationMiddleware>();
            //app.UseMiddleware<NightBlockMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Apply CORS policy
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}