using MyApiProject.BusinessLayer.Abstract;
using MyApiProject.BusinessLayer.Concrete;
using MyApiProject.DataAccessLayer.Abstract;
using MyApiProject.DataAccessLayer.Context;
using MyApiProject.DataAccessLayer.EntityFramework;

namespace MyApiProject.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApiContext>();

            // Dependency Injection Registrations
            builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
            builder.Services.AddScoped<ICategoryService, CategoryManager>();

            builder.Services.AddScoped<IProductDal, EfProductDal>();
            builder.Services.AddScoped<IProductService, ProductManager>();

            // Add services to the container.
            builder.Services.AddControllers();
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

            app.Run();
        }
    }
}