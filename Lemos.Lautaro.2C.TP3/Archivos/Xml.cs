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
        public bool Guardar(string archivo, T datos) //void Serializar(T objeto, string rutaCompleta)
        {
            bool retorno = false;
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, archivo);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    retorno = true;
                }
            }
            return retorno;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            using (XmlTextReader reader = new XmlTextReader(archivo))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(reader);
                retorno = true;
            }
            return retorno;
        }
    }
}
