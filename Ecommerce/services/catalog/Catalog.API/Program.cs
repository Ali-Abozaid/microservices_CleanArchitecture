using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data.Contexts;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly(),
                Assembly.GetAssembly(typeof(GetProductByIdQuery))));


            builder.Services.AddScoped<ICatalogContext, CatalogContext>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IBrandRepository, ProductRepository>();
            builder.Services.AddScoped<ITypeRepository, ProductRepository>();

            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
            });
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Catalog API",
                    Version = "v1",
                    Description = "Catalog microservice for managing products and categories",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Aly Abozaid",
                        Email = "aliabozaid@gmail.com"
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}