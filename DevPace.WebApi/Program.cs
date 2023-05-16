using Domain.Repositories;
using Persistence;
using Services;
using Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;

namespace DevPace.WebApi
{
    public class Program
    {
        public IConfiguration Configuration { get; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IService, CustomerService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRespository>();
            builder.Services.AddDbContextPool<RepositoryDbContext>(dbBuilder =>
            {
                var connectionString = builder.Configuration.GetConnectionString("Database");
                dbBuilder.UseSqlServer(connectionString);
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}