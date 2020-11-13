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

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero}

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        /// <summary>
        /// Constructor por defecto de clase Persona
        /// </summary>
        public Persona() { }
        /// <summary>
        /// Constructor de clase Persona con parametros nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor de clase Persona con parametros nombre, apellido, dni (como nro. entero) y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        protected Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Constructor de clase Persona con parametros nombre, apellido, dni (como texto) y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        protected Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        /// <summary>
        /// Valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y 89999999 y Extranjero entre 90000000 y 99999999. Caso contrario, se lanzará la excepción NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad">enum ENacionalidad</param>
        /// <param name="dato">dni como entero</param>
        /// <returns>dni validado</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if ((dato > 0 && dato < 90000000 && nacionalidad == ENacionalidad.Argentino) || (dato >= 90000000 && dato <= 99999999 && nacionalidad == ENacionalidad.Extranjero))
                return dato;
            else if (dato < 0 || dato > 99999999)
                throw new DniInvalidoException();
            else
                throw new NacionalidadInvalidaException();
        }
        /// <summary>
        /// Valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y 89999999 y Extranjero entre 90000000 y 99999999. Caso contrario, se lanzará la excepción NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad">enum ENacionalidad</param>
        /// <param name="dato">dni como cadena de texto</param>
        /// <returns>dni validado</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            if (int.TryParse(dato, out int dniParseado))
                return ValidarDNI(nacionalidad, dniParseado);
            else
                throw new DniInvalidoException();
        }
        /// <summary>
        /// Valida que el nombre o apellido tenga más de dos caracteres
        /// </summary>
        /// <param name="dato">cadena a validar</param>
        /// <returns>dato validado</returns>
        private string ValidarNombreApellido(string dato)
        {
            if (!(string.IsNullOrWhiteSpace(dato) || dato.Length < 3))
                return dato;
            else
                throw new NacionalidadInvalidaException();
        }
        /// <summary>
        /// Propiedad getter y setter de nombre. Valida el mismo.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set 
            {
                this.nombre = ValidarNombreApellido(value); 
            }
        }
        /// <summary>
        /// Propiedad getter y setter de apellido. Valida el mismo.
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set 
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad getter y setter de nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        /// <summary>
        /// Propiedad getter y setter de dni. Valida el mismo.
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set 
            {
                  this.dni = ValidarDNI(this.Nacionalidad, value); 
            }
        }
        /// <summary>
        /// Propiedad setter de dni como cadena. Valida el mismo.
        /// </summary>
        public string StringToDNI
        {
            set 
            {
                this.DNI = ValidarDNI(this.Nacionalidad, value);
            }
        }
        /// <summary>
        /// Carga los datos de Persona en una cadena
        /// </summary>
        /// <returns>retorna la cadena con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            sb.Append($"NACIONALIDAD: {this.Nacionalidad.ToString()}");
        
            return sb.ToString();
    }
    }
}
