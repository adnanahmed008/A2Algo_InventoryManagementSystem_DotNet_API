
using AutoMapper;
using BusinessLogic;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using Core.DTOs;
using Core.Entities;
using DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            //MapperConfiguration config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Product, ProductReadDTO>().ReverseMap();

            //    cfg.CreateMap<ProductWriteDTO, Product>()
            //        .ForMember(dest => dest.Id, src => src.Ignore())
            //        .ForMember(dest => dest.Quantity, src => src.Ignore())
            //        .ForMember(dest => dest.Purchases, src => src.Ignore())
            //        .ForMember(dest => dest.Sales, src => src.Ignore())
            //        .ForMember(dest => dest.CreatedBy, src => src.Ignore())
            //        .ForMember(dest => dest.CreationDate, src => src.Ignore())
            //        .ForMember(dest => dest.ModifiedBy, src => src.Ignore())
            //        .ForMember(dest => dest.ModifiedDate, src => src.Ignore())
            //        .ForMember(dest => dest.IsDeleted, src => src.Ignore());



            //    cfg.CreateMap<Sale, SaleDTO>();
            //    cfg.CreateMap<Purchase, PurchaseDTO>();
            //});

            //config.AssertConfigurationIsValid();

            //IMapper mapper = config.CreateMapper();
            //builder.Services.AddSingleton(mapper);


            builder.Services.AddDbContext<InventoryDbContext>(options =>
            {
                options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IProductService, ProductService>();

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