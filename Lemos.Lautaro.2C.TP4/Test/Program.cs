using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;
using Excepciones;
using Archivos;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Cliente
            Console.WriteLine("\nTEST CLIENTE\n");

            List<Cliente> clientesAGuardar = new List<Cliente>();
            List<Cliente> clientesALeer = new List<Cliente>();
            try
            {
                Cliente cliente0 = new Cliente("Cliente con cuit invalido", 1);
            }
            catch (CuitInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Cliente cliente1 = new Cliente("Universidad teCNologica nacIONAL", 30546671166);
                clientesAGuardar.Add(cliente1);
                Cliente.Guardar(clientesAGuardar);
                clientesALeer = Cliente.Leer();
                foreach (Cliente c in clientesALeer)
                    Console.WriteLine(c.ToString());

            }
            catch (CuitInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArchivosException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("----");
            #endregion

            #region Producto
            Console.WriteLine("\nTEST PRODUCTO\n");

            Producto producto1 = new Producto("Producto UNO", 11, 100);
            Producto producto2 = new Producto(1, "Producto DOS", 22, 200);
            Console.WriteLine(producto1.ToString());
            Console.WriteLine(producto2.ToString());
            Console.WriteLine("----");
            #endregion

            #region Fabrica
            Console.WriteLine("\nTEST FÁBRICA\n");

            Fabrica fabrica = new Fabrica();
            fabrica.Activo = true;
            fabrica.EventoStock += EventoFabrica;

            void EventoFabrica()
            {
                Console.WriteLine("Se lanzó el evento de la fábrica (producción de un item).");
            }
            Console.ReadKey();
            fabrica.Activo = false;
            Console.WriteLine("Hilo de fábrica detenido.");
            Console.WriteLine("----");
            #endregion

            #region Log
            Console.WriteLine("\nTEST LOG\n");

            Log.Guardar("LOG: TEXTO DE PRUEBA");
            Console.WriteLine(Log.Leer());
            Console.WriteLine("----");
            #endregion

            #region ProductoDAO
            Console.WriteLine("\nTEST DATABASE\n");

            Producto producto3 = new Producto("Producto TRES", 33, 300);
            ProductoDAO productoDAO = new ProductoDAO();
            productoDAO.Guardar(producto3);

            List<Producto> productos = productoDAO.Leer();
            foreach (Producto p in productos)
                Console.WriteLine(p);
            Console.ReadKey();
            Console.WriteLine("");


            Producto productoModificado = productos[productos.Count - 1];
            productoModificado.Descripcion = "Producto TRES MODIFICADO";
            productoDAO.Modificar(productoModificado);

            productos = productoDAO.Leer();
            foreach (Producto p in productos)
                Console.WriteLine(p);
            Console.ReadKey();
            Console.WriteLine("");


            productoDAO.Borrar(productos[productos.Count - 1].Id);
            productos = productoDAO.Leer();
            foreach (Producto p in productos)
                Console.WriteLine(p);

            Console.WriteLine("----");
            #endregion

            Console.ReadKey();
        }
    }
}
