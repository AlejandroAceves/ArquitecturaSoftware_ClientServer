using DiccionarioService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiccionarioService.Repositories
{
    public class ConceptoRepository
    {
        private readonly DiccionarioDBContext _context;

        public ConceptoRepository(DiccionarioDBContext context)
        {
            _context = context;
        }

        public List<Concepto> GetAllConceptos()
        {
            return _context.Conceptos.ToList();
        }

        public void AddConcepto(Concepto concepto)
        {
            _context.Conceptos.Add(concepto);
            _context.SaveChanges();
        }

        public Concepto GetConceptoById(int id)
        {
            return _context.Conceptos.SingleOrDefault(c => c.Id == id);
        }
    }

}
