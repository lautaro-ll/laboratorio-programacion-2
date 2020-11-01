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
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(archivo);
                streamWriter.WriteLine(datos);
            }
            finally
            {
                if (streamWriter != null)
                { 
                    streamWriter.Close();
                    retorno = true;
                }
            }
            return retorno;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            StreamReader StreamReader = null;
            try
            {
                StreamReader = new StreamReader(archivo);

                datos = string.Empty;
                string newLine = StreamReader.ReadLine();

                while (newLine != null)
                {
                    datos += newLine + "\n";
                    newLine = StreamReader.ReadLine();
                }
            }
            finally
            {
                if (StreamReader != null)
                {
                    StreamReader.Close();
                    retorno = true;
                }
            }
            return retorno;
        }
    }
}
