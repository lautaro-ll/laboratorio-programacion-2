﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Excepción que indica en su mensaje: "Alumno repetido."
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.") { }
    }
}
