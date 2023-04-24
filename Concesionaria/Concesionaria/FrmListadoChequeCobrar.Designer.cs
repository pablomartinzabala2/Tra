namespace Concesionaria
{
    partial class FrmListadoChequeCobrar
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
            this.chkSoloImpago = new System.Windows.Forms.CheckBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.dpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.daFechaCobro = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNumeroCheque = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumeroCheque);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.daFechaCobro);
            this.groupBox1.Controls.Add(this.dpFechaHasta);
            this.groupBox1.Controls.Add(this.dpFechaDesde);
            this.groupBox1.Controls.Add(this.chkSoloImpago);
            this.groupBox1.Controls.Add(this.btnAbrir);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnCobrar);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1176, 525);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado";
            // 
            // chkSoloImpago
            // 
            this.chkSoloImpago.AutoSize = true;
            this.chkSoloImpago.Location = new System.Drawing.Point(486, 24);
            this.chkSoloImpago.Name = "chkSoloImpago";
            this.chkSoloImpago.Size = new System.Drawing.Size(80, 21);
            this.chkSoloImpago.TabIndex = 60;
            this.chkSoloImpago.Text = "Impagos";
            this.chkSoloImpago.UseVisualStyleBackColor = true;
            // 
            // btnAbrir
            // 
            this.btnAbrir.Image = global::Concesionaria.Properties.Resources.carpeta;
            this.btnAbrir.Location = new System.Drawing.Point(1137, 24);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(34, 24);
            this.btnAbrir.TabIndex = 59;
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 57;
            this.label4.Text = "Fecha Cobro";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::Concesionaria.Properties.Resources.cancel;
            this.btnEliminar.Location = new System.Drawing.Point(1097, 24);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(34, 24);
            this.btnEliminar.TabIndex = 51;
            this.btnEliminar.Text = "º";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.Image = global::Concesionaria.Properties.Resources.money_euro;
            this.btnCobrar.Location = new System.Drawing.Point(1057, 24);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(34, 24);
            this.btnCobrar.TabIndex = 50;
            this.btnCobrar.Text = "º";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // button3
            // 
            this.button3.Image = global::Concesionaria.Properties.Resources.zoom;
            this.button3.Location = new System.Drawing.Point(1017, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 24);
            this.button3.TabIndex = 48;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 45;
            this.label7.Text = "Desde";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(154, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 44;
            this.label8.Text = "Hasta";
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(9, 53);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(1161, 466);
            this.Grilla.TabIndex = 0;
            // 
            // dpFechaDesde
            // 
            this.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaDesde.Location = new System.Drawing.Point(61, 24);
            this.dpFechaDesde.Name = "dpFechaDesde";
            this.dpFechaDesde.Size = new System.Drawing.Size(87, 23);
            this.dpFechaDesde.TabIndex = 71;
            // 
            // dpFechaHasta
            // 
            this.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaHasta.Location = new System.Drawing.Point(205, 24);
            this.dpFechaHasta.Name = "dpFechaHasta";
            this.dpFechaHasta.Size = new System.Drawing.Size(87, 23);
            this.dpFechaHasta.TabIndex = 72;
            // 
            // daFechaCobro
            // 
            this.daFechaCobro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.daFechaCobro.Location = new System.Drawing.Point(393, 24);
            this.daFechaCobro.Name = "daFechaCobro";
            this.daFechaCobro.Size = new System.Drawing.Size(87, 23);
            this.daFechaCobro.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(572, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 74;
            this.label1.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(636, 24);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(173, 23);
            this.txtApellido.TabIndex = 75;
            // 
            // txtNumeroCheque
            // 
            this.txtNumeroCheque.Location = new System.Drawing.Point(879, 24);
            this.txtNumeroCheque.Name = "txtNumeroCheque";
            this.txtNumeroCheque.Size = new System.Drawing.Size(120, 23);
            this.txtNumeroCheque.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(815, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 76;
            this.label2.Text = "Número";
            // 
            // FrmListadoChequeCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1200, 540);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListadoChequeCobrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de cheques";
            this.Load += new System.EventHandler(this.FrmListadoChequeCobrar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.CheckBox chkSoloImpago;
        private System.Windows.Forms.DateTimePicker dpFechaDesde;
        private System.Windows.Forms.DateTimePicker dpFechaHasta;
        private System.Windows.Forms.DateTimePicker daFechaCobro;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroCheque;
        private System.Windows.Forms.Label label2;
    }
}