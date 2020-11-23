using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class CuitInvalidoException : Exception
    {
        /// <summary>
        /// Excepción que indica en su mensaje: "La nacionalidad no se condice con el número de DNI"
        /// </summary>
        public CuitInvalidoException() : base("CUIT Inválido.") { }
        /// <summary>
        /// Excepción que indica un mensaje personalizado.
        /// </summary>
        /// <param name="mensaje">mensaje a mostrar</param>
        public CuitInvalidoException(string mensaje) : base(mensaje) { }
    }
}
