using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
        {
            Console.WriteLine(this.Message);
        }
        public NacionalidadInvalidaException(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
}
