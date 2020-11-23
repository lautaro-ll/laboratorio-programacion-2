namespace Lemos.Lautaro._2C.TP4
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numUDCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnVenta = new System.Windows.Forms.Button();
            this.btnAgregarAProduccion = new System.Windows.Forms.Button();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.dgStock = new System.Windows.Forms.DataGridView();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnQuitarDeProduccion = new System.Windows.Forms.Button();
            this.gbFabrica = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUDCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStock)).BeginInit();
            this.gbFabrica.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(6, 40);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(214, 21);
            this.cboCliente.TabIndex = 2;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad";
            // 
            // numUDCantidad
            // 
            this.numUDCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numUDCantidad.Location = new System.Drawing.Point(9, 84);
            this.numUDCantidad.Name = "numUDCantidad";
            this.numUDCantidad.Size = new System.Drawing.Size(60, 23);
            this.numUDCantidad.TabIndex = 4;
            this.numUDCantidad.ValueChanged += new System.EventHandler(this.numUDCantidad_ValueChanged);
            // 
            // btnVenta
            // 
            this.btnVenta.Location = new System.Drawing.Point(100, 70);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(120, 40);
            this.btnVenta.TabIndex = 5;
            this.btnVenta.Text = "Ingresar Venta";
            this.btnVenta.UseVisualStyleBackColor = true;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // btnAgregarAProduccion
            // 
            this.btnAgregarAProduccion.Location = new System.Drawing.Point(100, 107);
            this.btnAgregarAProduccion.Name = "btnAgregarAProduccion";
            this.btnAgregarAProduccion.Size = new System.Drawing.Size(120, 45);
            this.btnAgregarAProduccion.TabIndex = 6;
            this.btnAgregarAProduccion.Text = "Agregar a Producción";
            this.btnAgregarAProduccion.UseVisualStyleBackColor = true;
            this.btnAgregarAProduccion.Click += new System.EventHandler(this.btnAgregarAProduccion_Click);
            // 
            // tbPrecio
            // 
            this.tbPrecio.Location = new System.Drawing.Point(9, 81);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(211, 20);
            this.tbPrecio.TabIndex = 12;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(183, 65);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 11;
            this.lblPrecio.Text = "Precio";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(9, 42);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(211, 20);
            this.tbDescripcion.TabIndex = 10;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(157, 26);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 9;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // dgStock
            // 
            this.dgStock.AllowUserToAddRows = false;
            this.dgStock.AllowUserToDeleteRows = false;
            this.dgStock.AllowUserToResizeColumns = false;
            this.dgStock.AllowUserToResizeRows = false;
            this.dgStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgStock.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStock.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgStock.Location = new System.Drawing.Point(248, 9);
            this.dgStock.MultiSelect = false;
            this.dgStock.Name = "dgStock";
            this.dgStock.ReadOnly = true;
            this.dgStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStock.Size = new System.Drawing.Size(356, 430);
            this.dgStock.TabIndex = 10;
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(100, 116);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(120, 40);
            this.btnLog.TabIndex = 10;
            this.btnLog.Text = "Ver Log de Ventas";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnQuitarDeProduccion
            // 
            this.btnQuitarDeProduccion.Location = new System.Drawing.Point(100, 158);
            this.btnQuitarDeProduccion.Name = "btnQuitarDeProduccion";
            this.btnQuitarDeProduccion.Size = new System.Drawing.Size(120, 45);
            this.btnQuitarDeProduccion.TabIndex = 13;
            this.btnQuitarDeProduccion.Text = "Quitar de Producción";
            this.btnQuitarDeProduccion.UseVisualStyleBackColor = true;
            this.btnQuitarDeProduccion.Click += new System.EventHandler(this.btnQuitarDeProduccion_Click);
            // 
            // gbFabrica
            // 
            this.gbFabrica.BackColor = System.Drawing.Color.Azure;
            this.gbFabrica.Controls.Add(this.lblDescripcion);
            this.gbFabrica.Controls.Add(this.btnQuitarDeProduccion);
            this.gbFabrica.Controls.Add(this.tbDescripcion);
            this.gbFabrica.Controls.Add(this.tbPrecio);
            this.gbFabrica.Controls.Add(this.lblPrecio);
            this.gbFabrica.Controls.Add(this.btnAgregarAProduccion);
            this.gbFabrica.Location = new System.Drawing.Point(12, 12);
            this.gbFabrica.Name = "gbFabrica";
            this.gbFabrica.Size = new System.Drawing.Size(230, 231);
            this.gbFabrica.TabIndex = 14;
            this.gbFabrica.TabStop = false;
            this.gbFabrica.Text = "FÁBRICA";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboCliente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnLog);
            this.groupBox1.Controls.Add(this.numUDCantidad);
            this.groupBox1.Controls.Add(this.btnVenta);
            this.groupBox1.Location = new System.Drawing.Point(12, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 190);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LOCAL";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 448);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbFabrica);
            this.Controls.Add(this.dgStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de STOCK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUDCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStock)).EndInit();
            this.gbFabrica.ResumeLayout(false);
            this.gbFabrica.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUDCantidad;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnAgregarAProduccion;
        private System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.DataGridView dgStock;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnQuitarDeProduccion;
        private System.Windows.Forms.GroupBox gbFabrica;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

