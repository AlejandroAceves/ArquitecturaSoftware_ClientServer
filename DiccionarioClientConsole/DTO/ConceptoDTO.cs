using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiccionarioClientConsole.DTO
{
    internal class ConceptoDTO
    {
        public string Concepto { get; set; }
        public string Definicion { get; set; }

        public override string ToString()
        {
            return $"CONCEPTO|{Concepto}|{Definicion}";
        }

        public static ConceptoDTO FromString(string data)
        {
            var parts = data.Split('|');
            return new ConceptoDTO
            {
                Concepto = parts[1],
                Definicion = parts[2]
            };
        }
    }
}
