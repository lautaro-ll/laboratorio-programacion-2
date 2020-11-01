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
        public bool Guardar(Jornada jornada)
        {
            string texto = this.ToString();
            string archivo = "datos.txt";
            Texto fileManager = new Texto();

            return fileManager.Guardar(archivo, texto);
        }
        public string Leer()
        {
            string archivo = "datos.txt";
            Texto fileManager = new Texto();
            if (fileManager.Leer(archivo, out string datos))
                return datos;
            else
                throw new ArchivosException();
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

            sb.AppendLine("Instructor");
            sb.AppendLine(this.Instructor.ToString());
            sb.AppendLine("Clase");
            sb.AppendLine(this.Clase.ToString());
            sb.AppendLine("Alumnos");
            foreach(Alumno a in Alumnos)
                sb.AppendLine(a.ToString());

            return sb.ToString();
        }

    }
}
