using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Producto
    {
        private int id;
        private string descripcion;
        private float precio;
        private int cantidad;
        /// <summary>
        /// Setter y getter de id.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Setter y getter de descripcion.
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        /// <summary>
        /// Setter y getter de precio.
        /// </summary>
        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        /// <summary>
        /// Setter y getter de cantidad.
        /// </summary>
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        /// <summary>
        /// Constructor con parámetros descripcion, precio y cantidad.
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
        public Producto(string descripcion, float precio, int cantidad)
        {
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Cantidad = cantidad;
        }
        /// <summary>
        /// Constructor con parámetros id, descripcion, precio y cantidad.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
        public Producto(int id, string descripcion, float precio, int cantidad) : this(descripcion, precio, cantidad)
        {
            this.Id = id;
        }
        /// <summary>
        /// Devuelve los datos de Producto.
        /// </summary>
        /// <returns>String con id, descripcion, precio y cantidad.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"ID: {Id}\n");
            sb.Append($"PRODUCTO: {Descripcion}\n");
            sb.Append($"PRECIO: ${Precio.ToString()}\n");
            sb.Append($"UNIDADES: {Cantidad}");
            return sb.ToString();
        }
    }
}