using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calcularoa_C_S2_Tr1.Modelos;

namespace Calcularoa_C_S2_Tr1.Controladores
{
    public class Controlador_calculadora
    {
        private readonly Calculadora calculadora_obj = new Calculadora();

        // Calcula el resultado respetando su orden de operaciones
        public decimal Calcular_resultado(Guardar_numero_signo data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

        // Trabajar sobre copias para no mutar el modelo original
        var numeros = new List<decimal>(data.Numeros);
        var operadores = new List<char>(data.Operadores);

        // Manejar operador de porcentaje '%'
        for (int idx =0; idx < operadores.Count; idx++)
        {
            if (operadores[idx] == '%')
            {
                if (idx ==0)
                {
                    // "%" aplicado al primer número: 
                    if (numeros.Count >0)
                        numeros[idx] = numeros[idx] /100m;
                }
                else
                {
                    // Base para el porcentaje es el número anterior en la lista
                    if (idx -1 >=0 && idx < numeros.Count)
                    {
                        decimal base_valor = numeros[idx -1];
                        decimal verdadero_valor = base_valor * numeros[idx] /100m;
                        numeros[idx] = verdadero_valor;
                    }
                }

                // Remover el operador '%'
                operadores.RemoveAt(idx);
                idx--;
            }
        }

        // Primero multiplicacion y division
        for (int idx =0; idx < operadores.Count; idx++)
        {
            if (operadores[idx] == '*' || operadores[idx] == '/')
            {
                decimal valor_a = numeros[idx];
                decimal valor_b = numeros[idx +1];
                decimal resultado;

             if (operadores[idx] == '*')
                resultado = calculadora_obj.Multiplicacio(valor_a, valor_b);
            else
                resultado = calculadora_obj.Divicion(valor_a, valor_b);

            numeros[idx] = resultado;
            numeros.RemoveAt(idx +1);
            operadores.RemoveAt(idx);
                idx--; // retroceder índice para reevaluar en la nueva posición
            }
        }

         // Suma y resta
        for (int idx =0; idx < operadores.Count; idx++)
        {
           if (operadores[idx] == '+' || operadores[idx] == '-')
           {
                decimal valor_a = numeros[idx];
                decimal valor_b = numeros[idx +1];
                decimal resultado;

           if (operadores[idx] == '+')
                resultado = calculadora_obj.Suma(valor_a, valor_b);
           else
                resultado = calculadora_obj.Resta(valor_a, valor_b);

                numeros[idx] = resultado;
                numeros.RemoveAt(idx +1);
                operadores.RemoveAt(idx);
                idx--;
           }
        }

        return numeros.Count >0 ? numeros[0] :0m;
        }
     }
}
