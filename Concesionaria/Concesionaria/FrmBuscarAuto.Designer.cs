﻿namespace Concesionaria
{
    partial class FrmBuscarAuto
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkStock = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.tableAdapterManager1 = new Concesionaria.COPIACONCESIONARIADataSetTableAdapters.TableAdapterManager();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.txtPatente);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.flowLayoutPanel1);
            this.Grupo.Controls.Add(this.chkStock);
            this.Grupo.Controls.Add(this.btnAceptar);
            this.Grupo.Controls.Add(this.btnBuscar);
            this.Grupo.Controls.Add(this.cmbMarca);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 11);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(641, 384);
            this.Grupo.TabIndex = 2;
            this.Grupo.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(348, 188);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 45;
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Checked = true;
            this.chkStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStock.Location = new System.Drawing.Point(543, 14);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(62, 21);
            this.chkStock.TabIndex = 44;
            this.chkStock.Text = "Stcok";
            this.chkStock.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(543, 342);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 43;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Concesionaria.Properties.Resources.zoom2;
            this.btnBuscar.Location = new System.Drawing.Point(490, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(40, 27);
            this.btnBuscar.TabIndex = 42;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(68, 12);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(246, 24);
            this.cmbMarca.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Marca";
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(15, 42);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.ShowEditingIcon = false;
            this.Grilla.Size = new System.Drawing.Size(603, 259);
            this.Grilla.TabIndex = 26;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.ReporteAutoTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = Concesionaria.COPIACONCESIONARIADataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 46;
            this.label2.Text = "Patente";
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(383, 12);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(101, 23);
            this.txtPatente.TabIndex = 79;
            // 
            // FrmBuscarAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(648, 407);
            this.Controls.Add(this.Grupo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuscarAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuscarAuto";
            this.Load += new System.EventHandler(this.FrmBuscarAuto_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chkStock;
        private COPIACONCESIONARIADataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPatente;
    }
}