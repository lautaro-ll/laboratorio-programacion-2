using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//• Atributos Alumnos(lista de inscriptos), Profesores(lista de quienes pueden dar clases) y Jornadas.
//• Se accederá a una Jornada específica a través de un indexador.
//• Un Universidad será igual a un Alumno si el mismo está inscripto en él.
//• Un Universidad será igual a un Profesor si el mismo está dando clases en él.
//• Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, un Profesor que pueda darla (según su atributo ClasesDelDia) 
//    y la lista de alumnos que la toman (todos los que coincidan en su campo ClaseQueToma).
//• Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
//• La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. Sino, lanzará la Excepción SinProfesorException. El distinto retornará el primer Profesor que no pueda dar la clase.
//• Si al querer agregar alumnos este ya figura en la lista, lanzar la excepción AlumnoRepetidoException.
//• MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante ToString.
//• Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
//• Leer de clase retornará un Universidad con todos los datos previamente serializados.

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }
        public List<Jornada> Jornada
        {
            get { return jornada; }
            set { jornada = value; }
        }
        public List<Profesor> Profesores
        {
            get { return profesores; }
            set { profesores = value; }
        }
        public Jornada this[int i]
        {
            get { return jornada[i]; }
            set { jornada[i] = value; }
        }
        public Universidad() 
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        public bool Guardar(Universidad uni)
        {
            return true;
        }
        public Universidad Leer()
        {
            return null;
        }
        private string MostrarDatos(Universidad uni)
        {
            return "";
        }
        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.Alumnos.Contains(a);
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.Profesores.Contains(i);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            return null;
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            return !(u == eClase);
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = null;
            try
            {
                foreach(Profesor p in g.Profesores)
                {
                    if(p == clase)
                    {
                        profesor = p;
                        break;
                    }
                }
                if (profesor.Equals(null))
                    throw new SinProfesorException();
                Jornada jornada = new Jornada(clase, profesor);
                foreach(Alumno a in g.Alumnos)
                {
                    if(a == clase)
                    {
                        g.Alumnos.Add(a);
                    }
                }
            }
            catch (SinProfesorException ex)
            {
                Console.WriteLine($"Excepcion {ex.Message}");
            }
            return g;
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            return null;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            return null;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
