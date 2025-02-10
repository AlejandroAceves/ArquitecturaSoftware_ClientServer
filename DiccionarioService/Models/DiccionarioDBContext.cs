using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace DiccionarioService.Models
{
    public class DiccionarioDBContext : DbContext
    {
        public DiccionarioDBContext(DbContextOptions<DiccionarioDBContext> options)
            : base(options)
        {

        }

        public DbSet<Concepto> Conceptos { get; set; }
    }
}
