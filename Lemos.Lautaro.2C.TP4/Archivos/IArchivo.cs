using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// IArchivo establece las firmas de los métodos para guardar y leer tanto un archivo de texto como una serialización Xml.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IArchivo<T>
    {
        void Guardar(string archivo, T datos);
        void Leer(string archivo, out T datos);
    }
}
