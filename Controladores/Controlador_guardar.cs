using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calcularoa_C_S2_Tr1.Modelos;

namespace Calcularoa_C_S2_Tr1.Controladores
{
 public class Controlador_guardar
 {
     // Parsea la expresión y devuelve un objeto Guardar_numero_signo
     public Guardar_numero_signo Parfrase_Expresion(string expr)
     {
         if (expr == null)
         expr = string.Empty;

         expr = expr.Trim();

         var resultado = new Guardar_numero_signo();

         var numeros = new List<decimal>();
         var operacionales = new List<char>();

         string num = "";
         foreach (char c in expr)
         {
             if (char.IsDigit(c) || c == '.')
             {
                num += c;
             }
            else
            {
                if (num != "")
            {
                numeros.Add(decimal.Parse(num, CultureInfo.InvariantCulture));
                num = "";
            }

                // Sólo guardar operadores válidos (añadido '%')
                if (c == '+' || c == '-' || c == '*' || c == '/' || c == '%')
                operacionales.Add(c);
            }
         }
         if (num != "")
            numeros.Add(decimal.Parse(num, CultureInfo.InvariantCulture));

            resultado.Numeros = numeros;
            resultado.Operadores = operacionales;

        return resultado;
     }
 }
}
