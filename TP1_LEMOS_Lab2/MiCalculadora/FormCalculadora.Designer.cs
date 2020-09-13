namespace MiCalculadora
{
    partial class FormCalculadora
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
            this.labelResultado = new System.Windows.Forms.Label();
            this.textBoxNumero1 = new System.Windows.Forms.TextBox();
            this.comboBoxOperador = new System.Windows.Forms.ComboBox();
            this.textBoxNumero2 = new System.Windows.Forms.TextBox();
            this.buttonOperar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.buttonConvertirABinario = new System.Windows.Forms.Button();
            this.buttonConvertirADecimal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelResultado
            // 
            this.labelResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultado.Location = new System.Drawing.Point(25, 9);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(240, 13);
            this.labelResultado.TabIndex = 0;
            this.labelResultado.Text = "Resultado";
            this.labelResultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxNumero1
            // 
            this.textBoxNumero1.Location = new System.Drawing.Point(28, 35);
            this.textBoxNumero1.Name = "textBoxNumero1";
            this.textBoxNumero1.Size = new System.Drawing.Size(75, 20);
            this.textBoxNumero1.TabIndex = 1;
            // 
            // comboBoxOperador
            // 
            this.comboBoxOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperador.Location = new System.Drawing.Point(109, 34);
            this.comboBoxOperador.Name = "comboBoxOperador";
            this.comboBoxOperador.Size = new System.Drawing.Size(75, 21);
            this.comboBoxOperador.TabIndex = 2;
            // 
            // textBoxNumero2
            // 
            this.textBoxNumero2.Location = new System.Drawing.Point(190, 34);
            this.textBoxNumero2.Name = "textBoxNumero2";
            this.textBoxNumero2.Size = new System.Drawing.Size(75, 20);
            this.textBoxNumero2.TabIndex = 3;
            // 
            // buttonOperar
            // 
            this.buttonOperar.Location = new System.Drawing.Point(28, 62);
            this.buttonOperar.Name = "buttonOperar";
            this.buttonOperar.Size = new System.Drawing.Size(75, 23);
            this.buttonOperar.TabIndex = 4;
            this.buttonOperar.Text = "Operar";
            this.buttonOperar.UseVisualStyleBackColor = true;
            this.buttonOperar.Click += new System.EventHandler(this.buttonOperar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(109, 61);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 5;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(190, 61);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrar.TabIndex = 6;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // buttonConvertirABinario
            // 
            this.buttonConvertirABinario.Location = new System.Drawing.Point(28, 90);
            this.buttonConvertirABinario.Name = "buttonConvertirABinario";
            this.buttonConvertirABinario.Size = new System.Drawing.Size(113, 23);
            this.buttonConvertirABinario.TabIndex = 7;
            this.buttonConvertirABinario.Text = "Convertir a Binario";
            this.buttonConvertirABinario.UseVisualStyleBackColor = true;
            this.buttonConvertirABinario.Click += new System.EventHandler(this.buttonConvertirABinario_Click);
            // 
            // buttonConvertirADecimal
            // 
            this.buttonConvertirADecimal.Location = new System.Drawing.Point(147, 90);
            this.buttonConvertirADecimal.Name = "buttonConvertirADecimal";
            this.buttonConvertirADecimal.Size = new System.Drawing.Size(118, 23);
            this.buttonConvertirADecimal.TabIndex = 8;
            this.buttonConvertirADecimal.Text = "Convertir a Decimal";
            this.buttonConvertirADecimal.UseVisualStyleBackColor = true;
            this.buttonConvertirADecimal.Click += new System.EventHandler(this.buttonConvertirADecimal_Click);
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 131);
            this.Controls.Add(this.buttonConvertirADecimal);
            this.Controls.Add(this.buttonConvertirABinario);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonOperar);
            this.Controls.Add(this.textBoxNumero2);
            this.Controls.Add(this.comboBoxOperador);
            this.Controls.Add(this.textBoxNumero1);
            this.Controls.Add(this.labelResultado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Lautaro Lemos del curso 2°C";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelResultado;
        private System.Windows.Forms.TextBox textBoxNumero1;
        private System.Windows.Forms.TextBox textBoxNumero2;
        private System.Windows.Forms.Button buttonOperar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Button buttonConvertirABinario;
        private System.Windows.Forms.Button buttonConvertirADecimal;
        private System.Windows.Forms.ComboBox comboBoxOperador;
    }
}