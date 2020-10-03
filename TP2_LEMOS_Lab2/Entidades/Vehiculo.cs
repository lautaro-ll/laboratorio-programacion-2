using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        private string chasis;
        private ConsoleColor color;
        private EMarca marca;

        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.color = color;
            this.marca = marca;
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>String con detalle del vehículo</returns>
        public virtual string Mostrar()
        {
            return (string) this;
        }
        /// <summary>
        /// Convierte por casteo el objeto Vehiculo a un string con la información del mismo
        /// </summary>
        /// <param name="p">Objeto a convertir</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {p.chasis}");
            sb.AppendLine($"MARCA : {p.marca}");
            sb.AppendLine($"COLOR : {p.color}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Primer objeto Vehiculo a comparar</param>
        /// <param name="v2">Segundo objeto Vehiculo a comparar</param>
        /// <returns>true si son iguales, false si no</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Primer objeto Vehiculo a comparar</param>
        /// <param name="v2">Segundo objeto Vehiculo a comparar</param>
        /// <returns>true si NO son iguales, false si lo son</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}
