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

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario() { }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad) { }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Legajo");
            sb.AppendLine(this.legajo.ToString());

            return sb.ToString();
        }
        protected abstract string ParticiparEnClase();
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.GetType() == pg2.GetType()) && (pg1.legajo == pg2.legajo || pg1.DNI == pg1.DNI);
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
