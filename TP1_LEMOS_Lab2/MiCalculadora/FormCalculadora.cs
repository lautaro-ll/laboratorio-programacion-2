using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Inicializa el formulario, limpia el Label y setea las opciones del ComboBox.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            this.labelResultado.Text = string.Empty;
            comboBoxOperador.Items.Add("+");
            comboBoxOperador.Items.Add("-");
            comboBoxOperador.Items.Add("*");
            comboBoxOperador.Items.Add("/");
        }
        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        public void Limpiar()
        {
            this.textBoxNumero1.Text = string.Empty;
            this.textBoxNumero2.Text = string.Empty;
            this.labelResultado.Text = string.Empty;
            comboBoxOperador.SelectedIndex = -1;
        }
        /// <summary>
        /// Realiza la operación indicada llamando al método Operar de Calculadora.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public static double Operar(string numero1, string numero2, string operador)
        {
            Calculadora calc = new Calculadora();
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return calc.Operar(num1, num2, operador);
        }
        /// <summary>
        /// Valida que los datos ingresados sean números válidos y llama al método "Operar" para realizar la operación pedida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOperar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.textBoxNumero1.Text) || string.IsNullOrWhiteSpace(this.textBoxNumero2.Text) || string.IsNullOrWhiteSpace(this.comboBoxOperador.Text))
            {
                MessageBox.Show("Debe ingresar números válidos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double resultado = Math.Round(Operar(this.textBoxNumero1.Text, this.textBoxNumero2.Text, this.comboBoxOperador.Text), 10, MidpointRounding.AwayFromZero);
                if (resultado != double.MinValue)
                    this.labelResultado.Text = resultado.ToString();
                else
                    this.labelResultado.Text = "Valor Inválido";
            }
        }
        /// <summary>
        /// Llama al método "Limpiar" para borrar los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Convierte el resultado, de existir y ser posible, a decimal. Caso contrario mostrará un mensaje de error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            if (string.IsNullOrEmpty(this.labelResultado.Text))
            {
                MessageBox.Show("Debe existir un resultado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (double.TryParse(this.labelResultado.Text, out double resultado))
                {
                    this.labelResultado.Text = num.BinarioDecimal(resultado);
                }
                else
                    this.labelResultado.Text = "Valor Inválido";
            }
        }
        /// <summary>
        /// Convierte el resultado, de existir y ser posible, a binario. Caso contrario mostrará un mensaje de error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            if(string.IsNullOrWhiteSpace(this.labelResultado.Text))
            {
                MessageBox.Show("Debe existir un resultado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string resultado = num.DecimalBinario(this.labelResultado.Text);
                if (resultado.Length>30)
                    resultado = "Resultado fuera de rango";
                this.labelResultado.Text = resultado;
            }
        }
    }
}
