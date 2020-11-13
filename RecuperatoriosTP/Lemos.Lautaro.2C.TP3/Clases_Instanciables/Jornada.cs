using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;

//• Atributos Profesor, Clase y Alumnos que toman dicha clase.
//• Se inicializará la lista de alumnos en el constructor por defecto.
//• Una Jornada será igual a un Alumno si el mismo participa de la clase.
//• Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
//• ToString mostrará todos los datos de la Jornada.
//• Guardar de clase guardará los datos de la Jornada en un archivo de texto.
//• Leer de clase retornará los datos de la Jornada como texto.

namespace Clases_Instanciables
{
    public class Jornada
    {
        private Profesor instructor;
        private EClases clase;
        private List<Alumno> alumnos;
        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }
        public Profesor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }
        public static bool Guardar(Jornada jornada)
        {
            IArchivo<string> archivosTexto = new Texto();
            string rutaArchivoTexto = AppDomain.CurrentDomain.BaseDirectory + "txtfile.txt";

            if (archivosTexto.Guardar(rutaArchivoTexto, jornada.ToString()))
                return true;
            else
                return false;
        }
        public static string Leer()
        {
            IArchivo<string> archivosTexto = new Texto();
            string rutaArchivoTexto = AppDomain.CurrentDomain.BaseDirectory + "txtfile.txt";
            string contenido;

            if (archivosTexto.Leer(rutaArchivoTexto, out contenido))
                return contenido;
            else
                return "";
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.Alumnos.Contains(a);
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
                j.Alumnos.Add(a);
            return j;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CLASE DE {this.Clase.ToString()} POR {this.Instructor.ToString()}");
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno a in Alumnos)
                sb.AppendLine(a.ToString());

            return sb.ToString();
        }

    }
}
