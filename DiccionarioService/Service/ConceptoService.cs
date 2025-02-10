using DiccionarioService.DTO;
using DiccionarioService.Models;
using DiccionarioService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiccionarioService.Service
{
    public class ConceptoService
    {
        private readonly ConceptoRepository _conceptoRepository;

        public ConceptoService(ConceptoRepository conceptoRepository)
        {
            _conceptoRepository = conceptoRepository;
        }

        public void AddConcepto (ConceptoDTO conceptoDTO)
        {
            var concepto = new Concepto
            {
                Concept = conceptoDTO.Concepto,
                Definicion = conceptoDTO.Definicion,
            };

            _conceptoRepository.AddConcepto(concepto);
        }

        public List<ConceptoDTO> GetAllConceptos()
        {
            var conceptos = _conceptoRepository.GetAllConceptos();
            return conceptos.Select(c => new ConceptoDTO
            {
                Concepto = c.Concept,
                Definicion = c.Definicion
            }).ToList();
        }

        public ConceptoDTO GetConceptoById(int id)
        {
            var concepto = _conceptoRepository.GetConceptoById(id);
            if (concepto == null) return null;

            return new ConceptoDTO
            {
                Concepto = concepto.Concept,
                Definicion = concepto.Definicion
            };
        }
    }
}
