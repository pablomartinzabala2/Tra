namespace Concesionaria
{
    partial class FRMcUENTApROVEEDOR
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
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.btnQuitarFinanciacion = new System.Windows.Forms.Button();
            this.btnAgregarFinanciacion = new System.Windows.Forms.Button();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodProveedor = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.txtSaldo);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Controls.Add(this.btnQuitarFinanciacion);
            this.Grupo.Controls.Add(this.btnAgregarFinanciacion);
            this.Grupo.Controls.Add(this.txtCuenta);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.txtCodProveedor);
            this.Grupo.Controls.Add(this.txtNombre);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(393, 297);
            this.Grupo.TabIndex = 14;
            this.Grupo.TabStop = false;
            this.Grupo.Text = "Marcas de vehículos";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(82, 86);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(217, 23);
            this.txtSaldo.TabIndex = 78;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 77;
            this.label3.Text = "Saldo";
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(6, 129);
            this.Grilla.Name = "Grilla";
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(351, 149);
            this.Grilla.TabIndex = 76;
            // 
            // btnQuitarFinanciacion
            // 
            this.btnQuitarFinanciacion.Image = global::Concesionaria.Properties.Resources.cancel;
            this.btnQuitarFinanciacion.Location = new System.Drawing.Point(345, 57);
            this.btnQuitarFinanciacion.Name = "btnQuitarFinanciacion";
            this.btnQuitarFinanciacion.Size = new System.Drawing.Size(34, 24);
            this.btnQuitarFinanciacion.TabIndex = 75;
            this.btnQuitarFinanciacion.UseVisualStyleBackColor = true;
            this.btnQuitarFinanciacion.Click += new System.EventHandler(this.btnQuitarFinanciacion_Click);
            // 
            // btnAgregarFinanciacion
            // 
            this.btnAgregarFinanciacion.Image = global::Concesionaria.Properties.Resources.add;
            this.btnAgregarFinanciacion.Location = new System.Drawing.Point(305, 57);
            this.btnAgregarFinanciacion.Name = "btnAgregarFinanciacion";
            this.btnAgregarFinanciacion.Size = new System.Drawing.Size(34, 24);
            this.btnAgregarFinanciacion.TabIndex = 74;
            this.btnAgregarFinanciacion.UseVisualStyleBackColor = true;
            this.btnAgregarFinanciacion.Click += new System.EventHandler(this.btnAgregarFinanciacion_Click);
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(82, 57);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(217, 23);
            this.txtCuenta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cuenta";
            // 
            // txtCodProveedor
            // 
            this.txtCodProveedor.Location = new System.Drawing.Point(305, 28);
            this.txtCodProveedor.Name = "txtCodProveedor";
            this.txtCodProveedor.Size = new System.Drawing.Size(56, 23);
            this.txtCodProveedor.TabIndex = 2;
            this.txtCodProveedor.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(82, 28);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(217, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor";
            // 
            // FRMcUENTApROVEEDOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 321);
            this.Controls.Add(this.Grupo);
            this.Name = "FRMcUENTApROVEEDOR";
            this.Text = "FRMcUENTApROVEEDOR";
            this.Load += new System.EventHandler(this.FRMcUENTApROVEEDOR_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.TextBox txtCodProveedor;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Button btnQuitarFinanciacion;
        private System.Windows.Forms.Button btnAgregarFinanciacion;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label3;
    }
}