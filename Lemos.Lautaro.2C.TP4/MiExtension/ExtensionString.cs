using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoDeExtension
{
    public static class ExtensionString
    {
        /// <summary>
        /// Quita los espacios antes y después del texto, y deja sólo el primer carácter en mayúscula.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>dato formateado.</returns>
        public static string FormatearTexto(this string dato)
        {
            if (!string.IsNullOrWhiteSpace(dato))
            {
                dato = dato.Trim(' ');
                dato = char.ToUpper(dato[0]) + dato.Substring(1).ToLower(); ;
            }
            else
                dato = "";
            return dato;
        }
    }
}
