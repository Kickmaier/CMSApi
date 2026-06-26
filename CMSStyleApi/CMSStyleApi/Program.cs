using CMSStyleApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMSStyleApi
{
    public class Program
    {
        public static void Main(string[] args)
        { 

            var builder = WebApplication.CreateBuilder(args);
            
            var cMSUrl = builder.Configuration["AllowedSource:CMSUrl"]
                ?? throw new InvalidOperationException("No allowed source found in appsettings");

            var connectionString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCMS", policy =>
                {
                    policy.WithOrigins("https://localhost:7174/")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseCors("MyCMS");

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           
            app.UseAuthentication();

            app.MapControllers();
 
            app.Run();
        }
    }
}
