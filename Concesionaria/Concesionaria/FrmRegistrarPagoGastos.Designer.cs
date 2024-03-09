namespace Concesionaria
{
    partial class FrmRegistrarPagoGastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistrarPagoGastos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFechaRetiro = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImporteCobrado = new System.Windows.Forms.TextBox();
            this.txtFechaTramite = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodVenta = new System.Windows.Forms.TextBox();
            this.txtTope = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtFechaPago = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnMensaje = new System.Windows.Forms.Button();
            this.btnActualizarFechaPago = new System.Windows.Forms.Button();
            this.btnGrabarFechaRetiro = new System.Windows.Forms.Button();
            this.btnActualizarFechaTramite = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMensaje);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnActualizarFechaPago);
            this.groupBox1.Controls.Add(this.btnGrabarFechaRetiro);
            this.groupBox1.Controls.Add(this.txtFechaRetiro);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtImporteCobrado);
            this.groupBox1.Controls.Add(this.btnActualizarFechaTramite);
            this.groupBox1.Controls.Add(this.txtFechaTramite);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCodVenta);
            this.groupBox1.Controls.Add(this.txtTope);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.txtFechaPago);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAnular);
            this.groupBox1.Controls.Add(this.btnGrabar);
            this.groupBox1.Controls.Add(this.txtImporte);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPatente);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 287);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de los gastos";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(278, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 36);
            this.button1.TabIndex = 64;
            this.button1.Text = "Anular Fecha";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFechaRetiro
            // 
            this.txtFechaRetiro.BackColor = System.Drawing.SystemColors.Control;
            this.txtFechaRetiro.Location = new System.Drawing.Point(126, 176);
            this.txtFechaRetiro.Mask = "00/00/0000";
            this.txtFechaRetiro.Name = "txtFechaRetiro";
            this.txtFechaRetiro.Size = new System.Drawing.Size(100, 23);
            this.txtFechaRetiro.TabIndex = 61;
            this.txtFechaRetiro.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 60;
            this.label6.Text = "Fecha Retiro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 59;
            this.label5.Text = "Costo";
            // 
            // txtImporteCobrado
            // 
            this.txtImporteCobrado.BackColor = System.Drawing.SystemColors.Control;
            this.txtImporteCobrado.Location = new System.Drawing.Point(126, 84);
            this.txtImporteCobrado.Name = "txtImporteCobrado";
            this.txtImporteCobrado.Size = new System.Drawing.Size(207, 23);
            this.txtImporteCobrado.TabIndex = 58;
            // 
            // txtFechaTramite
            // 
            this.txtFechaTramite.BackColor = System.Drawing.SystemColors.Control;
            this.txtFechaTramite.Location = new System.Drawing.Point(126, 142);
            this.txtFechaTramite.Mask = "00/00/0000";
            this.txtFechaTramite.Name = "txtFechaTramite";
            this.txtFechaTramite.Size = new System.Drawing.Size(100, 23);
            this.txtFechaTramite.TabIndex = 55;
            this.txtFechaTramite.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "Fecha Trámite";
            // 
            // txtCodVenta
            // 
            this.txtCodVenta.Location = new System.Drawing.Point(365, 33);
            this.txtCodVenta.Name = "txtCodVenta";
            this.txtCodVenta.Size = new System.Drawing.Size(50, 23);
            this.txtCodVenta.TabIndex = 53;
            this.txtCodVenta.Visible = false;
            // 
            // txtTope
            // 
            this.txtTope.Location = new System.Drawing.Point(309, 33);
            this.txtTope.Name = "txtTope";
            this.txtTope.Size = new System.Drawing.Size(50, 23);
            this.txtTope.TabIndex = 52;
            this.txtTope.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 51;
            this.label3.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(126, 113);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(207, 23);
            this.txtDescripcion.TabIndex = 50;
            // 
            // txtFechaPago
            // 
            this.txtFechaPago.BackColor = System.Drawing.SystemColors.Control;
            this.txtFechaPago.Location = new System.Drawing.Point(126, 209);
            this.txtFechaPago.Mask = "00/00/0000";
            this.txtFechaPago.Name = "txtFechaPago";
            this.txtFechaPago.Size = new System.Drawing.Size(100, 23);
            this.txtFechaPago.TabIndex = 49;
            this.txtFechaPago.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 48;
            this.label2.Text = "Fecha Entrega";
            // 
            // btnAnular
            // 
            this.btnAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.Location = new System.Drawing.Point(126, 230);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(75, 36);
            this.btnAnular.TabIndex = 47;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Location = new System.Drawing.Point(196, 230);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 36);
            this.btnGrabar.TabIndex = 44;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtImporte
            // 
            this.txtImporte.BackColor = System.Drawing.SystemColors.Control;
            this.txtImporte.Location = new System.Drawing.Point(126, 51);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ReadOnly = true;
            this.txtImporte.Size = new System.Drawing.Size(207, 23);
            this.txtImporte.TabIndex = 38;
            this.txtImporte.Leave += new System.EventHandler(this.txtImporte_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "Importe";
            // 
            // txtPatente
            // 
            this.txtPatente.BackColor = System.Drawing.SystemColors.Control;
            this.txtPatente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPatente.Location = new System.Drawing.Point(126, 22);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(161, 23);
            this.txtPatente.TabIndex = 35;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 17);
            this.label16.TabIndex = 34;
            this.label16.Text = "Patente";
            // 
            // btnMensaje
            // 
            this.btnMensaje.Image = ((System.Drawing.Image)(resources.GetObject("btnMensaje.Image")));
            this.btnMensaje.Location = new System.Drawing.Point(339, 84);
            this.btnMensaje.Name = "btnMensaje";
            this.btnMensaje.Size = new System.Drawing.Size(40, 28);
            this.btnMensaje.TabIndex = 65;
            this.btnMensaje.UseVisualStyleBackColor = true;
            this.btnMensaje.Click += new System.EventHandler(this.btnMensaje_Click);
            // 
            // btnActualizarFechaPago
            // 
            this.btnActualizarFechaPago.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarFechaPago.Image")));
            this.btnActualizarFechaPago.Location = new System.Drawing.Point(231, 206);
            this.btnActualizarFechaPago.Name = "btnActualizarFechaPago";
            this.btnActualizarFechaPago.Size = new System.Drawing.Size(40, 28);
            this.btnActualizarFechaPago.TabIndex = 63;
            this.btnActualizarFechaPago.UseVisualStyleBackColor = true;
            this.btnActualizarFechaPago.Click += new System.EventHandler(this.btnActualizarFechaPago_Click);
            // 
            // btnGrabarFechaRetiro
            // 
            this.btnGrabarFechaRetiro.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabarFechaRetiro.Image")));
            this.btnGrabarFechaRetiro.Location = new System.Drawing.Point(232, 170);
            this.btnGrabarFechaRetiro.Name = "btnGrabarFechaRetiro";
            this.btnGrabarFechaRetiro.Size = new System.Drawing.Size(40, 28);
            this.btnGrabarFechaRetiro.TabIndex = 62;
            this.btnGrabarFechaRetiro.UseVisualStyleBackColor = true;
            this.btnGrabarFechaRetiro.Click += new System.EventHandler(this.btnGrabarFechaRetiro_Click);
            // 
            // btnActualizarFechaTramite
            // 
            this.btnActualizarFechaTramite.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarFechaTramite.Image")));
            this.btnActualizarFechaTramite.Location = new System.Drawing.Point(232, 136);
            this.btnActualizarFechaTramite.Name = "btnActualizarFechaTramite";
            this.btnActualizarFechaTramite.Size = new System.Drawing.Size(40, 28);
            this.btnActualizarFechaTramite.TabIndex = 57;
            this.btnActualizarFechaTramite.UseVisualStyleBackColor = true;
            this.btnActualizarFechaTramite.Click += new System.EventHandler(this.BtnAgregarCheque_Click);
            // 
            // FrmRegistrarPagoGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(475, 311);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegistrarPagoGastos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Pagos";
            this.Load += new System.EventHandler(this.FrmRegistrarPagoGastos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtTope;
        private System.Windows.Forms.TextBox txtCodVenta;
        private System.Windows.Forms.MaskedTextBox txtFechaTramite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtFechaPago;
        private System.Windows.Forms.Button btnActualizarFechaTramite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImporteCobrado;
        private System.Windows.Forms.Button btnGrabarFechaRetiro;
        private System.Windows.Forms.MaskedTextBox txtFechaRetiro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnActualizarFechaPago;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMensaje;
    }
}