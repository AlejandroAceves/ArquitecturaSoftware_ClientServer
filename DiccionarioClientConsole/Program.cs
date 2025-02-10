using DiccionarioClientConsole.DTO;
using DiccionarioService.Models;
using DiccionarioService.Repositories;
using DiccionarioService.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DiccionarioClientConsole
{
  
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DiccionarioDb");

            // Configurar el contenedor de servicios
            var serviceProvider = new ServiceCollection()
                .AddDbContext<DiccionarioDBContext>(options => options.UseSqlServer(connectionString))
                .AddScoped<ConceptoRepository>()
                .AddScoped<ConceptoService>()
                .BuildServiceProvider();

            // Obtener el servicio desde la DI container
            var conceptoService = serviceProvider.GetRequiredService<ConceptoService>();

            // Ahora puedes usar conceptoService en el cliente
            Menu(conceptoService);

        }



        static void Menu(ConceptoService conceptoService)
        {
            Console.WriteLine("Opciones:");
            Console.WriteLine("1. Agregar Concepto");
            Console.WriteLine("2. Ver Todos los Conceptos");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                Console.WriteLine("Ingrese el concepto:");
                string concepto = Console.ReadLine();
                Console.WriteLine("Ingrese la definición:");
                string definicion = Console.ReadLine();

                var conceptoDTO = new ConceptoDTO { Concepto = concepto, Definicion = definicion };
                conceptoService.AddConcepto(conceptoDTO);
                Console.WriteLine("Concepto agregado.");
            }
            else if (opcion == 2)
            {
                var conceptos = conceptoService.GetAllConceptos();
                foreach (var item in conceptos)
                {
                    Console.WriteLine($"Concepto: {item.Concepto}, Definición: {item.Definicion}");
                }
            }
        }
    }
}
