namespace Concesionaria
{
    partial class FrmAbmVendedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbmVendedor));
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.chk_Activo = new System.Windows.Forms.CheckBox();
            this.txt_Apellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BarraBotones = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnAceptar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.Grupo.SuspendLayout();
            this.BarraBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.chk_Activo);
            this.Grupo.Controls.Add(this.txt_Apellido);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.txtCodigo);
            this.Grupo.Controls.Add(this.txt_Nombre);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 57);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(379, 134);
            this.Grupo.TabIndex = 1;
            this.Grupo.TabStop = false;
            this.Grupo.Text = "Información del Vendedor";
            // 
            // chk_Activo
            // 
            this.chk_Activo.AutoSize = true;
            this.chk_Activo.Location = new System.Drawing.Point(9, 95);
            this.chk_Activo.Name = "chk_Activo";
            this.chk_Activo.Size = new System.Drawing.Size(64, 20);
            this.chk_Activo.TabIndex = 6;
            this.chk_Activo.Text = "Activo";
            this.chk_Activo.UseVisualStyleBackColor = true;
            // 
            // txt_Apellido
            // 
            this.txt_Apellido.Location = new System.Drawing.Point(76, 58);
            this.txt_Apellido.Name = "txt_Apellido";
            this.txt_Apellido.Size = new System.Drawing.Size(277, 22);
            this.txt_Apellido.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Apellido";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(238, 0);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(57, 22);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.Visible = false;
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(76, 30);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(277, 22);
            this.txt_Nombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // BarraBotones
            // 
            this.BarraBotones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar,
            this.btnAceptar,
            this.btnCancelar,
            this.btnAbrir,
            this.btnImprimir,
            this.btnSalir});
            this.BarraBotones.Location = new System.Drawing.Point(0, 0);
            this.BarraBotones.Name = "BarraBotones";
            this.BarraBotones.Size = new System.Drawing.Size(402, 39);
            this.BarraBotones.TabIndex = 15;
            this.BarraBotones.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(36, 36);
            this.btnNuevo.Text = "toolStripButton1";
            this.btnNuevo.ToolTipText = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(36, 36);
            this.btnEditar.Text = "toolStripButton2";
            this.btnEditar.ToolTipText = "Modificar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(36, 36);
            this.btnEliminar.Text = "toolStripButton3";
            this.btnEliminar.ToolTipText = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(36, 36);
            this.btnAceptar.Text = "Grabar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(36, 36);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(36, 36);
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(36, 36);
            this.btnImprimir.Text = "toolStripButton1";
            this.btnImprimir.ToolTipText = "Imprimir";
            // 
            // btnSalir
            // 
            this.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(36, 36);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmAbmVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 212);
            this.Controls.Add(this.BarraBotones);
            this.Controls.Add(this.Grupo);
            this.Name = "FrmAbmVendedor";
            this.Text = "FrmAbmVendedor";
            this.Load += new System.EventHandler(this.FrmAbmVendedor_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            this.BarraBotones.ResumeLayout(false);
            this.BarraBotones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Apellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip BarraBotones;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnAceptar;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnAbrir;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.CheckBox chk_Activo;
    }
}