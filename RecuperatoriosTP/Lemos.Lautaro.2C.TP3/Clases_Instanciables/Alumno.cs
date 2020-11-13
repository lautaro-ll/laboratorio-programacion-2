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
        /// <summary>
        /// Constructor por defecto de Alumno
        /// </summary>
        public Alumno() { }
        /// <summary>
        /// Constructor de Alumno con parametros id, nombre, apellido, dni, nacionalidad y clase que toma.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor de Alumno con parametros id, nombre, apellido, dni, nacionalidad, clase que toma y estado de cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Carga los datos de Alumno en una cadena
        /// </summary>
        /// <returns>retorna la cadena con los datos</returns>
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
        /// <summary>
        /// Indica en que clases participa el Alumno
        /// </summary>
        /// <returns>cadena con las clases donde participa</returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.claseQueToma.ToString()}";
        }
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true si el alumno toma la clase y no es deudor, false sino</returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }
        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true si el alumno no toma la clase, false sino</returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            return a.claseQueToma != clase;
        }
        /// <summary>
        /// Devuelve una cadena con los datos de Alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (string) MostrarDatos();
        }
    }
}
