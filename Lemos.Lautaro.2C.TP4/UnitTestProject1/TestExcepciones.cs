using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;
using Excepciones;

namespace UnitTestExcepciones
{
    [TestClass]
    public class TestExcepciones
    {
        /// <summary>
        /// Verifica si al ingresar un cuit inválido se lanza la excepción CuitInvalidoException.
        /// </summary>
        [ExpectedException(typeof(CuitInvalidoException), "Un Cuit ingresado no contiene 8 caracteres.")]
        public void TestCuitInvalidoException()
        {
            Cliente cliente = new Cliente("Cliente de Prueba", 1235456);
        }
    }
}
