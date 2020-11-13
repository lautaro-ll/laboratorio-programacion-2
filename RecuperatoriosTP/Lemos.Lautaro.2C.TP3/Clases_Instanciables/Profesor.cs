using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;

//• Atributos ClasesDelDia del tipo Cola y random del tipo Random y estático.
//• Sobrescribir el método MostrarDatos con todos los datos del profesor.
//• ParticiparEnClase retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
//• ToString hará públicos los datos del Profesor.
//• Se inicializará a Random sólo en un constructor.
//• En el constructor de instancia se inicializará ClasesDelDia y se asignarán dos clases al azar al Profesor mediante el método randomClases. Las dos clases pueden o no ser la misma.
//• Un Profesor será igual a un EClase si da esa clase.

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((EClases)Profesor.random.Next(0, 3));
        }
        /// <summary>
        /// Carga los datos de Profesor en una cadena
        /// </summary>
        /// <returns>retorna la cadena con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        /// Indica en que clases participa el Profesor
        /// </summary>
        /// <returns>cadena con las clases donde participa</returns>
        protected override string ParticiparEnClase()
        {
            List<EClases> listaDeClases = clasesDelDia.ToList();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA:");
            foreach (EClases clase in listaDeClases)
                sb.AppendLine(clase.ToString());

            return sb.ToString();
        }
        /// <summary>
        /// Constructor estático que instancia la variable random
        /// </summary>
        static Profesor() 
        {
            Profesor.random = new Random();
        }
        /// <summary>
        /// Constructor por defecto de Profesor
        /// </summary>
        public Profesor() { }
        /// <summary>
        /// Constructor de Profesor con los parametros id, nombre, apellido, dni, nacionalidad
        /// </summary>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base (id, nombre, apellido, dni, nacionalidad) 
        {
            this.clasesDelDia = new Queue<EClases>();
            _randomClases();
            _randomClases();
        }
        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>true si el profesor da la clase, false sino</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            foreach (EClases c in i.clasesDelDia)
                if (c == clase)
                    return true;
            return false;
        }
        /// <summary>
        /// Un Profesor será distinto a un EClase si no da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>false si el profesor da la clase, true sino</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        /// <summary>
        /// Devuelve una cadena con los datos de Profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (string) MostrarDatos();
        }
    }
}
