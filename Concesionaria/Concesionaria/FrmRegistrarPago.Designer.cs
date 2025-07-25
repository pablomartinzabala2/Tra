namespace Concesionaria
{
    partial class FrmRegistrarPago
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
            this.txtCodConcepto = new System.Windows.Forms.TextBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkPbligatorio = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbTipoPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCostoFijo = new System.Windows.Forms.CheckBox();
            this.Grupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.chkCostoFijo);
            this.Grupo.Controls.Add(this.txtCodConcepto);
            this.Grupo.Controls.Add(this.txtConcepto);
            this.Grupo.Controls.Add(this.label5);
            this.Grupo.Controls.Add(this.chkPbligatorio);
            this.Grupo.Controls.Add(this.btnCancelar);
            this.Grupo.Controls.Add(this.btnGuardar);
            this.Grupo.Controls.Add(this.txtImporte);
            this.Grupo.Controls.Add(this.label4);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.dpVencimiento);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.dpFecha);
            this.Grupo.Controls.Add(this.button1);
            this.Grupo.Controls.Add(this.cmbTipoPago);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(393, 277);
            this.Grupo.TabIndex = 16;
            this.Grupo.TabStop = false;
            this.Grupo.Text = "Información del tipo de pago";
            // 
            // txtCodConcepto
            // 
            this.txtCodConcepto.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txtCodConcepto.Location = new System.Drawing.Point(326, 24);
            this.txtCodConcepto.Name = "txtCodConcepto";
            this.txtCodConcepto.Size = new System.Drawing.Size(42, 22);
            this.txtCodConcepto.TabIndex = 82;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(102, 27);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.ReadOnly = true;
            this.txtConcepto.Size = new System.Drawing.Size(218, 22);
            this.txtConcepto.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 80;
            this.label5.Text = "Concepto";
            // 
            // chkPbligatorio
            // 
            this.chkPbligatorio.AutoSize = true;
            this.chkPbligatorio.Location = new System.Drawing.Point(102, 170);
            this.chkPbligatorio.Name = "chkPbligatorio";
            this.chkPbligatorio.Size = new System.Drawing.Size(93, 20);
            this.chkPbligatorio.TabIndex = 79;
            this.chkPbligatorio.Text = "Obligatorio";
            this.chkPbligatorio.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(183, 239);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 32);
            this.btnCancelar.TabIndex = 78;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(102, 239);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 32);
            this.btnGuardar.TabIndex = 77;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(102, 142);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(126, 22);
            this.txtImporte.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 75;
            this.label4.Text = "Importe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 74;
            this.label3.Text = "Vencimiento";
            // 
            // dpVencimiento
            // 
            this.dpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpVencimiento.Location = new System.Drawing.Point(102, 114);
            this.dpVencimiento.Name = "dpVencimiento";
            this.dpVencimiento.Size = new System.Drawing.Size(85, 22);
            this.dpVencimiento.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 72;
            this.label2.Text = "Fecha";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(102, 83);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(85, 22);
            this.dpFecha.TabIndex = 71;
            // 
            // button1
            // 
            this.button1.Image = global::Concesionaria.Properties.Resources.page_add;
            this.button1.Location = new System.Drawing.Point(323, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 28);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbTipoPago
            // 
            this.cmbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPago.FormattingEnabled = true;
            this.cmbTipoPago.Location = new System.Drawing.Point(102, 53);
            this.cmbTipoPago.Name = "cmbTipoPago";
            this.cmbTipoPago.Size = new System.Drawing.Size(215, 24);
            this.cmbTipoPago.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo De Pago";
            // 
            // chkCostoFijo
            // 
            this.chkCostoFijo.AutoSize = true;
            this.chkCostoFijo.Location = new System.Drawing.Point(102, 196);
            this.chkCostoFijo.Name = "chkCostoFijo";
            this.chkCostoFijo.Size = new System.Drawing.Size(87, 20);
            this.chkCostoFijo.TabIndex = 83;
            this.chkCostoFijo.Text = "Costo Fijo";
            this.chkCostoFijo.UseVisualStyleBackColor = true;
            // 
            // FrmRegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 301);
            this.Controls.Add(this.Grupo);
            this.Name = "FrmRegistrarPago";
            this.Text = "Registrar Pago";
            this.Load += new System.EventHandler(this.FrmRegistrarPago_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.ComboBox cmbTipoPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkPbligatorio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpVencimiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.TextBox txtCodConcepto;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkCostoFijo;
    }
}