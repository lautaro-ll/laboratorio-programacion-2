using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Excepción que indica en su mensaje: "Dni inválido."
        /// </summary>
        public DniInvalidoException() : base("Dni inválido.") { }
        /// <summary>
        /// Excepción que indica en su mensaje: "Dni inválido." y transmite la innerException
        /// </summary>
        public DniInvalidoException(Exception e) : base("Dni inválido.", e) { }
        /// <summary>
        /// Excepción que indica un mensaje personalizado.
        /// </summary>
        /// <param name="mensaje">mensaje a mostrar</param>
        public DniInvalidoException(string message) : base(message) { }
        /// <summary>
        /// Excepción que indica un mensaje personalizado y transmite la innerException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e) : base(message, e) { }
    }
}
