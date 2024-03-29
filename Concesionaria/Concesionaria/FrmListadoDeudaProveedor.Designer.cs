﻿namespace Concesionaria
{
    partial class FrmListadoDeudaProveedor
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
            this.txtTotalDeuda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAbrirDeuda = new System.Windows.Forms.Button();
            this.btnEliminarDeuda = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.btnBorarCobranza = new System.Windows.Forms.Button();
            this.txtTotalSaldo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCobroCheque = new System.Windows.Forms.Button();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConcepto);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTotalDeuda);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtProveedor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAbrirDeuda);
            this.groupBox1.Controls.Add(this.btnEliminarDeuda);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dpFechaHasta);
            this.groupBox1.Controls.Add(this.dpFechaDesde);
            this.groupBox1.Controls.Add(this.btnBorarCobranza);
            this.groupBox1.Controls.Add(this.txtTotalSaldo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnCobroCheque);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(978, 485);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de deuda Proveedor";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(597, 33);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(137, 23);
            this.txtConcepto.TabIndex = 82;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(523, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 81;
            this.label6.Text = "Concepto";
            // 
            // txtTotalDeuda
            // 
            this.txtTotalDeuda.Location = new System.Drawing.Point(682, 465);
            this.txtTotalDeuda.Name = "txtTotalDeuda";
            this.txtTotalDeuda.ReadOnly = true;
            this.txtTotalDeuda.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalDeuda.Size = new System.Drawing.Size(100, 23);
            this.txtTotalDeuda.TabIndex = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(613, 465);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 79;
            this.label5.Text = "Deuda";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(386, 34);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(137, 23);
            this.txtProveedor.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 77;
            this.label4.Text = "Proveedor";
            // 
            // btnAbrirDeuda
            // 
            this.btnAbrirDeuda.Image = global::Concesionaria.Properties.Resources.carpeta;
            this.btnAbrirDeuda.Location = new System.Drawing.Point(917, 28);
            this.btnAbrirDeuda.Name = "btnAbrirDeuda";
            this.btnAbrirDeuda.Size = new System.Drawing.Size(40, 31);
            this.btnAbrirDeuda.TabIndex = 76;
            this.btnAbrirDeuda.UseVisualStyleBackColor = true;
            this.btnAbrirDeuda.Click += new System.EventHandler(this.btnAbrirDeuda_Click);
            // 
            // btnEliminarDeuda
            // 
            this.btnEliminarDeuda.Image = global::Concesionaria.Properties.Resources.cancel;
            this.btnEliminarDeuda.Location = new System.Drawing.Point(871, 28);
            this.btnEliminarDeuda.Name = "btnEliminarDeuda";
            this.btnEliminarDeuda.Size = new System.Drawing.Size(40, 31);
            this.btnEliminarDeuda.TabIndex = 75;
            this.btnEliminarDeuda.UseVisualStyleBackColor = true;
            this.btnEliminarDeuda.Click += new System.EventHandler(this.btnEliminarDeuda_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Concesionaria.Properties.Resources.add;
            this.button1.Location = new System.Drawing.Point(825, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 31);
            this.button1.TabIndex = 74;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dpFechaHasta
            // 
            this.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaHasta.Location = new System.Drawing.Point(213, 34);
            this.dpFechaHasta.Name = "dpFechaHasta";
            this.dpFechaHasta.Size = new System.Drawing.Size(87, 23);
            this.dpFechaHasta.TabIndex = 73;
            // 
            // dpFechaDesde
            // 
            this.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaDesde.Location = new System.Drawing.Point(69, 34);
            this.dpFechaDesde.Name = "dpFechaDesde";
            this.dpFechaDesde.Size = new System.Drawing.Size(87, 23);
            this.dpFechaDesde.TabIndex = 72;
            // 
            // btnBorarCobranza
            // 
            this.btnBorarCobranza.Image = global::Concesionaria.Properties.Resources.cancel;
            this.btnBorarCobranza.Location = new System.Drawing.Point(825, -3);
            this.btnBorarCobranza.Name = "btnBorarCobranza";
            this.btnBorarCobranza.Size = new System.Drawing.Size(40, 31);
            this.btnBorarCobranza.TabIndex = 56;
            this.btnBorarCobranza.UseVisualStyleBackColor = true;
            this.btnBorarCobranza.Visible = false;
            // 
            // txtTotalSaldo
            // 
            this.txtTotalSaldo.Location = new System.Drawing.Point(866, 468);
            this.txtTotalSaldo.Name = "txtTotalSaldo";
            this.txtTotalSaldo.ReadOnly = true;
            this.txtTotalSaldo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalSaldo.Size = new System.Drawing.Size(100, 23);
            this.txtTotalSaldo.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(797, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 49;
            this.label3.Text = "Saldo";
            // 
            // btnCobroCheque
            // 
            this.btnCobroCheque.Image = global::Concesionaria.Properties.Resources.money_euro;
            this.btnCobroCheque.Location = new System.Drawing.Point(779, -3);
            this.btnCobroCheque.Name = "btnCobroCheque";
            this.btnCobroCheque.Size = new System.Drawing.Size(40, 31);
            this.btnCobroCheque.TabIndex = 48;
            this.btnCobroCheque.UseVisualStyleBackColor = true;
            this.btnCobroCheque.Visible = false;
            this.btnCobroCheque.Click += new System.EventHandler(this.btnCobroCheque_Click);
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(17, 63);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(947, 384);
            this.Grilla.TabIndex = 45;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(745, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(74, 28);
            this.btnBuscar.TabIndex = 44;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 41;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "Hasta";
            // 
            // FrmListadoDeudaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 514);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmListadoDeudaProveedor";
            this.Text = "Listado de deudasr";
            this.Load += new System.EventHandler(this.FrmListadoDeudaProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dpFechaHasta;
        private System.Windows.Forms.DateTimePicker dpFechaDesde;
        private System.Windows.Forms.Button btnBorarCobranza;
        private System.Windows.Forms.TextBox txtTotalSaldo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCobroCheque;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminarDeuda;
        private System.Windows.Forms.Button btnAbrirDeuda;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalDeuda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label6;
    }
}