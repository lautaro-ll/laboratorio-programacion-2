using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }

        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        #region "Constructores"
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible) :this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns>String con detalles de todos los vehículos</returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>String con detalle de los vehículos del tipo requerido</returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                //CORRECCION
                sb.AppendLine(v.Mostrar());
                //switch (tipo)
                //{
                //    case ETipo.SUV:
                //        if (v is Suv)
                //            sb.AppendLine(((Suv)v).Mostrar());
                //        break;
                //    case ETipo.Ciclomotor:
                //        if (v is Ciclomotor)
                //            sb.AppendLine(((Ciclomotor)v).Mostrar());
                //        break;
                //    case ETipo.Sedan:
                //        if (v is Sedan)
                //            sb.AppendLine(((Sedan)v).Mostrar());
                //        break;
                //    default:
                //        sb.AppendLine(v.Mostrar());
                //        break;
                //}
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>Objeto de tipo Taller</returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            if(taller.vehiculos.Count() < taller.espacioDisponible)
            {
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                        return taller;
                }
                taller.vehiculos.Add(vehiculo);
            }
            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns>Objeto de tipo Taller</returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    taller.vehiculos.Remove(vehiculo);
                    break;
                }
            }
            return taller;
        }
        #endregion
    }
}
