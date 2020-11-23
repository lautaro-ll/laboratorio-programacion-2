using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;
using System.IO;

namespace Archivos
{
    /// <summary>
    /// Establece los métodos para Guardar y Leer un archivo XML vía serialización.
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public class Xml<V> : IArchivo<V>
    {
        /// <summary>
        /// Serializa los datos en un archivo en la ruta indicada.
        /// </summary>
        /// <param name="rutaArchivo">Ruta donde guardar el archivo</param>
        /// <param name="datos">Datos a guardar</param>
        public void Guardar(string archivo, V datos)
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(V));
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!object.ReferenceEquals(writer, null))
                    writer.Close();
            }
        }
        /// <summary>
        /// Deserializa los datos de el archivo indicado en la ruta.
        /// </summary>
        /// <param name="rutaArchivo">Ruta del archivo a leer</param>
        /// <param name="datos">Datos a leer</param>
        public void Leer(string archivo, out V datos)
        {
            XmlTextReader writer = null;
            try
            {
                writer = new XmlTextReader(archivo);
                XmlSerializer serializer = new XmlSerializer(typeof(V));
                datos = (V)serializer.Deserialize(writer);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!object.ReferenceEquals(writer, null))
                    writer.Close();
            }
        }
    }
}
