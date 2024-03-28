namespace Concesionaria
{
    partial class FrmIngresoCaja
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
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.txtEgresos = new System.Windows.Forms.TextBox();
            this.txtIngresos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.btnBuscarVehiculo = new System.Windows.Forms.Button();
            this.txtCodStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVehiculo = new System.Windows.Forms.TextBox();
            this.btnAnular = new System.Windows.Forms.Button();
            this.cmbTipoIngresoEgreso = new System.Windows.Forms.ComboBox();
            this.txtCodCuenta = new System.Windows.Forms.TextBox();
            this.btnBuscarCuenta = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCuentaProveedor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbTipoMov = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.btnDetalle);
            this.Grupo.Controls.Add(this.btnImprimir);
            this.Grupo.Controls.Add(this.txtSaldo);
            this.Grupo.Controls.Add(this.txtEgresos);
            this.Grupo.Controls.Add(this.txtIngresos);
            this.Grupo.Controls.Add(this.label7);
            this.Grupo.Controls.Add(this.label8);
            this.Grupo.Controls.Add(this.label9);
            this.Grupo.Controls.Add(this.txtPatente);
            this.Grupo.Controls.Add(this.btnBuscarVehiculo);
            this.Grupo.Controls.Add(this.txtCodStock);
            this.Grupo.Controls.Add(this.label6);
            this.Grupo.Controls.Add(this.txtVehiculo);
            this.Grupo.Controls.Add(this.btnAnular);
            this.Grupo.Controls.Add(this.cmbTipoIngresoEgreso);
            this.Grupo.Controls.Add(this.txtCodCuenta);
            this.Grupo.Controls.Add(this.btnBuscarCuenta);
            this.Grupo.Controls.Add(this.label10);
            this.Grupo.Controls.Add(this.txtCuentaProveedor);
            this.Grupo.Controls.Add(this.label5);
            this.Grupo.Controls.Add(this.txtProveedor);
            this.Grupo.Controls.Add(this.btnBuscar);
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Controls.Add(this.label4);
            this.Grupo.Controls.Add(this.txtImporte);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.CmbTipoMov);
            this.Grupo.Controls.Add(this.btnGuardar);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.dpFechaHasta);
            this.Grupo.Controls.Add(this.txtConcepto);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(21, 21);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(937, 465);
            this.Grupo.TabIndex = 14;
            this.Grupo.TabStop = false;
            this.Grupo.Text = "Información de ingreso y egreso de caja";
            // 
            // btnDetalle
            // 
            this.btnDetalle.Image = global::Concesionaria.Properties.Resources.Compra;
            this.btnDetalle.Location = new System.Drawing.Point(661, 185);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(40, 27);
            this.btnDetalle.TabIndex = 101;
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::Concesionaria.Properties.Resources.printer;
            this.btnImprimir.Location = new System.Drawing.Point(704, 180);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(45, 28);
            this.btnImprimir.TabIndex = 100;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(816, 425);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(100, 23);
            this.txtSaldo.TabIndex = 99;
            // 
            // txtEgresos
            // 
            this.txtEgresos.Location = new System.Drawing.Point(652, 425);
            this.txtEgresos.Name = "txtEgresos";
            this.txtEgresos.Size = new System.Drawing.Size(100, 23);
            this.txtEgresos.TabIndex = 98;
            // 
            // txtIngresos
            // 
            this.txtIngresos.Location = new System.Drawing.Point(474, 425);
            this.txtIngresos.Name = "txtIngresos";
            this.txtIngresos.Size = new System.Drawing.Size(100, 23);
            this.txtIngresos.TabIndex = 97;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(766, 428);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 96;
            this.label7.Text = "Saldo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(580, 428);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 95;
            this.label8.Text = "Egresos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(397, 428);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 17);
            this.label9.TabIndex = 94;
            this.label9.Text = "Ingresos";
            // 
            // txtPatente
            // 
            this.txtPatente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtPatente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPatente.Enabled = false;
            this.txtPatente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatente.Location = new System.Drawing.Point(640, 63);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(89, 23);
            this.txtPatente.TabIndex = 93;
            this.txtPatente.Visible = false;
            // 
            // btnBuscarVehiculo
            // 
            this.btnBuscarVehiculo.Image = global::Concesionaria.Properties.Resources.carpeta;
            this.btnBuscarVehiculo.Location = new System.Drawing.Point(587, 33);
            this.btnBuscarVehiculo.Name = "btnBuscarVehiculo";
            this.btnBuscarVehiculo.Size = new System.Drawing.Size(43, 29);
            this.btnBuscarVehiculo.TabIndex = 92;
            this.btnBuscarVehiculo.UseVisualStyleBackColor = true;
            this.btnBuscarVehiculo.Click += new System.EventHandler(this.btnBuscarVehiculo_Click);
            // 
            // txtCodStock
            // 
            this.txtCodStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtCodStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodStock.Enabled = false;
            this.txtCodStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodStock.Location = new System.Drawing.Point(587, 67);
            this.txtCodStock.Name = "txtCodStock";
            this.txtCodStock.Size = new System.Drawing.Size(47, 23);
            this.txtCodStock.TabIndex = 91;
            this.txtCodStock.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 90;
            this.label6.Text = "Vehículo";
            // 
            // txtVehiculo
            // 
            this.txtVehiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVehiculo.Enabled = false;
            this.txtVehiculo.Location = new System.Drawing.Point(334, 38);
            this.txtVehiculo.Name = "txtVehiculo";
            this.txtVehiculo.Size = new System.Drawing.Size(247, 23);
            this.txtVehiculo.TabIndex = 89;
            // 
            // btnAnular
            // 
            this.btnAnular.Location = new System.Drawing.Point(580, 181);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(75, 33);
            this.btnAnular.TabIndex = 88;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // cmbTipoIngresoEgreso
            // 
            this.cmbTipoIngresoEgreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIngresoEgreso.FormattingEnabled = true;
            this.cmbTipoIngresoEgreso.Location = new System.Drawing.Point(311, 183);
            this.cmbTipoIngresoEgreso.Name = "cmbTipoIngresoEgreso";
            this.cmbTipoIngresoEgreso.Size = new System.Drawing.Size(178, 24);
            this.cmbTipoIngresoEgreso.TabIndex = 87;
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodCuenta.Enabled = false;
            this.txtCodCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCuenta.Location = new System.Drawing.Point(735, 60);
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.Size = new System.Drawing.Size(47, 23);
            this.txtCodCuenta.TabIndex = 86;
            this.txtCodCuenta.Visible = false;
            this.txtCodCuenta.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnBuscarCuenta
            // 
            this.btnBuscarCuenta.Image = global::Concesionaria.Properties.Resources.carpeta;
            this.btnBuscarCuenta.Location = new System.Drawing.Point(580, 141);
            this.btnBuscarCuenta.Name = "btnBuscarCuenta";
            this.btnBuscarCuenta.Size = new System.Drawing.Size(43, 34);
            this.btnBuscarCuenta.TabIndex = 85;
            this.btnBuscarCuenta.UseVisualStyleBackColor = true;
            this.btnBuscarCuenta.Click += new System.EventHandler(this.btnBuscarCuenta_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(313, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 84;
            this.label10.Text = "Cuenta";
            // 
            // txtCuentaProveedor
            // 
            this.txtCuentaProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCuentaProveedor.Location = new System.Drawing.Point(382, 155);
            this.txtCuentaProveedor.Name = "txtCuentaProveedor";
            this.txtCuentaProveedor.Size = new System.Drawing.Size(178, 23);
            this.txtCuentaProveedor.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 82;
            this.label5.Text = "Proveedor";
            // 
            // txtProveedor
            // 
            this.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProveedor.Location = new System.Drawing.Point(127, 152);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(178, 23);
            this.txtProveedor.TabIndex = 81;
            this.txtProveedor.TextChanged += new System.EventHandler(this.txtProveedor_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Concesionaria.Properties.Resources.zoom2;
            this.btnBuscar.Location = new System.Drawing.Point(220, 34);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(40, 27);
            this.btnBuscar.TabIndex = 80;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(28, 220);
            this.Grilla.Name = "Grilla";
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(888, 189);
            this.Grilla.TabIndex = 79;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 78;
            this.label4.Text = "Importe";
            // 
            // txtImporte
            // 
            this.txtImporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImporte.Location = new System.Drawing.Point(127, 183);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(178, 23);
            this.txtImporte.TabIndex = 77;
            this.txtImporte.Leave += new System.EventHandler(this.txtImporte_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 76;
            this.label3.Text = "Tipo";
            // 
            // CmbTipoMov
            // 
            this.CmbTipoMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoMov.FormattingEnabled = true;
            this.CmbTipoMov.Location = new System.Drawing.Point(127, 119);
            this.CmbTipoMov.Name = "CmbTipoMov";
            this.CmbTipoMov.Size = new System.Drawing.Size(110, 24);
            this.CmbTipoMov.TabIndex = 75;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(499, 182);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 32);
            this.btnGuardar.TabIndex = 74;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 73;
            this.label2.Text = "Fecha";
            // 
            // dpFechaHasta
            // 
            this.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaHasta.Location = new System.Drawing.Point(127, 38);
            this.dpFechaHasta.Name = "dpFechaHasta";
            this.dpFechaHasta.Size = new System.Drawing.Size(87, 23);
            this.dpFechaHasta.TabIndex = 72;
            // 
            // txtConcepto
            // 
            this.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Location = new System.Drawing.Point(127, 67);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(454, 46);
            this.txtConcepto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Concepto";
            // 
            // FrmIngresoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(970, 498);
            this.Controls.Add(this.Grupo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmIngresoCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de Caja";
            this.Load += new System.EventHandler(this.FrmIngresoCaja_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpFechaHasta;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox CmbTipoMov;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCuentaProveedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Button btnBuscarCuenta;
        private System.Windows.Forms.TextBox txtCodCuenta;
        private System.Windows.Forms.ComboBox cmbTipoIngresoEgreso;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnBuscarVehiculo;
        private System.Windows.Forms.TextBox txtCodStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVehiculo;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.TextBox txtEgresos;
        private System.Windows.Forms.TextBox txtIngresos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnDetalle;
    }
}