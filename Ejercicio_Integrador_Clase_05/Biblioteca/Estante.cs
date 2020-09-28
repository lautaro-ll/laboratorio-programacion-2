using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Estante
    {
        private Producto[] Producto;
        private int ubicacionEstante;

        private Estante(int capacidad)
        {
            Producto = new Producto[capacidad];
        }
        public Estante(int capacidad, int ubicacion) : this(capacidad)
        {
            this.ubicacionEstante = ubicacion;
        }

        public Producto[] GetProductos()
        {
            return this.Producto;
        }
        public static string MostrarEstante(Estante e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string codigoDeBarra;
            foreach (Producto x in e.Producto)
            {
                stringBuilder.AppendLine (Biblioteca.Producto.MostrarProducto(x));
            }

            return stringBuilder.ToString();
        }

        public static bool operator ==(Estante e, Producto p)
        {
            string codigo = (string) p;
            bool flag = false;
            foreach (Producto x in e.Producto)
            {
                if (!object.ReferenceEquals(x, null))
                {
                    string codigoEstante = (string)x;
                    if (p.GetMarca() == x.GetMarca() && codigo == codigoEstante)
                    {
                        flag = true;
                        break;
                    }
                }
            }

            return flag;
        }
        public static bool operator !=(Estante e, Producto p)
        {
            return !(e == p);
        }

        public static bool operator +(Estante e, Producto p)
        {
            bool flag = false;
            if (e != p)
            {
                for(int i=0; i<e.Producto.Length; i++)
                {
                    if(object.ReferenceEquals(e.Producto[i], null)) //devuelve true si cuando compara hay un null
                    {
                        e.Producto[i] = p;
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
        public static Estante operator -(Estante e, Producto p)
        {
            Estante nuevoEstante = new Estante(e.Producto.Length);
            bool flag = true;
            if(e == p)
            {
                for (int i = 0; i < e.Producto.Length; i++)
                {
                    if(e.Producto[i] == p && flag)
                    {
                        flag = false;
                    }
                    else
                    {
                        nuevoEstante.Producto[i] = e.Producto[i];
                    }
                }
            }
            return nuevoEstante;

        }
    }
}
