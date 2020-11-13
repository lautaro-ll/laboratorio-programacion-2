using System;
using Clases_Instanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class TestInstancia
    {
        [TestMethod]
        public void InstanciaProfesorOK()
        {
            //Arrange
            //Act
            Profesor profesor = new Profesor(1, "Juan", "Lopez", "12224458", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            //Assert
            Assert.IsNotNull(profesor);

        }
    }
}
