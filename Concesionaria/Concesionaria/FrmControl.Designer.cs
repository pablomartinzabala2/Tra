﻿namespace Concesionaria
{
    partial class FrmControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnImprimirReporte = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblVencidas = new System.Windows.Forms.Label();
            this.ChkVencida = new System.Windows.Forms.CheckBox();
            this.btnCobroPrenda = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(10, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1117, 25);
            this.label2.TabIndex = 59;
            this.label2.Text = "Control de operaciones";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.txtDescripcion);
            this.Grupo.Controls.Add(this.label5);
            this.Grupo.Controls.Add(this.btnImprimirReporte);
            this.Grupo.Controls.Add(this.btnImprimir);
            this.Grupo.Controls.Add(this.dpFecha);
            this.Grupo.Controls.Add(this.lblVencidas);
            this.Grupo.Controls.Add(this.ChkVencida);
            this.Grupo.Controls.Add(this.btnCobroPrenda);
            this.Grupo.Controls.Add(this.label4);
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.btnBuscar);
            this.Grupo.Controls.Add(this.txtApellido);
            this.Grupo.Controls.Add(this.txtPatente);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(5, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(1133, 504);
            this.Grupo.TabIndex = 60;
            this.Grupo.TabStop = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(611, 13);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(124, 23);
            this.txtDescripcion.TabIndex = 74;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(554, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 73;
            this.label5.Text = "Descr.";
            // 
            // btnImprimirReporte
            // 
            this.btnImprimirReporte.Image = global::Concesionaria.Properties.Resources.printer1;
            this.btnImprimirReporte.Location = new System.Drawing.Point(924, 1);
            this.btnImprimirReporte.Name = "btnImprimirReporte";
            this.btnImprimirReporte.Size = new System.Drawing.Size(40, 26);
            this.btnImprimirReporte.TabIndex = 72;
            this.btnImprimirReporte.UseVisualStyleBackColor = true;
            this.btnImprimirReporte.Click += new System.EventHandler(this.btnImprimirReporte_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.AutoSize = true;
            this.btnImprimir.Image = global::Concesionaria.Properties.Resources.printer;
            this.btnImprimir.Location = new System.Drawing.Point(1028, 10);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(0, 17);
            this.btnImprimir.TabIndex = 71;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(459, 12);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(87, 23);
            this.dpFecha.TabIndex = 70;
            // 
            // lblVencidas
            // 
            this.lblVencidas.AutoSize = true;
            this.lblVencidas.Location = new System.Drawing.Point(980, 10);
            this.lblVencidas.Name = "lblVencidas";
            this.lblVencidas.Size = new System.Drawing.Size(66, 17);
            this.lblVencidas.TabIndex = 64;
            this.lblVencidas.Text = "Vencidas";
            // 
            // ChkVencida
            // 
            this.ChkVencida.AutoSize = true;
            this.ChkVencida.Checked = true;
            this.ChkVencida.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkVencida.Location = new System.Drawing.Point(741, 9);
            this.ChkVencida.Name = "ChkVencida";
            this.ChkVencida.Size = new System.Drawing.Size(85, 21);
            this.ChkVencida.TabIndex = 63;
            this.ChkVencida.Text = "Vencidas";
            this.ChkVencida.UseVisualStyleBackColor = true;
            // 
            // btnCobroPrenda
            // 
            this.btnCobroPrenda.Image = global::Concesionaria.Properties.Resources.money_euro;
            this.btnCobroPrenda.Location = new System.Drawing.Point(878, 4);
            this.btnCobroPrenda.Name = "btnCobroPrenda";
            this.btnCobroPrenda.Size = new System.Drawing.Size(40, 26);
            this.btnCobroPrenda.TabIndex = 62;
            this.btnCobroPrenda.UseVisualStyleBackColor = true;
            this.btnCobroPrenda.Click += new System.EventHandler(this.btnCobroPrenda_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 61;
            this.label4.Text = "Fecha";
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(10, 67);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(1117, 415);
            this.Grilla.TabIndex = 52;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Concesionaria.Properties.Resources.zoom2;
            this.btnBuscar.Location = new System.Drawing.Point(832, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(40, 26);
            this.btnBuscar.TabIndex = 51;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Location = new System.Drawing.Point(233, 14);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(158, 23);
            this.txtApellido.TabIndex = 3;
            // 
            // txtPatente
            // 
            this.txtPatente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPatente.Location = new System.Drawing.Point(70, 13);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(100, 23);
            this.txtPatente.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patente";
            // 
            // FrmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1150, 518);
            this.Controls.Add(this.Grupo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control";
            this.Load += new System.EventHandler(this.FrmControl_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCobroPrenda;
        private System.Windows.Forms.CheckBox ChkVencida;
        private System.Windows.Forms.Label lblVencidas;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label btnImprimir;
        private System.Windows.Forms.Button btnImprimirReporte;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label5;
    }
}