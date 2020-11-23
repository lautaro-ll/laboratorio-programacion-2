using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Biblioteca
{
    /// <summary>
    /// Simula la producción de la fábrica mediante un hilo y un tiempo random de velocidad de producción.
    /// Cuando se lanza el evento EventoStock se debe agregar un producto al stock.
    /// </summary>
    public delegate void encargadoStock();
    public class Fabrica
    {
        private Thread hiloFabrica;
        public event encargadoStock EventoStock;
        private static Random random;
        private const int velocidadDeProduccion = 1000;
        /// <summary>
        /// Inicializa la variable random.
        /// </summary>
        static Fabrica()
        {
            random = new Random();
        }
        /// <summary>
        /// Genera tiempos random en milisegundos.
        /// </summary>
        /// <returns></returns>
        private int randomTime()
        {
            return velocidadDeProduccion * random.Next(2, 5);
        }
        /// <summary>
        /// true: inicia el thread de Fabrica si no está activo.
        /// false: detiene el thread si está activo.
        /// </summary>
        public bool Activo
        {
            get { return hiloFabrica.IsAlive; }
            set
            {
                if (value == true)
                {
                    if (object.ReferenceEquals(hiloFabrica, null))
                        hiloFabrica = new Thread(Run);
                    if (!hiloFabrica.IsAlive)
                        hiloFabrica.Start();
                }
                else if (hiloFabrica.IsAlive)
                {
                    hiloFabrica.Abort();
                }
            }
        }
        /// <summary>
        /// Aguarda un tiempo random y lanza eventoStock.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Thread.Sleep(randomTime());
                EventoStock();
            }
        }
    }
}
