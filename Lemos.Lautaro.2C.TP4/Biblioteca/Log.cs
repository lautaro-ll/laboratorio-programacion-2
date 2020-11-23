using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Biblioteca
{
    public class Log
    {
        /// <summary>
        /// Guarda un texto en un archivo .txt
        /// </summary>
        /// <param name="entrada"></param>
        public static void Guardar(string entrada)
        {
            IArchivo<string> archivosTexto = new Texto();
            string rutaArchivoTexto = AppDomain.CurrentDomain.BaseDirectory + "txtfile.txt";
            archivosTexto.Guardar(rutaArchivoTexto, entrada);
        }
        /// <summary>
        /// Lee un texto de un archivo .txt 
        /// </summary>
        /// <returns>string con texto leído.</returns>
        public static string Leer()
        {
            IArchivo<string> archivosTexto = new Texto();
            string rutaArchivoTexto = AppDomain.CurrentDomain.BaseDirectory + "txtfile.txt";
            string contenido;

            archivosTexto.Leer(rutaArchivoTexto, out contenido);
            return contenido;
        }
    }
}
