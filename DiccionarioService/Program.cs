using DiccionarioService.Models;
using DiccionarioService.DTO;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using DiccionarioService.Repositories;
using DiccionarioService.Service;
namespace DiccionarioService
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            var connectionString = configuration.GetConnectionString("DiccionarioDb");

            var serviceProvider = new ServiceCollection()
                .AddDbContext<DiccionarioDBContext>(options =>
                    options.UseSqlServer(connectionString))
                .AddScoped<ConceptoRepository>()
                .AddScoped<ConceptoService>()
                .BuildServiceProvider();

            var dbContext = serviceProvider.GetRequiredService<DiccionarioDBContext>();

            AddConcepto(dbContext);
        }

        public static void AddConcepto(DiccionarioDBContext dbContext)
        {
            var concepto = new Concepto
            {
                Concept = "Polimorfismo",
                Definicion = "Capacidad de un objeto de tomar diferentes formas."
            };

            dbContext.Conceptos.Add(concepto);
            dbContext.SaveChanges();

            Console.WriteLine("Concepto agregado: " + concepto.Concept);
        }
    }
}
