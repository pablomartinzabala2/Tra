namespace Concesionaria
{
    partial class FrmPagoCuentaProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPagoCuentaProveedor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.txtImporteCheque = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodCheque = new System.Windows.Forms.TextBox();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCodCuenta = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCuentaProveedor = new System.Windows.Forms.TextBox();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtConcepto);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Controls.Add(this.txtSaldo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtCodCuenta);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtCuentaProveedor);
            this.groupBox1.Controls.Add(this.dpFecha);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtProveedor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 508);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar Pago Cuenta Proveedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 86;
            this.label5.Text = "Concepto";
            // 
            // txtConcepto
            // 
            this.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Location = new System.Drawing.Point(119, 125);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(305, 23);
            this.txtConcepto.TabIndex = 85;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(42, 351);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(571, 115);
            this.tabControl1.TabIndex = 84;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPage1.Controls.Add(this.txtEfectivo);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(563, 86);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Efectivo";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Location = new System.Drawing.Point(63, 25);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(100, 23);
            this.txtEfectivo.TabIndex = 3;
            this.txtEfectivo.Leave += new System.EventHandler(this.txtEfectivo_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = " Monto";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(563, 86);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transferencia";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.btnAgregarCliente);
            this.tabPage3.Controls.Add(this.txtImporteCheque);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtCodCheque);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(563, 86);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cheque";
            // 
            // button2
            // 
            this.button2.Image = global::Concesionaria.Properties.Resources.carpeta;
            this.button2.Location = new System.Drawing.Point(237, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 29);
            this.button2.TabIndex = 85;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(454, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 29);
            this.button4.TabIndex = 84;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCliente.Image")));
            this.btnAgregarCliente.Location = new System.Drawing.Point(408, 13);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(40, 29);
            this.btnAgregarCliente.TabIndex = 83;
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Visible = false;
            // 
            // txtImporteCheque
            // 
            this.txtImporteCheque.Enabled = false;
            this.txtImporteCheque.Location = new System.Drawing.Point(131, 15);
            this.txtImporteCheque.Name = "txtImporteCheque";
            this.txtImporteCheque.Size = new System.Drawing.Size(100, 23);
            this.txtImporteCheque.TabIndex = 82;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 81;
            this.label6.Text = "Importe";
            // 
            // txtCodCheque
            // 
            this.txtCodCheque.BackColor = System.Drawing.Color.Red;
            this.txtCodCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodCheque.Location = new System.Drawing.Point(16, 15);
            this.txtCodCheque.Name = "txtCodCheque";
            this.txtCodCheque.Size = new System.Drawing.Size(51, 23);
            this.txtCodCheque.TabIndex = 80;
            this.txtCodCheque.Visible = false;
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(42, 198);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(558, 135);
            this.Grilla.TabIndex = 83;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(119, 154);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(100, 23);
            this.txtSaldo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo";
            // 
            // button1
            // 
            this.button1.Image = global::Concesionaria.Properties.Resources.email;
            this.button1.Location = new System.Drawing.Point(481, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 29);
            this.button1.TabIndex = 82;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.BackColor = System.Drawing.Color.Red;
            this.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodCuenta.Location = new System.Drawing.Point(306, 34);
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.Size = new System.Drawing.Size(71, 23);
            this.txtCodCuenta.TabIndex = 79;
            this.txtCodCuenta.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 77;
            this.label10.Text = "Cuenta";
            // 
            // txtCuentaProveedor
            // 
            this.txtCuentaProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCuentaProveedor.Location = new System.Drawing.Point(119, 66);
            this.txtCuentaProveedor.Name = "txtCuentaProveedor";
            this.txtCuentaProveedor.Size = new System.Drawing.Size(305, 23);
            this.txtCuentaProveedor.TabIndex = 76;
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(119, 37);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(87, 23);
            this.dpFecha.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Proveedor";
            // 
            // txtProveedor
            // 
            this.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProveedor.Location = new System.Drawing.Point(119, 95);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(305, 23);
            this.txtProveedor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(46, 465);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 37);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmPagoCuentaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 532);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPagoCuentaProveedor";
            this.Text = "FrmPagoCuentaProveedor";
            this.Load += new System.EventHandler(this.FrmPagoCuentaProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCodCuenta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCuentaProveedor;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtImporteCheque;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodCheque;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnAgregarCliente;
    }
}