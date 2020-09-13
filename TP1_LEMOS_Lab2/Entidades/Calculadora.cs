using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida y realiza la operación pedida entre los números ingresados.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            string operadorValidado = ValidarOperador(char.Parse(operador));

            switch (operadorValidado)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
        /// <summary>
        /// Valida que el operador recibido sea +, -, / o *. 
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Retorna el operador válido recibido. Caso contrario retornará +.</returns>
        private static string ValidarOperador(char operador)
        {
            if (operador.Equals('+') || operador.Equals('-') || operador.Equals('*') || operador.Equals('/'))
                return operador.ToString();
            else
                return "+";
        }
    }
}
