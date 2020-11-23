using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;
using Archivos;
using System.Threading;
using MetodoDeExtension;
using Excepciones;

namespace Lemos.Lautaro._2C.TP4
{
    public partial class FormPrincipal : Form
    {
        private List<Cliente> clientes;
        private List<Producto> productos;
        private ProductoDAO productoDAO;
        private Fabrica fabrica;
        private static Random random;
        private Thread hiloListado;
        private float totalIngresoDeJornada;
        delegate void Callback();

        /// <summary>
        /// Inicializa la variable random.
        /// </summary>
        static FormPrincipal()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor por defecto.
        /// Inicializa las variables de FormPrincipal.
        /// </summary>
        public FormPrincipal()
        {
            InitializeComponent();
            btnVenta.Enabled = false;
            clientes = new List<Cliente>();
            productos = new List<Producto>();
            productoDAO = new ProductoDAO();
            fabrica = new Fabrica();
            fabrica.EventoStock += Fabrica_EventoStock;
            hiloListado = new Thread(actualizarInfo);
            hiloListado.Start();
        }
        /// <summary>
        /// Inicia el hilo de fabrica y carga las listas de clientes y productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                fabrica.Activo = true;
                if(!object.ReferenceEquals(Cliente.Leer(), null))
                    clientes = Cliente.Leer();
                else
                {
                    Cliente cliente = new Cliente("UNIVERSIDAD TECNOLOGICA NACIONAL", 30546671166);
                    clientes.Add(cliente);
                    cliente = new Cliente("MERCADOLIBRE S.R.L.", 30703088534);
                    clientes.Add(cliente);
                    cliente = new Cliente("GOOGLE ARGENTINA S.R.L.", 33709585229);
                    clientes.Add(cliente);
                }
                foreach (Cliente c in clientes)
                {
                    cboCliente.Items.Add(c);
                }
                productos = productoDAO.Leer();
                dgStock.DataSource = productos;
                Log.Guardar($"\n*************************************************************************************" +
                            $"\n{DateTime.Now.ToString("dd/MM/yy HH:mm")} - INICIO DE JORNADA" +
                            $"\n-------------------------------------------------------------------------------------");
            }
            catch (CuitInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Evento de fábrica, selecciona un producto random de la lista y le incrementa el stock en uno.
        /// </summary>
        private void Fabrica_EventoStock()
        {
            try
            {
                if (productos != null && productos.Count > 0)
                {
                    Producto producto = productos[random.Next(0, productos.Count)];
                    producto.Cantidad++;
                    productoDAO.Modificar(producto);
                    productos = productoDAO.Leer();
                }
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Agrega el producto ingresado en los textbox correspondientes, a la base de datos y actualiza la información.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarAProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tbDescripcion.Text) && !string.IsNullOrWhiteSpace(tbPrecio.Text) && float.TryParse(tbPrecio.Text, out float precio) && precio > 0)
                {
                    Producto producto = new Producto(tbDescripcion.Text.FormatearTexto(), precio, 0);
                    productoDAO.Guardar(producto);
                    productos = productoDAO.Leer();
                    dgStock.DataSource = productos;
                }
                else
                    MessageBox.Show("Descripción o Precio Inválidos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Quita de la base de datos el producto seleccionado y actualiza la información.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitarDeProduccion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"¿Desea quitar de producción el producto {((Producto)dgStock.CurrentRow.DataBoundItem).Descripcion}?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes && dgStock.CurrentRow.DataBoundItem != null)
            {
                productoDAO.Borrar(((Producto)dgStock.CurrentRow.DataBoundItem).Id);
                productos = productoDAO.Leer();
                dgStock.DataSource = productos;
            }
        }
        /// <summary>
        /// Efectúa la venta indicada, la registra en el log y muestra un messagebox con la información.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVenta_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = (Producto)dgStock.CurrentRow.DataBoundItem;
                producto.Cantidad = producto.Cantidad - (int)numUDCantidad.Value;
                productoDAO.Modificar(producto);
                totalIngresoDeJornada += producto.Precio * (int)numUDCantidad.Value;

                Log.Guardar($"{DateTime.Now.ToString("dd/MM/yy HH:mm")} - Venta de {numUDCantidad.Value} unidades de {producto.Descripcion} a {((Cliente)cboCliente.SelectedItem).RazonSocial}," +
                    $" CUIT: {((Cliente)cboCliente.SelectedItem).Cuit} - Ingreso de ${producto.Precio * (int)numUDCantidad.Value}");
                MessageBox.Show($"CLIENTE: {((Cliente)cboCliente.SelectedItem).RazonSocial}\nCUIT: {((Cliente)cboCliente.SelectedItem).Cuit}\nPRODUCTO: {producto.Descripcion}\n" +
                    $"UNIDADES: {numUDCantidad.Value}\nINGRESO: ${producto.Precio * (int)numUDCantidad.Value}", "VENTA REGISTRADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Muestra un Form con el log de ventas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                FormLogVentas formLogVentas = new FormLogVentas(Log.Leer());
                formLogVentas.ShowDialog();
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void numUDCantidad_ValueChanged(object sender, EventArgs e)
        {
            habilitaVenta();
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            habilitaVenta();
        }
        /// <summary>
        /// Valida si debe habilitarse el botón de venta.
        /// Debe haber un cliente seleccionado, un producto seleccionado y stock disponible del mismo.
        /// </summary>
        private void habilitaVenta()
        {
            btnVenta.Enabled = (dgStock.CurrentRow.DataBoundItem != null && ((Producto)dgStock.CurrentRow.DataBoundItem).Cantidad >= numUDCantidad.Value && numUDCantidad.Value > 0 && cboCliente.SelectedItem != null);
        }
        /// <summary>
        /// Actualiza la lista de productos.
        /// </summary>
        private void refrescarLista()
        {
            if (dgStock.InvokeRequired)
            {
                Callback d = new Callback(this.refrescarLista);
                this.Invoke(d);
            }
            else
            {
                int index = -1;
                if (dgStock.CurrentCell != null)
                    index = dgStock.CurrentCell.RowIndex;
                dgStock.DataSource = productos;
                if (index != -1)
                    dgStock.CurrentCell = dgStock.Rows[index].Cells[0];
            }
        }
        /// <summary>
        /// Define un tiempo de demora entre actualizaciones de la lista y actualiza la misma.
        /// </summary>
        private void actualizarInfo()
        {
            while(true)
            {
                refrescarLista();
                Thread.Sleep(1000);
            }
        }
        /// <summary>
        /// Cierra los hilos abiertos y guarda en log la finalización de la jornada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                fabrica.Activo = false;
                if (hiloListado.IsAlive)
                    hiloListado.Abort();
                Cliente.Guardar(clientes);
                Log.Guardar($"\n-------------------------------------------------------------------------------------" +
                            $"\n{DateTime.Now.ToString("dd/MM/yy HH:mm")} - INGRESO TOTAL DE LA JORNADA: ${totalIngresoDeJornada}" +
                            $"\n*************************************************************************************");
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
