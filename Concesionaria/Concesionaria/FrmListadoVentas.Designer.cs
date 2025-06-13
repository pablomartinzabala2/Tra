namespace Concesionaria
{
    partial class FrmListadoVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListadoVentas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkOrden = new System.Windows.Forms.CheckBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCantidadVentas = new System.Windows.Forms.TextBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGanancia = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.txtPrenda = new System.Windows.Forms.TextBox();
            this.txtVehículo = new System.Windows.Forms.TextBox();
            this.txtDocumentos = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnResponsabilidadCivil = new System.Windows.Forms.Button();
            this.btnReporte2 = new System.Windows.Forms.Button();
            this.BtnVerGanancia = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnAbrirVenta = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.chkOrden);
            this.groupBox1.Controls.Add(this.txtModelo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbMarca);
            this.groupBox1.Controls.Add(this.btnResponsabilidadCivil);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dpFechaHasta);
            this.groupBox1.Controls.Add(this.dpFechaDesde);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnReporte2);
            this.groupBox1.Controls.Add(this.BtnVerGanancia);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCantidadVentas);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.txtPatente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAbrirVenta);
            this.groupBox1.Controls.Add(this.lblGanancia);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Controls.Add(this.txtPrenda);
            this.groupBox1.Controls.Add(this.txtVehículo);
            this.groupBox1.Controls.Add(this.txtDocumentos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1270, 534);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de ventas";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkOrden
            // 
            this.chkOrden.AutoSize = true;
            this.chkOrden.Checked = true;
            this.chkOrden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOrden.Location = new System.Drawing.Point(215, 10);
            this.chkOrden.Name = "chkOrden";
            this.chkOrden.Size = new System.Drawing.Size(108, 20);
            this.chkOrden.TabIndex = 78;
            this.chkOrden.Text = "Descendente";
            this.chkOrden.UseVisualStyleBackColor = true;
            // 
            // txtModelo
            // 
            this.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModelo.Location = new System.Drawing.Point(883, 32);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(65, 22);
            this.txtModelo.TabIndex = 77;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(823, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 76;
            this.label7.Text = "Modelo";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(696, 31);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(121, 24);
            this.cmbMarca.TabIndex = 75;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(373, 37);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(133, 22);
            this.txtNombre.TabIndex = 73;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 72;
            this.label6.Text = "Cliente";
            // 
            // dpFechaHasta
            // 
            this.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaHasta.Location = new System.Drawing.Point(221, 35);
            this.dpFechaHasta.Name = "dpFechaHasta";
            this.dpFechaHasta.Size = new System.Drawing.Size(87, 22);
            this.dpFechaHasta.TabIndex = 71;
            // 
            // dpFechaDesde
            // 
            this.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaDesde.Location = new System.Drawing.Point(77, 37);
            this.dpFechaDesde.Name = "dpFechaDesde";
            this.dpFechaDesde.Size = new System.Drawing.Size(85, 22);
            this.dpFechaDesde.TabIndex = 70;
            // 
            // txtApellido
            // 
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Location = new System.Drawing.Point(1047, 8);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(33, 22);
            this.txtApellido.TabIndex = 60;
            this.txtApellido.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(648, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 59;
            this.label3.Text = "Marca";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(783, 506);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "Cantidad operaciones";
            // 
            // txtCantidadVentas
            // 
            this.txtCantidadVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadVentas.Location = new System.Drawing.Point(936, 506);
            this.txtCantidadVentas.Name = "txtCantidadVentas";
            this.txtCantidadVentas.Size = new System.Drawing.Size(100, 22);
            this.txtCantidadVentas.TabIndex = 55;
            // 
            // txtPatente
            // 
            this.txtPatente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPatente.Location = new System.Drawing.Point(568, 34);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(74, 22);
            this.txtPatente.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 52;
            this.label4.Text = "Dominio";
            // 
            // lblGanancia
            // 
            this.lblGanancia.AutoSize = true;
            this.lblGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanancia.Location = new System.Drawing.Point(1045, 506);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(105, 17);
            this.lblGanancia.TabIndex = 42;
            this.lblGanancia.Text = "Total Ganancia";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(1156, 506);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTotal.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = " Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Desde";
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(25, 70);
            this.Grilla.Name = "Grilla";
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(1231, 420);
            this.Grilla.TabIndex = 8;
            // 
            // txtPrenda
            // 
            this.txtPrenda.Enabled = false;
            this.txtPrenda.Location = new System.Drawing.Point(137, 146);
            this.txtPrenda.Name = "txtPrenda";
            this.txtPrenda.ReadOnly = true;
            this.txtPrenda.Size = new System.Drawing.Size(136, 22);
            this.txtPrenda.TabIndex = 7;
            // 
            // txtVehículo
            // 
            this.txtVehículo.Enabled = false;
            this.txtVehículo.Location = new System.Drawing.Point(137, 106);
            this.txtVehículo.Name = "txtVehículo";
            this.txtVehículo.ReadOnly = true;
            this.txtVehículo.Size = new System.Drawing.Size(136, 22);
            this.txtVehículo.TabIndex = 5;
            // 
            // txtDocumentos
            // 
            this.txtDocumentos.Enabled = false;
            this.txtDocumentos.Location = new System.Drawing.Point(137, 70);
            this.txtDocumentos.Name = "txtDocumentos";
            this.txtDocumentos.ReadOnly = true;
            this.txtDocumentos.Size = new System.Drawing.Size(136, 22);
            this.txtDocumentos.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(956, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 27);
            this.button1.TabIndex = 79;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnResponsabilidadCivil
            // 
            this.btnResponsabilidadCivil.Image = global::Concesionaria.Properties.Resources.MOVIMIENTOS;
            this.btnResponsabilidadCivil.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResponsabilidadCivil.Location = new System.Drawing.Point(1213, 31);
            this.btnResponsabilidadCivil.Name = "btnResponsabilidadCivil";
            this.btnResponsabilidadCivil.Size = new System.Drawing.Size(43, 27);
            this.btnResponsabilidadCivil.TabIndex = 74;
            this.btnResponsabilidadCivil.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnResponsabilidadCivil.UseVisualStyleBackColor = true;
            this.btnResponsabilidadCivil.Click += new System.EventHandler(this.btnResponsabilidadCivil_Click);
            // 
            // btnReporte2
            // 
            this.btnReporte2.Image = global::Concesionaria.Properties.Resources.MOVIMIENTOS;
            this.btnReporte2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReporte2.Location = new System.Drawing.Point(1175, 31);
            this.btnReporte2.Name = "btnReporte2";
            this.btnReporte2.Size = new System.Drawing.Size(43, 27);
            this.btnReporte2.TabIndex = 58;
            this.btnReporte2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReporte2.UseVisualStyleBackColor = true;
            this.btnReporte2.Click += new System.EventHandler(this.btnReporte2_Click);
            // 
            // BtnVerGanancia
            // 
            this.BtnVerGanancia.Image = global::Concesionaria.Properties.Resources.Linterna;
            this.BtnVerGanancia.Location = new System.Drawing.Point(1140, 31);
            this.BtnVerGanancia.Name = "BtnVerGanancia";
            this.BtnVerGanancia.Size = new System.Drawing.Size(40, 27);
            this.BtnVerGanancia.TabIndex = 57;
            this.BtnVerGanancia.UseVisualStyleBackColor = true;
            this.BtnVerGanancia.Click += new System.EventHandler(this.BtnVerGanancia_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnImprimir.Image = global::Concesionaria.Properties.Resources.COMPRA222;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(1094, 31);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(40, 27);
            this.btnImprimir.TabIndex = 54;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnAbrirVenta
            // 
            this.btnAbrirVenta.Image = global::Concesionaria.Properties.Resources.carpeta;
            this.btnAbrirVenta.Location = new System.Drawing.Point(1048, 32);
            this.btnAbrirVenta.Name = "btnAbrirVenta";
            this.btnAbrirVenta.Size = new System.Drawing.Size(40, 27);
            this.btnAbrirVenta.TabIndex = 43;
            this.btnAbrirVenta.UseVisualStyleBackColor = true;
            this.btnAbrirVenta.Click += new System.EventHandler(this.btnAbrirVenta_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Concesionaria.Properties.Resources.zoom2;
            this.btnBuscar.Location = new System.Drawing.Point(1002, 35);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(40, 27);
            this.btnBuscar.TabIndex = 40;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmListadoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1294, 555);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListadoVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de ventas";
            this.Load += new System.EventHandler(this.FrmListadoVentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.TextBox txtPrenda;
        private System.Windows.Forms.TextBox txtVehículo;
        private System.Windows.Forms.TextBox txtDocumentos;
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnAbrirVenta;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCantidadVentas;
        private System.Windows.Forms.Button BtnVerGanancia;
        private System.Windows.Forms.Button btnReporte2;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpFechaHasta;
        private System.Windows.Forms.DateTimePicker dpFechaDesde;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnResponsabilidadCivil;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkOrden;
        private System.Windows.Forms.Button button1;
    }
}