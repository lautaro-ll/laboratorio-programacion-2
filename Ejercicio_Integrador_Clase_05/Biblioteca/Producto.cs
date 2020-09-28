using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Producto
    {
        private string codigoDeBarra;
        private string marca;
        private float precio;

        public Producto(string marca, string codigo, float precio)
        {
            this.marca = marca;
            this.codigoDeBarra = codigo;
            this.precio = precio;
        }

        public string GetMarca()
        {
            return this.marca;
        }
        public float GetPrecio()
        {
            return this.precio;
        }
        public static string MostrarProducto(Producto p)
        {
            if (object.ReferenceEquals(p, null))
            {
                return "Vacío";
            }
            return $"Marca: {p.marca} - Precio: {p.precio} - Código de barras: {p.codigoDeBarra}";
        }

        public static explicit operator string(Producto p)
        {
            if (object.ReferenceEquals(p, null))
            {
                return "";
            }
            return p.codigoDeBarra;
        }
        public static bool operator ==(Producto p, string marca)
        {
            if (object.ReferenceEquals(p, null))
            {
                return false;
            }
            return (p.marca == marca);
        }
        public static bool operator !=(Producto p, string marca)
        {
            return !(p == marca);
        }

        public static bool operator ==(Producto p1, Producto p2)
        {
            if (object.ReferenceEquals(p1, null) || object.ReferenceEquals(p2, null))
            {
                return false;
            }
            return (p1.marca == p2.marca && p1.codigoDeBarra == p2.codigoDeBarra);
        }
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

    }
}
