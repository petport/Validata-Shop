
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using ValidataShopTest.Application.Commands;
using ValidataShopTest.Application.Queries;
using ValidataShopTest.DAL;
using ValidataShopTest.DAL.Repositories;
using ValidataShopTest.Models;

namespace ValidataShopTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ValidataShopContext>(options =>
            {
                options.UseSqlServer(@"Server = PETROS-DESKTOP\SQLEXPRESS;Initial Catalog=ValidataShop;Integrated Security=True;TrustServerCertificate=True");
            });

            /*
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            */

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<ICommandHandler<CreateCustomerCommand>, CreateCustomerCommandHandler>();
            builder.Services.AddScoped<IQueryHandler<GetCustomerQuery, Customer>, GetCustomerQueryHandler>();

            builder.Services.AddScoped<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
            builder.Services.AddScoped<IQueryHandler<GetProductQuery, Product>, GetProductQueryHandler>();


            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            app.MapGet("/api/test", () => "Hello World");

            Console.WriteLine("Hello World!");



            app.Run();

            
        }
    }
}
