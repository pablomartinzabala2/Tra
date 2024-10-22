namespace Concesionaria
{
    partial class FrmListadoCliente
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
            this.btnBuscarCompra = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ntmAbrirCliente = new System.Windows.Forms.Button();
            this.txtNonbre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAbrirVenta = new System.Windows.Forms.Button();
            this.btnPersonal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(6, 59);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(840, 374);
            this.Grilla.TabIndex = 45;
            // 
            // btnBuscarCompra
            // 
            this.btnBuscarCompra.Image = global::Concesionaria.Properties.Resources.zoom;
            this.btnBuscarCompra.Location = new System.Drawing.Point(322, 23);
            this.btnBuscarCompra.Name = "btnBuscarCompra";
            this.btnBuscarCompra.Size = new System.Drawing.Size(34, 30);
            this.btnBuscarCompra.TabIndex = 51;
            this.btnBuscarCompra.UseVisualStyleBackColor = true;
            this.btnBuscarCompra.Click += new System.EventHandler(this.btnBuscarCompra_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPersonal);
            this.groupBox1.Controls.Add(this.ntmAbrirCliente);
            this.groupBox1.Controls.Add(this.txtNonbre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAbrirVenta);
            this.groupBox1.Controls.Add(this.btnBuscarCompra);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 439);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Cliente";
            // 
            // ntmAbrirCliente
            // 
            this.ntmAbrirCliente.Image = global::Concesionaria.Properties.Resources.Folder1;
            this.ntmAbrirCliente.Location = new System.Drawing.Point(408, 23);
            this.ntmAbrirCliente.Name = "ntmAbrirCliente";
            this.ntmAbrirCliente.Size = new System.Drawing.Size(40, 27);
            this.ntmAbrirCliente.TabIndex = 57;
            this.ntmAbrirCliente.UseVisualStyleBackColor = true;
            this.ntmAbrirCliente.Click += new System.EventHandler(this.ntmAbrirCliente_Click);
            // 
            // txtNonbre
            // 
            this.txtNonbre.Location = new System.Drawing.Point(70, 26);
            this.txtNonbre.Name = "txtNonbre";
            this.txtNonbre.Size = new System.Drawing.Size(238, 23);
            this.txtNonbre.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Nombre";
            // 
            // btnAbrirVenta
            // 
            this.btnAbrirVenta.Image = global::Concesionaria.Properties.Resources.printer;
            this.btnAbrirVenta.Location = new System.Drawing.Point(362, 23);
            this.btnAbrirVenta.Name = "btnAbrirVenta";
            this.btnAbrirVenta.Size = new System.Drawing.Size(40, 27);
            this.btnAbrirVenta.TabIndex = 54;
            this.btnAbrirVenta.UseVisualStyleBackColor = true;
            this.btnAbrirVenta.Click += new System.EventHandler(this.btnAbrirVenta_Click);
            // 
            // btnPersonal
            // 
            this.btnPersonal.Image = global::Concesionaria.Properties.Resources.clie1;
            this.btnPersonal.Location = new System.Drawing.Point(454, 23);
            this.btnPersonal.Name = "btnPersonal";
            this.btnPersonal.Size = new System.Drawing.Size(40, 28);
            this.btnPersonal.TabIndex = 82;
            this.btnPersonal.UseVisualStyleBackColor = true;
            this.btnPersonal.Click += new System.EventHandler(this.btnPersonal_Click);
            // 
            // FrmListadoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 487);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmListadoCliente";
            this.Text = "Listado de Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Button btnBuscarCompra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAbrirVenta;
        private System.Windows.Forms.TextBox txtNonbre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ntmAbrirCliente;
        private System.Windows.Forms.Button btnPersonal;
    }
}