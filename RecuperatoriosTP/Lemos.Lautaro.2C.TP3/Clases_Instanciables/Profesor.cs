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
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            List<EClases> listaDeClases = clasesDelDia.ToList();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA:");
            foreach (EClases clase in listaDeClases)
                sb.AppendLine(clase.ToString());

            return sb.ToString();
        }
        static Profesor() 
        {
            Profesor.random = new Random();
        }
        public Profesor() { }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base (id, nombre, apellido, dni, nacionalidad) 
        {
            this.clasesDelDia = new Queue<EClases>();
            _randomClases();
            _randomClases();
        }
        public static bool operator ==(Profesor i, EClases clase)
        {
            foreach (EClases c in i.clasesDelDia)
                if (c == clase)
                    return true;
            return false;
        }
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        public override string ToString()
        {
            return (string) MostrarDatos();
        }
    }
}
