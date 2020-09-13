using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {

        private double numero;
        /// <summary>
        /// Constructor de clase Numero, asigna valor 0 al atributo número.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor de clase Numero, asigna el parametro "numero" al atributo número.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor de clase Numero, asigna el parametro "strNumero" al atributo número.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Asigna un valor al atributo número, previa validación.
        /// </summary>
        public string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }
        /// <summary>
        /// Comprueba que el valor recibido sea numérico.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna el número validado en formato double. Caso contrario, retornará 0.</returns>
        public static double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                return numero;
            }
            else
                return 0;
        }
        /// <summary>
        /// Valida que la cadena de caracteres esté compuesta SOLAMENTE por caracteres '0' o '1'.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Retorna "true" si la cadena es un número binario. Caso contrario retornará "false".</returns>
        private bool EsBinario(string binario)
        {
            bool retorno = true;
            char[] cadena = binario.ToCharArray();

            foreach(char x in cadena)
            {
                if (!(x.Equals('0') || x.Equals('1')))
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Convierte el valor recibido a un entero positivo, valida que se trate de un binario y luego lo convierte a decimal, en caso de ser posible.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna la cadena en decimal. Caso contrario retornará "Valor Inválido".</returns>
        public string BinarioDecimal(double numero)
        {
            double numeroEntero = Math.Abs(numero);
            if (EsBinario(numeroEntero.ToString()))
            {
                return Convert.ToString(Convert.ToInt32(numeroEntero.ToString(), 2),10);
            }
            return "Valor Inválido";
        }
        /// <summary>
        /// Convierte el valor recibido a un entero positivo, y luego lo convierte a decimal, en caso de ser posible.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna la cadena en binario. Si la cadena no es válida o cero retornará "Valor Inválido".</returns>
        public string DecimalBinario(string numero)
        {
            Numero objNum = new Numero(numero);
            int numeroEntero = (int) Math.Abs(objNum.numero);
            if (numeroEntero != 0)
            {
                return Convert.ToString(Convert.ToInt32(numeroEntero), 2);
            }
            return "Valor Inválido";
        }
        /// <summary>
        /// Realiza la suma entre los dos parámetros.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna la suma.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Realiza la resta entre los dos parámetros.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna la resta.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Realiza la multiplicación entre los dos parámetros.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el producto.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Realiza la división entre los dos parámetros.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el cociente. Si el divisor es cero retornará el mínimo valor de tipo "double".</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
                return n1.numero / n2.numero;
        }
    }
}
