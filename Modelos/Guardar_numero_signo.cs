using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcularoa_C_S2_Tr1.Modelos
{
    public class Guardar_numero_signo
    {
        public List<decimal> Numeros { get; set; }

        public List<char> Operadores { get; set; }

        public Guardar_numero_signo()
        {
            Numeros = new List<decimal>();
            Operadores = new List<char>();
        }

        public void Clear()
        {
            Numeros.Clear();
            Operadores.Clear();
        }
    }
}
