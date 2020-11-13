using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
        where T : new()
    {
        /// <summary>
        /// Serializa un objeto y guarda los datos en un archivo xml.
        /// </summary>
        /// <param name="archivo">indica la ubicación del archivo a guardar</param>
        /// <param name="datos">objeto a guardar</param>
        /// <returns>true si pudo guardar correctamente, false si ocurre una excepcion</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                if (!object.ReferenceEquals(writer, null))
                    writer.Close();
            }   
        }
        /// <summary>
        /// Lee un archivo xml y carga el objeto en una variable a retornar.
        /// </summary>
        /// <param name="archivo">indica la ubicación del archivo a leer</param>
        /// <param name="datos">objeto donde se cargan datos leidos</param>
        /// <returns>true si pudo leer correctamente, false si ocurre una excepcion</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader writer = null;
            try
            {
                writer = new XmlTextReader(archivo);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(writer);
                writer.Close();

                return true;
            }
            catch (Exception)
            {
                datos = default(T);
                return false;
            }
            finally
            {
                if (!object.ReferenceEquals(writer, null))
                    writer.Close();
            }
        }
    }
}
