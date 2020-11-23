using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Biblioteca
{
    public class Cliente
    {
        private string razonSocial;
        private long cuit;
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Cliente() {}
        /// <summary>
        /// Constructor con parámetros razonSocial y cuit.
        /// </summary>
        /// <param name="razonSocial"></param>
        /// <param name="cuit"></param>
        public Cliente(string razonSocial, long cuit)
        {
            this.RazonSocial = razonSocial;
            this.Cuit = cuit;
        }
        /// <summary>
        /// Setter y getter de razonSocial.
        /// </summary>
        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value.ToUpper(); }
        }
        /// <summary>
        /// Setter y getter de cuit.
        /// </summary>
        public long Cuit
        {
            get { return cuit; }
            set 
            {
                if (ValidarCuit(value))
                    cuit = value;
                else
                    throw new CuitInvalidoException();
            }
        }
        /// <summary>
        /// Serializa una lista de clientes.
        /// </summary>
        /// <param name="clientes"></param>
        public static void Guardar(List<Cliente> clientes)
        {
            IArchivo<List<Cliente>> archivosXml = new Xml<List<Cliente>>();
            string rutaArchivoXml = AppDomain.CurrentDomain.BaseDirectory + "xmlfile.xml";
            archivosXml.Guardar(rutaArchivoXml, clientes);
        }
        /// <summary>
        /// Deserializa una lista de clientes.
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> Leer()
        {
            IArchivo<List<Cliente>> archivosXml = new Xml<List<Cliente>>();
            string rutaArchivoXml = AppDomain.CurrentDomain.BaseDirectory + "xmlfile.xml";

            if(File.Exists(rutaArchivoXml))
            {
                List<Cliente> clientes;
                archivosXml.Leer(rutaArchivoXml, out clientes);
                return clientes;
            }
            else
                return null;
        }
        /// <summary>
        /// Valida que el CUIT tenga 11 caractéres y sea mayor a cero.
        /// </summary>
        /// <param name="cuit"></param>
        /// <returns>true si cumple los requisitos, false si no.</returns>
        private bool ValidarCuit(long cuit)
        {
            return (cuit.ToString().Length == 11 && cuit > 0);
        }
        /// <summary>
        /// Devuelve los datos de Cliente.
        /// </summary>
        /// <returns>String con razón social y cuit.</returns>
        public override string ToString()
        {
            return $"{this.RazonSocial} - CUIT: {this.Cuit}";
        }

    }
}
