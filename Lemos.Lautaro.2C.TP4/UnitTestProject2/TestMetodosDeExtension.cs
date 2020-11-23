using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetodoDeExtension;

namespace UnitTestExtension
{
    [TestClass]
    public class TestMetodosDeExtension
    {
        /// <summary>
        /// Verifica si el método de extensión FormatearTexto funciona correctamente.
        /// </summary>
        [TestMethod]
        public void TestFormatearTexto()
        {
            string texto = "   pRoDucto MáGICO ";
            string textoFormateado = texto.FormatearTexto();
            string textoEsperado = "Producto mágico";
            Assert.IsTrue(textoEsperado == textoFormateado);
        }
    }
}
