using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;

//• Atributos ClaseQueToma del tipo EClase y EstadoCuenta del tipo EEstadoCuenta.
//• Sobreescribirá el método MostrarDatos con todos los datos del alumno.
//• ParticiparEnClase retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
//• ToString hará públicos los datos del Alumno.
//• Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
//• Un Alumno será distinto a un EClase sólo si no toma esa clase

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno() { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());

            string cadenaEstadoCuenta = "";
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    cadenaEstadoCuenta = "Cuota al día";
                    break;
                case EEstadoCuenta.Becado:
                    cadenaEstadoCuenta = "Alumno becado";
                    break;
                case EEstadoCuenta.Deudor:
                    cadenaEstadoCuenta = "Alumno deudor";
                    break;
            }
            sb.AppendLine($"ESTADO DE CUENTA: {cadenaEstadoCuenta}");
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.claseQueToma.ToString()}";
        }
        public static bool operator ==(Alumno a, EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }
        public static bool operator !=(Alumno a, EClases clase)
        {
            return a.claseQueToma != clase;
        }
        public override string ToString()
        {
            return (string) MostrarDatos();
        }
    }
}
