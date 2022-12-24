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
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_CodTipoDoc = new System.Windows.Forms.ComboBox();
            this.btnAbrirVenta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(17, 67);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(805, 348);
            this.Grilla.TabIndex = 45;
            // 
            // btnBuscarCompra
            // 
            this.btnBuscarCompra.Image = global::Concesionaria.Properties.Resources.zoom;
            this.btnBuscarCompra.Location = new System.Drawing.Point(233, 27);
            this.btnBuscarCompra.Name = "btnBuscarCompra";
            this.btnBuscarCompra.Size = new System.Drawing.Size(34, 30);
            this.btnBuscarCompra.TabIndex = 51;
            this.btnBuscarCompra.UseVisualStyleBackColor = true;
            this.btnBuscarCompra.Click += new System.EventHandler(this.btnBuscarCompra_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAbrirVenta);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmb_CodTipoDoc);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 53;
            this.label6.Text = "Documento";
            // 
            // cmb_CodTipoDoc
            // 
            this.cmb_CodTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CodTipoDoc.FormattingEnabled = true;
            this.cmb_CodTipoDoc.Location = new System.Drawing.Point(100, 31);
            this.cmb_CodTipoDoc.Name = "cmb_CodTipoDoc";
            this.cmb_CodTipoDoc.Size = new System.Drawing.Size(127, 24);
            this.cmb_CodTipoDoc.TabIndex = 52;
            // 
            // btnAbrirVenta
            // 
            this.btnAbrirVenta.Image = global::Concesionaria.Properties.Resources.printer;
            this.btnAbrirVenta.Location = new System.Drawing.Point(273, 29);
            this.btnAbrirVenta.Name = "btnAbrirVenta";
            this.btnAbrirVenta.Size = new System.Drawing.Size(40, 27);
            this.btnAbrirVenta.TabIndex = 54;
            this.btnAbrirVenta.UseVisualStyleBackColor = true;
            this.btnAbrirVenta.Click += new System.EventHandler(this.btnAbrirVenta_Click);
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
        private System.Windows.Forms.ComboBox cmb_CodTipoDoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAbrirVenta;
    }
}