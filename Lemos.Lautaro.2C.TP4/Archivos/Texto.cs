using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Establece los métodos para Guardar y Leer un archivo de texto.
    /// </summary>
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda un texto en un archivo en la ruta indicada.
        /// </summary>
        /// <param name="rutaArchivo">Ruta donde guardar el archivo</param>
        /// <param name="datos">Texto a guardar</param>
        public void Guardar(string rutaArchivo, string datos)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(rutaArchivo, true))
                {
                    file.WriteLine(datos);
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Lee el texto de el archivo indicado en la ruta.
        /// </summary>
        /// <param name="rutaArchivo">Ruta del archivo a leer</param>
        /// <param name="datos">Texto a leer</param>
        public void Leer(string rutaArchivo, out string datos)
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(rutaArchivo))
                {
                    datos = file.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
