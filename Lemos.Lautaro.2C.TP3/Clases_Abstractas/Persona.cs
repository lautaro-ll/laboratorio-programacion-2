using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//• Abstracta, con los atributos Nombre, Apellido, Nacionalidad y DNI.
//• Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y
//89999999 y Extranjero entre 90000000 y 99999999. Caso contrario, se lanzará la excepción NacionalidadInvalidaException.
//• Si el DNI presenta un error de formato (más caracteres de los permitidos, letras, etc.) se lanzará DniInvalidoException.
//• Sólo se realizarán las validaciones dentro de las propiedades.
//• Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
//• ToString retornará los datos de la Persona.

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero}

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        public Persona() { }
        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        protected Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        protected Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if ((dato > 0 && dato < 90000000 && nacionalidad == ENacionalidad.Argentino) || (dato >= 90000000 && dato <= 99999999 && nacionalidad == ENacionalidad.Extranjero))
                return dato;
            else
                throw new NacionalidadInvalidaException();
        }
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            if (int.TryParse(dato, out int dniParseado))
                return ValidarDNI(nacionalidad, dniParseado);
            else
                throw new NacionalidadInvalidaException();
        }
        private string ValidarNombreApellido(string dato)
        {
            if (!(string.IsNullOrWhiteSpace(dato) || dato.Length < 3))
                return dato;
            else
                throw new NacionalidadInvalidaException();
        }
        public string Nombre
        {
            get { return this.nombre; }
            set 
            {
                this.nombre = ValidarNombreApellido(value); 
            }
        }
        public string Apellido
        {
            get { return this.apellido; }
            set 
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        public int DNI
        {
            get { return this.dni; }
            set 
            {
                  this.dni = ValidarDNI(this.Nacionalidad, value); 
            }
        }
        public string StringToDNI
        {
            set 
            {
                this.DNI = ValidarDNI(this.Nacionalidad, value);
            }
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nombre");
            sb.AppendLine(this.Nombre);
            sb.AppendLine("Apellido");
            sb.AppendLine(this.Apellido);
            sb.AppendLine("DNI");
            sb.AppendLine(this.DNI.ToString());
            sb.AppendLine("Nacionalidad");
            sb.AppendLine(this.Nacionalidad.ToString());
        
            return sb.ToString();
    }
    }
}
