namespace Concesionaria
{
    partial class FrmListadoCuentasProveedor
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
            this.btnVerResumen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBorarCobranza = new System.Windows.Forms.Button();
            this.btnCobroCheque = new System.Windows.Forms.Button();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVerResumen);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnBorarCobranza);
            this.groupBox1.Controls.Add(this.btnCobroCheque);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(936, 485);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Cuentas Corrientes";
            // 
            // btnVerResumen
            // 
            this.btnVerResumen.Image = global::Concesionaria.Properties.Resources.Folder1;
            this.btnVerResumen.Location = new System.Drawing.Point(542, 22);
            this.btnVerResumen.Name = "btnVerResumen";
            this.btnVerResumen.Size = new System.Drawing.Size(40, 31);
            this.btnVerResumen.TabIndex = 75;
            this.btnVerResumen.UseVisualStyleBackColor = true;
            this.btnVerResumen.Click += new System.EventHandler(this.btnVerResumen_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Concesionaria.Properties.Resources.add;
            this.button1.Location = new System.Drawing.Point(634, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 31);
            this.button1.TabIndex = 74;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // btnBorarCobranza
            // 
            this.btnBorarCobranza.Image = global::Concesionaria.Properties.Resources.cancel;
            this.btnBorarCobranza.Location = new System.Drawing.Point(943, 26);
            this.btnBorarCobranza.Name = "btnBorarCobranza";
            this.btnBorarCobranza.Size = new System.Drawing.Size(40, 31);
            this.btnBorarCobranza.TabIndex = 56;
            this.btnBorarCobranza.UseVisualStyleBackColor = true;
            // 
            // btnCobroCheque
            // 
            this.btnCobroCheque.Image = global::Concesionaria.Properties.Resources.money_euro;
            this.btnCobroCheque.Location = new System.Drawing.Point(496, 26);
            this.btnCobroCheque.Name = "btnCobroCheque";
            this.btnCobroCheque.Size = new System.Drawing.Size(40, 31);
            this.btnCobroCheque.TabIndex = 48;
            this.btnCobroCheque.UseVisualStyleBackColor = true;
            this.btnCobroCheque.Click += new System.EventHandler(this.btnCobroCheque_Click);
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(17, 63);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(852, 384);
            this.Grilla.TabIndex = 45;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(402, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(88, 28);
            this.btnBuscar.TabIndex = 44;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmListadoCuentasProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 539);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmListadoCuentasProveedor";
            this.Text = "FrmListadoCuentasProveedor";
            this.Load += new System.EventHandler(this.FrmListadoCuentasProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBorarCobranza;
        private System.Windows.Forms.Button btnCobroCheque;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnVerResumen;
    }
}