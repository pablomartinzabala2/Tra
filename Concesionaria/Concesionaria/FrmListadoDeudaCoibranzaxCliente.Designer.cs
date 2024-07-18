namespace Concesionaria
{
    partial class FrmListadoDeudaCoibranzaxCliente
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
            this.btnCobrar = new System.Windows.Forms.Button();
            this.GrillaDeuda = new System.Windows.Forms.DataGridView();
            this.Cobrar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnImprimir = new System.Windows.Forms.Label();
            this.lblVencidas = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCalcularSaldo = new System.Windows.Forms.Button();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDeuda)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.txtImporte);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Controls.Add(this.txtSaldo);
            this.Grupo.Controls.Add(this.lblMoneda);
            this.Grupo.Controls.Add(this.btnCalcularSaldo);
            this.Grupo.Controls.Add(this.btnCobrar);
            this.Grupo.Controls.Add(this.GrillaDeuda);
            this.Grupo.Controls.Add(this.btnImprimir);
            this.Grupo.Controls.Add(this.lblVencidas);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(973, 485);
            this.Grupo.TabIndex = 62;
            this.Grupo.TabStop = false;
            // 
            // btnCobrar
            // 
            this.btnCobrar.Location = new System.Drawing.Point(559, 10);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(75, 23);
            this.btnCobrar.TabIndex = 74;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // GrillaDeuda
            // 
            this.GrillaDeuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaDeuda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cobrar});
            this.GrillaDeuda.Location = new System.Drawing.Point(0, 70);
            this.GrillaDeuda.Name = "GrillaDeuda";
            this.GrillaDeuda.Size = new System.Drawing.Size(961, 409);
            this.GrillaDeuda.TabIndex = 73;
            this.GrillaDeuda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaDeuda_CellClick);
            // 
            // Cobrar
            // 
            this.Cobrar.HeaderText = "Cobrar";
            this.Cobrar.Name = "Cobrar";
            // 
            // btnImprimir
            // 
            this.btnImprimir.AutoSize = true;
            this.btnImprimir.Image = global::Concesionaria.Properties.Resources.printer;
            this.btnImprimir.Location = new System.Drawing.Point(1028, 10);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(0, 17);
            this.btnImprimir.TabIndex = 71;
            // 
            // lblVencidas
            // 
            this.lblVencidas.AutoSize = true;
            this.lblVencidas.Location = new System.Drawing.Point(1117, 484);
            this.lblVencidas.Name = "lblVencidas";
            this.lblVencidas.Size = new System.Drawing.Size(66, 17);
            this.lblVencidas.TabIndex = 64;
            this.lblVencidas.Text = "Vencidas";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(0, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(961, 25);
            this.label2.TabIndex = 59;
            this.label2.Text = "Listado de Deuda por Cliente";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCalcularSaldo
            // 
            this.btnCalcularSaldo.Location = new System.Drawing.Point(0, 10);
            this.btnCalcularSaldo.Name = "btnCalcularSaldo";
            this.btnCalcularSaldo.Size = new System.Drawing.Size(125, 23);
            this.btnCalcularSaldo.TabIndex = 75;
            this.btnCalcularSaldo.Text = "Calcular Saldo";
            this.btnCalcularSaldo.UseVisualStyleBackColor = true;
            this.btnCalcularSaldo.Click += new System.EventHandler(this.btnCalcularSaldo_Click);
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(131, 13);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(59, 17);
            this.lblMoneda.TabIndex = 76;
            this.lblMoneda.Text = "Moneda";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(175, 10);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(117, 23);
            this.txtSaldo.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 78;
            this.label1.Text = "Ingresar Importe";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(415, 10);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(138, 23);
            this.txtImporte.TabIndex = 79;
            this.txtImporte.Leave += new System.EventHandler(this.txtImporte_Leave);
            // 
            // FrmListadoDeudaCoibranzaxCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(988, 509);
            this.Controls.Add(this.Grupo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListadoDeudaCoibranzaxCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de cobro de deudas";
            this.Load += new System.EventHandler(this.FrmListadoDeudaCoibranzaxCliente_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDeuda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.Label btnImprimir;
        private System.Windows.Forms.Label lblVencidas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView GrillaDeuda;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cobrar;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Button btnCalcularSaldo;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label1;
    }
}