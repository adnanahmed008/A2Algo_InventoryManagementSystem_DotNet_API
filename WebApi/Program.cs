using BusinessLogic;
using BusinessLogic.Concreate;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string angularAppOrigin = "IMSAngularAppOrigin";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            builder.Services.AddDbContext<InventoryDbContext>(options =>
            {
                options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IPurchaseService, PurchaseService>();
            builder.Services.AddTransient<ISaleService, SaleService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: angularAppOrigin, policy =>
                                  {
                                      policy
                                      .AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                                  });
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
            app.UseCors(angularAppOrigin);

            app.MapControllers();

            app.Run();
        }
    }
}