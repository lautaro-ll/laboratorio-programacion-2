using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//• Abstracta, con el atributo Legajo.
//• Método protegido y virtual MostrarDatos retornará todos los datos del Universitario.
//• Método protegido y abstracto ParticiparEnClase.
//• Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;
        /// <summary>
        /// Constructor por defecto de clase Universitario
        /// </summary>
        public Universitario() { }
        /// <summary>
        /// Constructor por defecto de clase Universitario con parametros legajo, nombre, apellido, dni y nacionalidad
        /// </summary>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad) 
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// Compara si dos objetos son iguales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        /// <summary>
        /// Carga los datos de Universitario en una cadena
        /// </summary>
        /// <returns>retorna la cadena con los datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.Append($"LEGAJO NÚMERO: {this.legajo.ToString()}");

            return sb.ToString();
        }
        /// <summary>
        /// Metodo abstracto que indica en que clases participa el Universitario
        /// </summary>
        /// <returns>cadena con las clases donde participa</returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>true si son iguales, false si no</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return ((pg1.GetType() == pg2.GetType()) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }
        /// <summary>
        /// Dos Universitario serán distintos si no son del mismo Tipo o si su Legajo o DNI son distintos.
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>false si son iguales, true si no</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
