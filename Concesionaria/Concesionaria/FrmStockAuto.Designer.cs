namespace Concesionaria
{
    partial class FrmStockAuto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockAuto));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.BtnVerGanancia = new System.Windows.Forms.Button();
            this.btnAplicarIncremento = new System.Windows.Forms.Button();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbOrden = new System.Windows.Forms.ComboBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnBajaStock = new System.Windows.Forms.Button();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.txtTotalVehiculos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reporteAutoTableAdapter1 = new Concesionaria.CONCESIONARIADataSetTableAdapters.ReporteAutoTableAdapter();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEstadoFacturacion = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEstadoFacturacion);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnExportarExcel);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.BtnVerGanancia);
            this.groupBox1.Controls.Add(this.btnAplicarIncremento);
            this.groupBox1.Controls.Add(this.txtPorcentaje);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CmbEstado);
            this.groupBox1.Controls.Add(this.cmbOrden);
            this.groupBox1.Controls.Add(this.txtModelo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.btnBajaStock);
            this.groupBox1.Controls.Add(this.txtMontoTotal);
            this.groupBox1.Controls.Add(this.txtTotalVehiculos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbMarca);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtPatente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1154, 523);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Autos en Stock";
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(449, 55);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(40, 27);
            this.btnExportarExcel.TabIndex = 80;
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(1036, 22);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(40, 27);
            this.btnExcel.TabIndex = 79;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // BtnVerGanancia
            // 
            this.BtnVerGanancia.Image = global::Concesionaria.Properties.Resources.Linterna;
            this.BtnVerGanancia.Location = new System.Drawing.Point(990, 22);
            this.BtnVerGanancia.Name = "BtnVerGanancia";
            this.BtnVerGanancia.Size = new System.Drawing.Size(40, 27);
            this.BtnVerGanancia.TabIndex = 78;
            this.BtnVerGanancia.UseVisualStyleBackColor = true;
            this.BtnVerGanancia.Click += new System.EventHandler(this.BtnVerGanancia_Click);
            // 
            // btnAplicarIncremento
            // 
            this.btnAplicarIncremento.Location = new System.Drawing.Point(358, 55);
            this.btnAplicarIncremento.Name = "btnAplicarIncremento";
            this.btnAplicarIncremento.Size = new System.Drawing.Size(85, 30);
            this.btnAplicarIncremento.TabIndex = 77;
            this.btnAplicarIncremento.Text = "Aplicar";
            this.btnAplicarIncremento.UseVisualStyleBackColor = true;
            this.btnAplicarIncremento.Click += new System.EventHandler(this.btnAplicarIncremento_Click);
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPorcentaje.Location = new System.Drawing.Point(248, 59);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(104, 23);
            this.txtPorcentaje.TabIndex = 76;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(236, 17);
            this.label7.TabIndex = 75;
            this.label7.Text = "Porcentaje de aumento por Inflación";
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sel});
            this.Grilla.Location = new System.Drawing.Point(6, 88);
            this.Grilla.Name = "Grilla";
            this.Grilla.Size = new System.Drawing.Size(1125, 387);
            this.Grilla.TabIndex = 74;
            // 
            // Sel
            // 
            this.Sel.HeaderText = "Sel";
            this.Sel.Name = "Sel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(588, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 60;
            this.label6.Text = "Estado";
            // 
            // CmbEstado
            // 
            this.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Location = new System.Drawing.Point(644, 27);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(142, 24);
            this.CmbEstado.TabIndex = 59;
            // 
            // cmbOrden
            // 
            this.cmbOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrden.FormattingEnabled = true;
            this.cmbOrden.Location = new System.Drawing.Point(792, 27);
            this.cmbOrden.Name = "cmbOrden";
            this.cmbOrden.Size = new System.Drawing.Size(72, 24);
            this.cmbOrden.TabIndex = 58;
            // 
            // txtModelo
            // 
            this.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModelo.Location = new System.Drawing.Point(418, 26);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(164, 23);
            this.txtModelo.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "Modelo";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::Concesionaria.Properties.Resources.printer1;
            this.btnImprimir.Location = new System.Drawing.Point(950, 22);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(34, 30);
            this.btnImprimir.TabIndex = 55;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnBajaStock
            // 
            this.btnBajaStock.Location = new System.Drawing.Point(1082, 21);
            this.btnBajaStock.Name = "btnBajaStock";
            this.btnBajaStock.Size = new System.Drawing.Size(47, 30);
            this.btnBajaStock.TabIndex = 29;
            this.btnBajaStock.Text = "Baja stock";
            this.btnBajaStock.UseVisualStyleBackColor = true;
            this.btnBajaStock.Click += new System.EventHandler(this.btnBajaStock_Click);
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.BackColor = System.Drawing.Color.LightGreen;
            this.txtMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoTotal.Location = new System.Drawing.Point(1015, 491);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMontoTotal.Size = new System.Drawing.Size(119, 23);
            this.txtMontoTotal.TabIndex = 28;
            // 
            // txtTotalVehiculos
            // 
            this.txtTotalVehiculos.BackColor = System.Drawing.Color.LightGreen;
            this.txtTotalVehiculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalVehiculos.Location = new System.Drawing.Point(770, 491);
            this.txtTotalVehiculos.Name = "txtTotalVehiculos";
            this.txtTotalVehiculos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalVehiculos.Size = new System.Drawing.Size(119, 23);
            this.txtTotalVehiculos.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(918, 494);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 27;
            this.label4.Tag = "Total de vehículos";
            this.label4.Text = "Importe Total";
            // 
            // button1
            // 
            this.button1.Image = global::Concesionaria.Properties.Resources.CAR3;
            this.button1.Location = new System.Drawing.Point(910, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 30);
            this.button1.TabIndex = 26;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(641, 494);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 26;
            this.label3.Tag = "Total de vehículos";
            this.label3.Text = "Total de vehículos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = " Marca";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(209, 26);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(143, 24);
            this.cmbMarca.TabIndex = 24;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Concesionaria.Properties.Resources.zoom;
            this.btnBuscar.Location = new System.Drawing.Point(870, 22);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 30);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtPatente
            // 
            this.txtPatente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPatente.Location = new System.Drawing.Point(73, 26);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(73, 23);
            this.txtPatente.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = " Patente";
            // 
            // reporteAutoTableAdapter1
            // 
            this.reporteAutoTableAdapter1.ClearBeforeFill = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(495, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 17);
            this.label8.TabIndex = 81;
            this.label8.Text = "Facturación";
            // 
            // cmbEstadoFacturacion
            // 
            this.cmbEstadoFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoFacturacion.FormattingEnabled = true;
            this.cmbEstadoFacturacion.Location = new System.Drawing.Point(583, 57);
            this.cmbEstadoFacturacion.Name = "cmbEstadoFacturacion";
            this.cmbEstadoFacturacion.Size = new System.Drawing.Size(89, 24);
            this.cmbEstadoFacturacion.TabIndex = 82;
            // 
            // FrmStockAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1178, 547);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStockAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmStockAuto";
            this.Load += new System.EventHandler(this.FrmStockAuto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalVehiculos;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBajaStock;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbOrden;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Button btnAplicarIncremento;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sel;
        private CONCESIONARIADataSetTableAdapters.ReporteAutoTableAdapter reporteAutoTableAdapter1;
        private System.Windows.Forms.Button BtnVerGanancia;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.ComboBox cmbEstadoFacturacion;
        private System.Windows.Forms.Label label8;
    }
}