using System;
using System.Configuration;
using System.IO;
using FurnitureFactory.DbContext;
using FurnitureFactory.Interfaces;
using FurnitureFactory.Models;
using FurnitureFactory.Repository;
using FurnitureFactory.Repository.Interfaces;
using FurnitureFactory.Services;
using FurnitureFactory.Services.Interfaces;
//using FurnitureFactory.Repositoty;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FurnitureFactory
{
    public class Program
    {
        private readonly ILogger<Program> _logger;
        private static IConfigurationRoot configuration;
        private readonly IProductService _productService;


        static void Main(string[] args)
        {
            BuildConfig();
            var host = CreateHostBuilder(args).Build();
            var program = host.Services.GetRequiredService<Program>();
            var test = program._productService.GetAllProductsAsync();
            Console.WriteLine(test.Result.Count);
            Console.WriteLine("Exiting program :)");
        }

        public Program(ILogger<Program> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        private static void BuildConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Production"}.json",
                    optional: true);
            configuration = builder.Build();

        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                    services.AddTransient<Program>();
                    AddRepositories(services);
                    AddFactoryServices(services);
                    
                });
        }

        public static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
        }

        public static void AddFactoryServices(IServiceCollection services)
        {
            services.AddTransient<IProductFromTemplateService, ProductFromTemplateService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ITemplateService, TemplateService>();
        }
    }
}
