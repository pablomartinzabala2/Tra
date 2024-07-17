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
            this.lblVencidas = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImprimirReporte = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Label();
            this.GrillaDeuda = new System.Windows.Forms.DataGridView();
            this.Cobrar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDeuda)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.btnCobrar);
            this.Grupo.Controls.Add(this.GrillaDeuda);
            this.Grupo.Controls.Add(this.btnImprimirReporte);
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
            // btnImprimirReporte
            // 
            this.btnImprimirReporte.Image = global::Concesionaria.Properties.Resources.printer1;
            this.btnImprimirReporte.Location = new System.Drawing.Point(322, 13);
            this.btnImprimirReporte.Name = "btnImprimirReporte";
            this.btnImprimirReporte.Size = new System.Drawing.Size(40, 26);
            this.btnImprimirReporte.TabIndex = 72;
            this.btnImprimirReporte.UseVisualStyleBackColor = true;
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
            // GrillaDeuda
            // 
            this.GrillaDeuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaDeuda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cobrar});
            this.GrillaDeuda.Location = new System.Drawing.Point(0, 70);
            this.GrillaDeuda.Name = "GrillaDeuda";
            this.GrillaDeuda.Size = new System.Drawing.Size(961, 409);
            this.GrillaDeuda.TabIndex = 73;
            // 
            // Cobrar
            // 
            this.Cobrar.HeaderText = "Cobrar";
            this.Cobrar.Name = "Cobrar";
            // 
            // btnCobrar
            // 
            this.btnCobrar.Location = new System.Drawing.Point(43, 13);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(75, 23);
            this.btnCobrar.TabIndex = 74;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // FrmListadoDeudaCoibranzaxCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 509);
            this.Controls.Add(this.Grupo);
            this.Name = "FrmListadoDeudaCoibranzaxCliente";
            this.Text = "FrmListadoDeudaCoibranzaxCliente";
            this.Load += new System.EventHandler(this.FrmListadoDeudaCoibranzaxCliente_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDeuda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.Button btnImprimirReporte;
        private System.Windows.Forms.Label btnImprimir;
        private System.Windows.Forms.Label lblVencidas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView GrillaDeuda;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cobrar;
        private System.Windows.Forms.Button btnCobrar;
    }
}