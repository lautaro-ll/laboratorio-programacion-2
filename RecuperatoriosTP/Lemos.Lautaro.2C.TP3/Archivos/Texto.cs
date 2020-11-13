using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda una cadena de texto en un archivo.
        /// </summary>
        /// <param name="archivo">indica la ubicación del archivo a guardar</param>
        /// <param name="datos">cadena que contiene los datos a guardar</param>
        /// <returns>true si pudo guardar correctamente, false si ocurre una excepcion</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo, false))
                {
                    file.WriteLine(datos);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Lee un archivo y carga la cadena de texto en una variable a retornar.
        /// </summary>
        /// <param name="archivo">indica la ubicación del archivo a leer</param>
        /// <param name="datos">cadena donde se guardan los datos leidos</param>
        /// <returns>true si pudo leer correctamente, false si ocurre una excepcion</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(archivo))
                {
                    datos = file.ReadToEnd();
                }

                return true;
            }
            catch (Exception)
            {
                datos = "";
                return false;
            }
        }
    }
}
