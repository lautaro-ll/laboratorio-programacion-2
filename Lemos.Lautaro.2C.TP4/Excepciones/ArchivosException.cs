using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Excepción que indica en su mensaje: "Error en manejo de archivos" y transmite la innerException
        /// </summary>
        public ArchivosException(Exception innerException) : base("Error en manejo de archivos.", innerException) { }

    }
}
