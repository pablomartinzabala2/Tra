﻿namespace Concesionaria
{
    partial class FrmResumenCuentaProveedor
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
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCorregir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.btnAbrirDeuda = new System.Windows.Forms.Button();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.txtCodCuenta = new System.Windows.Forms.TextBox();
            this.txtCuentaProveedor = new System.Windows.Forms.TextBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDetalle);
            this.groupBox1.Controls.Add(this.txtConcepto);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnCorregir);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dpFechaHasta);
            this.groupBox1.Controls.Add(this.dpFechaDesde);
            this.groupBox1.Controls.Add(this.btnAbrirDeuda);
            this.groupBox1.Controls.Add(this.txtSaldo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Controls.Add(this.txtCodCuenta);
            this.groupBox1.Controls.Add(this.txtCuentaProveedor);
            this.groupBox1.Controls.Add(this.txtProveedor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(873, 467);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(322, 44);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(172, 23);
            this.txtConcepto.TabIndex = 86;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 85;
            this.label6.Text = "Concepto";
            // 
            // btnCorregir
            // 
            this.btnCorregir.Location = new System.Drawing.Point(575, 435);
            this.btnCorregir.Name = "btnCorregir";
            this.btnCorregir.Size = new System.Drawing.Size(75, 23);
            this.btnCorregir.TabIndex = 84;
            this.btnCorregir.Text = "Corregir";
            this.btnCorregir.UseVisualStyleBackColor = true;
            this.btnCorregir.Click += new System.EventHandler(this.btnCorregir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Concesionaria.Properties.Resources.zoom;
            this.btnBuscar.Location = new System.Drawing.Point(685, 35);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(40, 31);
            this.btnBuscar.TabIndex = 83;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::Concesionaria.Properties.Resources.printer;
            this.btnImprimir.Location = new System.Drawing.Point(777, 34);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(40, 31);
            this.btnImprimir.TabIndex = 82;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(607, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 81;
            this.label5.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(497, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 80;
            this.label4.Text = "Desde";
            // 
            // dpFechaHasta
            // 
            this.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaHasta.Location = new System.Drawing.Point(593, 44);
            this.dpFechaHasta.Name = "dpFechaHasta";
            this.dpFechaHasta.Size = new System.Drawing.Size(87, 23);
            this.dpFechaHasta.TabIndex = 79;
            // 
            // dpFechaDesde
            // 
            this.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaDesde.Location = new System.Drawing.Point(500, 44);
            this.dpFechaDesde.Name = "dpFechaDesde";
            this.dpFechaDesde.Size = new System.Drawing.Size(87, 23);
            this.dpFechaDesde.TabIndex = 78;
            // 
            // btnAbrirDeuda
            // 
            this.btnAbrirDeuda.Image = global::Concesionaria.Properties.Resources.carpeta;
            this.btnAbrirDeuda.Location = new System.Drawing.Point(731, 35);
            this.btnAbrirDeuda.Name = "btnAbrirDeuda";
            this.btnAbrirDeuda.Size = new System.Drawing.Size(40, 31);
            this.btnAbrirDeuda.TabIndex = 77;
            this.btnAbrirDeuda.UseVisualStyleBackColor = true;
            this.btnAbrirDeuda.Click += new System.EventHandler(this.btnAbrirDeuda_Click);
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(720, 438);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(147, 23);
            this.txtSaldo.TabIndex = 48;
            this.txtSaldo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(670, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 47;
            this.label3.Text = "Saldo";
            this.label3.Visible = false;
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(13, 73);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(850, 356);
            this.Grilla.TabIndex = 46;
            // 
            // txtCodCuenta
            // 
            this.txtCodCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtCodCuenta.Location = new System.Drawing.Point(9, 0);
            this.txtCodCuenta.Name = "txtCodCuenta";
            this.txtCodCuenta.Size = new System.Drawing.Size(38, 23);
            this.txtCodCuenta.TabIndex = 4;
            this.txtCodCuenta.Visible = false;
            // 
            // txtCuentaProveedor
            // 
            this.txtCuentaProveedor.Location = new System.Drawing.Point(168, 44);
            this.txtCuentaProveedor.Name = "txtCuentaProveedor";
            this.txtCuentaProveedor.Size = new System.Drawing.Size(148, 23);
            this.txtCuentaProveedor.TabIndex = 3;
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(9, 41);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(153, 23);
            this.txtProveedor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cuenta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor";
            // 
            // btnDetalle
            // 
            this.btnDetalle.Image = global::Concesionaria.Properties.Resources.Compra;
            this.btnDetalle.Location = new System.Drawing.Point(823, 38);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(40, 27);
            this.btnDetalle.TabIndex = 97;
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // FrmResumenCuentaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 491);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmResumenCuentaProveedor";
            this.Text = "FrmResumenCuentaProveedor";
            this.Load += new System.EventHandler(this.FrmResumenCuentaProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCuentaProveedor;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodCuenta;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAbrirDeuda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dpFechaHasta;
        private System.Windows.Forms.DateTimePicker dpFechaDesde;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCorregir;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDetalle;
    }
}