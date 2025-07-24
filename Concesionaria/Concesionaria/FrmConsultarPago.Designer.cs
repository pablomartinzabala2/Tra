namespace Concesionaria
{
    partial class FrmConsultarPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarPago));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dpFechaHasta);
            this.groupBox1.Controls.Add(this.dpFechaDesde);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnRegistrarPago);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(797, 532);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(682, 505);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 23);
            this.txtTotal.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(506, 505);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 73;
            this.label1.Text = "Total Vencimientos Diario";
            // 
            // dpFechaHasta
            // 
            this.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaHasta.Location = new System.Drawing.Point(298, 22);
            this.dpFechaHasta.Name = "dpFechaHasta";
            this.dpFechaHasta.Size = new System.Drawing.Size(85, 23);
            this.dpFechaHasta.TabIndex = 72;
            // 
            // dpFechaDesde
            // 
            this.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaDesde.Location = new System.Drawing.Point(113, 24);
            this.dpFechaDesde.Name = "dpFechaDesde";
            this.dpFechaDesde.Size = new System.Drawing.Size(85, 23);
            this.dpFechaDesde.TabIndex = 71;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::Concesionaria.Properties.Resources.cancel;
            this.btnEliminar.Location = new System.Drawing.Point(469, 23);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(34, 24);
            this.btnEliminar.TabIndex = 51;
            this.btnEliminar.Text = "º";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistrarPago.Image")));
            this.btnRegistrarPago.Location = new System.Drawing.Point(429, 22);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(34, 24);
            this.btnRegistrarPago.TabIndex = 50;
            this.btnRegistrarPago.Text = "º";
            this.btnRegistrarPago.UseVisualStyleBackColor = true;
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // button3
            // 
            this.button3.Image = global::Concesionaria.Properties.Resources.zoom;
            this.button3.Location = new System.Drawing.Point(389, 22);
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
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 45;
            this.label7.Text = "Fecha Desde";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 44;
            this.label8.Text = "Fecha Hasta";
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(9, 52);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(773, 437);
            this.Grilla.TabIndex = 0;
            // 
            // FrmConsultarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 540);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmConsultarPago";
            this.Text = "Formulario de consulta de pagos";
            this.Load += new System.EventHandler(this.FrmConsultarPago_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dpFechaHasta;
        private System.Windows.Forms.DateTimePicker dpFechaDesde;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
    }
}