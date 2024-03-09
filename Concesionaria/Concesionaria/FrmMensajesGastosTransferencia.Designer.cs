namespace Concesionaria
{
    partial class FrmMensajesGastosTransferencia
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
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnVerMensaje = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVerMensaje);
            this.groupBox1.Controls.Add(this.btnQuitar);
            this.groupBox1.Controls.Add(this.dpFecha);
            this.groupBox1.Controls.Add(this.Grilla);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMensaje);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 469);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mensajes";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(67, 29);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(87, 23);
            this.dpFecha.TabIndex = 73;
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(17, 171);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(571, 279);
            this.Grilla.TabIndex = 50;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(295, 33);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 23);
            this.txtCodigo.TabIndex = 49;
            this.txtCodigo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(17, 62);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(571, 103);
            this.txtMensaje.TabIndex = 0;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Image = global::Concesionaria.Properties.Resources.cancel;
            this.btnQuitar.Location = new System.Drawing.Point(502, 24);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(40, 28);
            this.btnQuitar.TabIndex = 74;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::Concesionaria.Properties.Resources.add;
            this.btnAgregar.Location = new System.Drawing.Point(456, 24);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(40, 28);
            this.btnAgregar.TabIndex = 48;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnVerMensaje
            // 
            this.btnVerMensaje.Image = global::Concesionaria.Properties.Resources.zoom1;
            this.btnVerMensaje.Location = new System.Drawing.Point(548, 24);
            this.btnVerMensaje.Name = "btnVerMensaje";
            this.btnVerMensaje.Size = new System.Drawing.Size(40, 28);
            this.btnVerMensaje.TabIndex = 75;
            this.btnVerMensaje.UseVisualStyleBackColor = true;
            this.btnVerMensaje.Click += new System.EventHandler(this.btnVerMensaje_Click);
            // 
            // FrmMensajesGastosTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(616, 457);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMensajesGastosTransferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Mensajes";
            this.Load += new System.EventHandler(this.FrmMensajesGastosTransferencia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnVerMensaje;
    }
}