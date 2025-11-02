using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcularoa_C_S2_Tr1.Modelos
{
    public class Calculadora
    {
        public decimal Suma(decimal a, decimal b) => a + b;
        public decimal Resta(decimal a, decimal b) => a - b;
        public decimal Multiplicacio(decimal a, decimal b) => a * b;
        public decimal Divicion(decimal a, decimal b)
        {
            if (b ==0)
                throw new DivideByZeroException("División por cero.");
            return a / b;
        }
    }
}
