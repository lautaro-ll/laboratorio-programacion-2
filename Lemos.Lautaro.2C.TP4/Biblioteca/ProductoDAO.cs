using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Biblioteca
{
    /// <summary>
    /// Establece los métodos para acceder a la base de datos 'Productos' y guardar, leer, modificar y borrar registros.
    /// </summary>
    public class ProductoDAO
    {
        private SqlConnection sqlConnection;
        string connectionString = "Server=.;Database=ProductosDB;Trusted_Connection=True;";
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ProductoDAO()
        {
            this.sqlConnection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// Guarda un producto en la base de datos Productos.
        /// </summary>
        /// <param name="producto"></param>
        public void Guardar(Producto producto)
        {
            try
            {
                string command = $"INSERT INTO Productos(descripcion, precio, cantidad) VALUES(@descripcion, @precio, @cantidad)";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("descripcion", producto.Descripcion);
                sqlCommand.Parameters.AddWithValue("precio", producto.Precio);
                sqlCommand.Parameters.AddWithValue("cantidad", producto.Cantidad);
                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
        }
        /// <summary>
        /// Lee una lista de productos de la base de datos Productos.
        /// </summary>
        /// <returns></returns>
        public List<Producto> Leer()
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                string command = $"SELECT * FROM Productos";

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Producto> personas = new List<Producto>();

                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string descripcion = (string)reader["descripcion"];
                    float precio = (float)((double)reader["precio"]);
                    int cantidad = (int)reader["cantidad"];


                    Producto producto = new Producto(id, descripcion, precio, cantidad);
                    personas.Add(producto);
                }
                if (sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }

                return personas;
            }
        }
        /// <summary>
        /// Modifica un producto de la base de datos Productos.
        /// Busca el id del producto ingresado como parametro en la base de datos y reescribe en ella la descripción, precio y cantidad.
        /// </summary>
        /// <param name="producto"></param>
        public void Modificar(Producto producto)
        {
            try
            {
                string command = $"UPDATE Productos SET descripcion = @descripcion, precio = @precio, cantidad = @cantidad WHERE id = @id";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("descripcion", producto.Descripcion);
                sqlCommand.Parameters.AddWithValue("precio", producto.Precio);
                sqlCommand.Parameters.AddWithValue("cantidad", producto.Cantidad);
                sqlCommand.Parameters.AddWithValue("id", producto.Id);
                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
        }
        /// <summary>
        /// Borra un producto (según su id) de la base de datos Productos.
        /// </summary>
        /// <param name="id"></param>
        public void Borrar(int id)
        {
            try
            {
                string command = $"DELETE FROM Productos WHERE id = @id";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", id);
                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
        }
    }
}
