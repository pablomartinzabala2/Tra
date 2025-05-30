namespace Concesionaria
{
    partial class FrmDistanciaFletes
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
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnCCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtKm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.cmbProvinciaDestino = new System.Windows.Forms.ComboBox();
            this.cmbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.cmbProvinciaOrigen = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.btnCCancelar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.txtKm);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbCiudadDestino);
            this.groupBox1.Controls.Add(this.cmbProvinciaDestino);
            this.groupBox1.Controls.Add(this.cmbCiudadOrigen);
            this.groupBox1.Controls.Add(this.cmbProvinciaOrigen);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 304);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(258, 249);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 30);
            this.btnConsultar.TabIndex = 53;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnCCancelar
            // 
            this.btnCCancelar.Location = new System.Drawing.Point(177, 249);
            this.btnCCancelar.Name = "btnCCancelar";
            this.btnCCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCCancelar.TabIndex = 52;
            this.btnCCancelar.Text = "Cancelar";
            this.btnCCancelar.UseVisualStyleBackColor = true;
            this.btnCCancelar.Click += new System.EventHandler(this.btnCCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(96, 249);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.TabIndex = 51;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtKm
            // 
            this.txtKm.Location = new System.Drawing.Point(15, 192);
            this.txtKm.Name = "txtKm";
            this.txtKm.Size = new System.Drawing.Size(157, 21);
            this.txtKm.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 16);
            this.label7.TabIndex = 49;
            this.label7.Text = "Kilometros de dsitancia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 48;
            this.label6.Text = "Ciudad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 47;
            this.label5.Text = "Provincia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "Destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "Ciudad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "Provincia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Origen";
            // 
            // cmbCiudadDestino
            // 
            this.cmbCiudadDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudadDestino.FormattingEnabled = true;
            this.cmbCiudadDestino.Location = new System.Drawing.Point(216, 121);
            this.cmbCiudadDestino.Name = "cmbCiudadDestino";
            this.cmbCiudadDestino.Size = new System.Drawing.Size(196, 23);
            this.cmbCiudadDestino.TabIndex = 42;
            // 
            // cmbProvinciaDestino
            // 
            this.cmbProvinciaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvinciaDestino.FormattingEnabled = true;
            this.cmbProvinciaDestino.Location = new System.Drawing.Point(227, 63);
            this.cmbProvinciaDestino.Name = "cmbProvinciaDestino";
            this.cmbProvinciaDestino.Size = new System.Drawing.Size(185, 23);
            this.cmbProvinciaDestino.TabIndex = 41;
            this.cmbProvinciaDestino.SelectedIndexChanged += new System.EventHandler(this.cmbProvinciaDestino_SelectedIndexChanged);
            // 
            // cmbCiudadOrigen
            // 
            this.cmbCiudadOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudadOrigen.FormattingEnabled = true;
            this.cmbCiudadOrigen.Location = new System.Drawing.Point(15, 121);
            this.cmbCiudadOrigen.Name = "cmbCiudadOrigen";
            this.cmbCiudadOrigen.Size = new System.Drawing.Size(157, 23);
            this.cmbCiudadOrigen.TabIndex = 40;
            // 
            // cmbProvinciaOrigen
            // 
            this.cmbProvinciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvinciaOrigen.FormattingEnabled = true;
            this.cmbProvinciaOrigen.Location = new System.Drawing.Point(15, 63);
            this.cmbProvinciaOrigen.Name = "cmbProvinciaOrigen";
            this.cmbProvinciaOrigen.Size = new System.Drawing.Size(157, 23);
            this.cmbProvinciaOrigen.TabIndex = 39;
            this.cmbProvinciaOrigen.SelectedIndexChanged += new System.EventHandler(this.cmbProvinciaOrigen_SelectedIndexChanged);
            // 
            // FrmDistanciaFletes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 319);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDistanciaFletes";
            this.Text = "FrmDistanciaFletes";
            this.Load += new System.EventHandler(this.FrmDistanciaFletes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCiudadOrigen;
        private System.Windows.Forms.ComboBox cmbProvinciaOrigen;
        private System.Windows.Forms.ComboBox cmbCiudadDestino;
        private System.Windows.Forms.ComboBox cmbProvinciaDestino;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnCCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtKm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}