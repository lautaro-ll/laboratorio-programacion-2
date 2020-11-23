using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lemos.Lautaro._2C.TP4
{
    public partial class FormLogVentas : Form
    {
        /// <summary>
        /// Constructor de FormLogVentas.
        /// Muestra el texto ingresado como parametro en la caja de texto.
        /// </summary>
        /// <param name="texto"></param>
        public FormLogVentas(string texto)
        {
            InitializeComponent();
            rtbLog.Text = texto;
        }
    }
}
