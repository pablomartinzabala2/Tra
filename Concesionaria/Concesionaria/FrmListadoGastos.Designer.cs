namespace Concesionaria
{
    partial class FrmListadoGastos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarGasto = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtVencida = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.dpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.txtTotalCosto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalGanancia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCobroCheque = new System.Windows.Forms.Button();
            this.chkImpagos = new System.Windows.Forms.CheckBox();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminarGasto);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.txtVencida);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbCategoria);
            this.groupBox1.Controls.Add(this.dpFechaHasta);
            this.groupBox1.Controls.Add(this.dpFechaDesde);
            this.groupBox1.Controls.Add(this.txtTotalCosto);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTotalGanancia);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPatente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnCobroCheque);
            this.groupBox1.Controls.Add(this.chkImpagos);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1178, 551);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Gastos";
            // 
            // btnEliminarGasto
            // 
            this.btnEliminarGasto.Image = global::Concesionaria.Properties.Resources.cancel;
            this.btnEliminarGasto.Location = new System.Drawing.Point(1095, 24);
            this.btnEliminarGasto.Name = "btnEliminarGasto";
            this.btnEliminarGasto.Size = new System.Drawing.Size(37, 31);
            this.btnEliminarGasto.TabIndex = 79;
            this.btnEliminarGasto.UseVisualStyleBackColor = true;
            this.btnEliminarGasto.Click += new System.EventHandler(this.btnEliminarGasto_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::Concesionaria.Properties.Resources.add;
            this.btnAgregar.Location = new System.Drawing.Point(1049, 27);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(40, 28);
            this.btnAgregar.TabIndex = 78;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtVencida
            // 
            this.txtVencida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVencida.Location = new System.Drawing.Point(17, 520);
            this.txtVencida.Name = "txtVencida";
            this.txtVencida.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtVencida.Size = new System.Drawing.Size(74, 23);
            this.txtVencida.TabIndex = 76;
            this.txtVencida.Text = "Vencidas";
            // 
            // txtCantidad
            // 
            this.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCantidad.Location = new System.Drawing.Point(305, 514);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCantidad.Size = new System.Drawing.Size(81, 23);
            this.txtCantidad.TabIndex = 75;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(236, 520);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 74;
            this.label9.Text = "Cantidad";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(884, 32);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(70, 24);
            this.cmbCategoria.TabIndex = 73;
            // 
            // dpFechaHasta
            // 
            this.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaHasta.Location = new System.Drawing.Point(199, 28);
            this.dpFechaHasta.Name = "dpFechaHasta";
            this.dpFechaHasta.Size = new System.Drawing.Size(87, 23);
            this.dpFechaHasta.TabIndex = 72;
            // 
            // dpFechaDesde
            // 
            this.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaDesde.Location = new System.Drawing.Point(55, 32);
            this.dpFechaDesde.Name = "dpFechaDesde";
            this.dpFechaDesde.Size = new System.Drawing.Size(87, 23);
            this.dpFechaDesde.TabIndex = 71;
            // 
            // txtTotalCosto
            // 
            this.txtTotalCosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalCosto.Location = new System.Drawing.Point(768, 514);
            this.txtTotalCosto.Name = "txtTotalCosto";
            this.txtTotalCosto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalCosto.Size = new System.Drawing.Size(118, 23);
            this.txtTotalCosto.TabIndex = 64;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(662, 520);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 63;
            this.label8.Text = "Total Costo";
            // 
            // txtTotalGanancia
            // 
            this.txtTotalGanancia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalGanancia.Location = new System.Drawing.Point(1003, 514);
            this.txtTotalGanancia.Name = "txtTotalGanancia";
            this.txtTotalGanancia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalGanancia.Size = new System.Drawing.Size(118, 23);
            this.txtTotalGanancia.TabIndex = 62;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(892, 520);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 17);
            this.label7.TabIndex = 61;
            this.label7.Text = "Total Ganancia";
            // 
            // txtApellido
            // 
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Location = new System.Drawing.Point(773, 31);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(104, 23);
            this.txtApellido.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(709, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 59;
            this.label6.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(599, 29);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(104, 23);
            this.txtNombre.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(535, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 57;
            this.label5.Text = "Nombre";
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Location = new System.Drawing.Point(538, 514);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(118, 23);
            this.txtTotal.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 520);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "Total Transferencia";
            // 
            // txtPatente
            // 
            this.txtPatente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPatente.Location = new System.Drawing.Point(455, 28);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(74, 23);
            this.txtPatente.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 48;
            this.label3.Text = "Patente";
            // 
            // btnCobroCheque
            // 
            this.btnCobroCheque.Image = global::Concesionaria.Properties.Resources.money_euro;
            this.btnCobroCheque.Location = new System.Drawing.Point(1003, 28);
            this.btnCobroCheque.Name = "btnCobroCheque";
            this.btnCobroCheque.Size = new System.Drawing.Size(40, 28);
            this.btnCobroCheque.TabIndex = 47;
            this.btnCobroCheque.UseVisualStyleBackColor = true;
            this.btnCobroCheque.Click += new System.EventHandler(this.btnCobroCheque_Click);
            // 
            // chkImpagos
            // 
            this.chkImpagos.AutoSize = true;
            this.chkImpagos.Checked = true;
            this.chkImpagos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImpagos.Location = new System.Drawing.Point(292, 29);
            this.chkImpagos.Name = "chkImpagos";
            this.chkImpagos.Size = new System.Drawing.Size(91, 21);
            this.chkImpagos.TabIndex = 46;
            this.chkImpagos.Text = "Pendiente";
            this.chkImpagos.UseVisualStyleBackColor = true;
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(0, 63);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(1172, 440);
            this.Grilla.TabIndex = 45;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Concesionaria.Properties.Resources.zoom;
            this.btnBuscar.Location = new System.Drawing.Point(960, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(37, 31);
            this.btnBuscar.TabIndex = 44;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 41;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "Hasta";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::Concesionaria.Properties.Resources.printer1;
            this.btnImprimir.Location = new System.Drawing.Point(1138, 24);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(34, 30);
            this.btnImprimir.TabIndex = 77;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FrmListadoGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1189, 570);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListadoGastos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmListadoGastos";
            this.Load += new System.EventHandler(this.FrmListadoGastos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCobroCheque;
        private System.Windows.Forms.CheckBox chkImpagos;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalCosto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalGanancia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dpFechaDesde;
        private System.Windows.Forms.DateTimePicker dpFechaHasta;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVencida;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminarGasto;
    }
}