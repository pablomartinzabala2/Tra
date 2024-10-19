namespace Concesionaria
{
    partial class FrmPersonal
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
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.btnQuitarResponsable = new System.Windows.Forms.Button();
            this.btnAgregarResponsable = new System.Windows.Forms.Button();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevoCargo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNuevoCargo);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Controls.Add(this.btnQuitarResponsable);
            this.groupBox1.Controls.Add(this.btnAgregarResponsable);
            this.groupBox1.Controls.Add(this.cmbCargo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 338);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información del personal";
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(15, 146);
            this.Grilla.Name = "Grilla";
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(487, 150);
            this.Grilla.TabIndex = 79;
            // 
            // btnQuitarResponsable
            // 
            this.btnQuitarResponsable.Image = global::Concesionaria.Properties.Resources.cancel;
            this.btnQuitarResponsable.Location = new System.Drawing.Point(368, 103);
            this.btnQuitarResponsable.Name = "btnQuitarResponsable";
            this.btnQuitarResponsable.Size = new System.Drawing.Size(34, 24);
            this.btnQuitarResponsable.TabIndex = 78;
            this.btnQuitarResponsable.UseVisualStyleBackColor = true;
            this.btnQuitarResponsable.Click += new System.EventHandler(this.btnQuitarResponsable_Click);
            // 
            // btnAgregarResponsable
            // 
            this.btnAgregarResponsable.Image = global::Concesionaria.Properties.Resources.add;
            this.btnAgregarResponsable.Location = new System.Drawing.Point(335, 103);
            this.btnAgregarResponsable.Name = "btnAgregarResponsable";
            this.btnAgregarResponsable.Size = new System.Drawing.Size(27, 24);
            this.btnAgregarResponsable.TabIndex = 77;
            this.btnAgregarResponsable.UseVisualStyleBackColor = true;
            this.btnAgregarResponsable.Click += new System.EventHandler(this.btnAgregarResponsable_Click);
            // 
            // cmbCargo
            // 
            this.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Location = new System.Drawing.Point(82, 73);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(247, 24);
            this.cmbCargo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cargo";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(82, 103);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(247, 23);
            this.txtTelefono.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Telefono";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(82, 41);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(247, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // btnNuevoCargo
            // 
            this.btnNuevoCargo.Image = global::Concesionaria.Properties.Resources.page_add;
            this.btnNuevoCargo.Location = new System.Drawing.Point(335, 70);
            this.btnNuevoCargo.Name = "btnNuevoCargo";
            this.btnNuevoCargo.Size = new System.Drawing.Size(40, 28);
            this.btnNuevoCargo.TabIndex = 80;
            this.btnNuevoCargo.UseVisualStyleBackColor = true;
            this.btnNuevoCargo.Click += new System.EventHandler(this.btnNuevoCargo_Click);
            // 
            // FrmPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 375);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPersonal";
            this.Text = "Formulario de Personal";
            this.Load += new System.EventHandler(this.FrmPersonal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuitarResponsable;
        private System.Windows.Forms.Button btnAgregarResponsable;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Button btnNuevoCargo;
    }
}