using System;
using Clases_Instanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TestDNI
    {
        [TestMethod]
        public void ExcepcionDNIInvalidoOK()
        {
            //arrange
            string nombre = "Lautaro";
            string apellido = "Lemos";
            string dni = "1";
            Alumno alumno = new Alumno(1, nombre, apellido, dni, EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

            //act
            //assert
            Assert.ThrowsException<DniInvalidoException>(() => alumno.DNI = -20);
        }

        [TestMethod]
        public void ExcepcionNacionalidadInvalidadOK()
        {
            //arrange
            string nombre = "Lautaro";
            string apellido = "Lemos";
            string dni = "1";
            Alumno alumno = new Alumno(1, nombre, apellido, dni, EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

            //act
            //assert
            Assert.ThrowsException<NacionalidadInvalidaException>(() => alumno.DNI = 99999999);
        }

    }
}
