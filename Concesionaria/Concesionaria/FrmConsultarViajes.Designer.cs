namespace Concesionaria
{
    partial class FrmConsultarViajes
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
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.txtCliente = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalaPagar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCalcularTotalPagar = new System.Windows.Forms.Button();
            this.txtValorKm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtAdelanto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGasto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiferencia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbChofer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(6, 40);
            this.Grilla.Name = "Grilla";
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(831, 395);
            this.Grilla.TabIndex = 0;
            // 
            // txtCliente
            // 
            this.txtCliente.Image = global::Concesionaria.Properties.Resources.cancel;
            this.txtCliente.Location = new System.Drawing.Point(526, 11);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(34, 24);
            this.txtCliente.TabIndex = 52;
            this.txtCliente.Text = "º";
            this.txtCliente.UseVisualStyleBackColor = true;
            this.txtCliente.Click += new System.EventHandler(this.txtCliente_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbChofer);
            this.groupBox1.Controls.Add(this.txtTotalaPagar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnCalcularTotalPagar);
            this.groupBox1.Controls.Add(this.txtValorKm);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.txtAdelanto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGasto);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDiferencia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dpFechaHasta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dpFechaDesde);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 489);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtTotalaPagar
            // 
            this.txtTotalaPagar.Location = new System.Drawing.Point(737, 455);
            this.txtTotalaPagar.Name = "txtTotalaPagar";
            this.txtTotalaPagar.ReadOnly = true;
            this.txtTotalaPagar.Size = new System.Drawing.Size(100, 21);
            this.txtTotalaPagar.TabIndex = 88;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(680, 458);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 87;
            this.label7.Text = "A Pagar";
            // 
            // btnCalcularTotalPagar
            // 
            this.btnCalcularTotalPagar.Image = global::Concesionaria.Properties.Resources.disk;
            this.btnCalcularTotalPagar.Location = new System.Drawing.Point(803, 8);
            this.btnCalcularTotalPagar.Name = "btnCalcularTotalPagar";
            this.btnCalcularTotalPagar.Size = new System.Drawing.Size(34, 24);
            this.btnCalcularTotalPagar.TabIndex = 86;
            this.btnCalcularTotalPagar.Text = "º";
            this.btnCalcularTotalPagar.UseVisualStyleBackColor = true;
            this.btnCalcularTotalPagar.Click += new System.EventHandler(this.btnCalcularTotalPagar_Click);
            // 
            // txtValorKm
            // 
            this.txtValorKm.Location = new System.Drawing.Point(697, 11);
            this.txtValorKm.Name = "txtValorKm";
            this.txtValorKm.Size = new System.Drawing.Size(100, 21);
            this.txtValorKm.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(606, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 84;
            this.label6.Text = "Valor del Km";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::Concesionaria.Properties.Resources.print;
            this.btnImprimir.Location = new System.Drawing.Point(566, 11);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(34, 24);
            this.btnImprimir.TabIndex = 83;
            this.btnImprimir.Text = "º";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtAdelanto
            // 
            this.txtAdelanto.Location = new System.Drawing.Point(396, 457);
            this.txtAdelanto.Name = "txtAdelanto";
            this.txtAdelanto.ReadOnly = true;
            this.txtAdelanto.Size = new System.Drawing.Size(100, 21);
            this.txtAdelanto.TabIndex = 82;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 81;
            this.label5.Text = "Adelanto";
            // 
            // txtGasto
            // 
            this.txtGasto.Location = new System.Drawing.Point(222, 457);
            this.txtGasto.Name = "txtGasto";
            this.txtGasto.ReadOnly = true;
            this.txtGasto.Size = new System.Drawing.Size(100, 21);
            this.txtGasto.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 460);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 79;
            this.label4.Text = "Gastos";
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.Location = new System.Drawing.Point(577, 457);
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.ReadOnly = true;
            this.txtDiferencia.Size = new System.Drawing.Size(100, 21);
            this.txtDiferencia.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 460);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 77;
            this.label2.Text = "Kilómetros";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Concesionaria.Properties.Resources.zoom1;
            this.btnBuscar.Location = new System.Drawing.Point(486, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 24);
            this.btnBuscar.TabIndex = 76;
            this.btnBuscar.Text = "º";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 75;
            this.label1.Text = "Hasta";
            // 
            // dpFechaHasta
            // 
            this.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaHasta.Location = new System.Drawing.Point(202, 13);
            this.dpFechaHasta.Name = "dpFechaHasta";
            this.dpFechaHasta.Size = new System.Drawing.Size(85, 21);
            this.dpFechaHasta.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 73;
            this.label3.Text = "Desde";
            // 
            // dpFechaDesde
            // 
            this.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaDesde.Location = new System.Drawing.Point(61, 13);
            this.dpFechaDesde.Name = "dpFechaDesde";
            this.dpFechaDesde.Size = new System.Drawing.Size(85, 21);
            this.dpFechaDesde.TabIndex = 72;
            // 
            // cmbChofer
            // 
            this.cmbChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChofer.FormattingEnabled = true;
            this.cmbChofer.Location = new System.Drawing.Point(293, 12);
            this.cmbChofer.Name = "cmbChofer";
            this.cmbChofer.Size = new System.Drawing.Size(121, 23);
            this.cmbChofer.TabIndex = 89;
            // 
            // FrmConsultarViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 513);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmConsultarViajes";
            this.Text = "Consulta de Viajes";
            this.Load += new System.EventHandler(this.FrmConsultarViajes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Button txtCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dpFechaDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpFechaHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtAdelanto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGasto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiferencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtTotalaPagar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCalcularTotalPagar;
        private System.Windows.Forms.TextBox txtValorKm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbChofer;
    }
}