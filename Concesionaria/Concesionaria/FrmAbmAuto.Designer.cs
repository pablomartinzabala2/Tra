﻿namespace Concesionaria
{
    partial class FrmAbmAuto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbmAuto));
            this.BarraBotones = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnAceptar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.btnNuevoColor = new System.Windows.Forms.Button();
            this.cmb_CodColor = new System.Windows.Forms.ComboBox();
            this.ChkAltaStock = new System.Windows.Forms.CheckBox();
            this.btnAgregarCiudad = new System.Windows.Forms.Button();
            this.btnSubirImagen = new System.Windows.Forms.Button();
            this.txt_RutaImagen = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Imagen = new System.Windows.Forms.PictureBox();
            this.cmb_CodSucursal = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.cmb_CodTipoUtilitario = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.txt_Ubicacion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_NumeroInterno = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_CodTipoCombustible = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Color = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Chasis = new System.Windows.Forms.TextBox();
            this.txt_Motor = new System.Windows.Forms.TextBox();
            this.txtCodStock = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCodAuto = new System.Windows.Forms.TextBox();
            this.cmb_CodCiudad = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Kilometros = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Descripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_CodMarca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Patente = new System.Windows.Forms.TextBox();
            this.lblPatente = new System.Windows.Forms.Label();
            this.cmb_CodAnio = new System.Windows.Forms.ComboBox();
            this.btnAgregarAnio = new System.Windows.Forms.Button();
            this.BarraBotones.SuspendLayout();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen)).BeginInit();
            this.SuspendLayout();
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
            this.BarraBotones.Size = new System.Drawing.Size(829, 39);
            this.BarraBotones.TabIndex = 10;
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
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click_1);
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
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click_1);
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
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(36, 36);
            this.btnAceptar.Text = "Grabar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(36, 36);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnAbrir
            // 
            this.btnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(36, 36);
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click_1);
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
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.btnAgregarAnio);
            this.Grupo.Controls.Add(this.cmb_CodAnio);
            this.Grupo.Controls.Add(this.btnNuevoColor);
            this.Grupo.Controls.Add(this.cmb_CodColor);
            this.Grupo.Controls.Add(this.ChkAltaStock);
            this.Grupo.Controls.Add(this.btnAgregarCiudad);
            this.Grupo.Controls.Add(this.btnSubirImagen);
            this.Grupo.Controls.Add(this.txt_RutaImagen);
            this.Grupo.Controls.Add(this.label13);
            this.Grupo.Controls.Add(this.Imagen);
            this.Grupo.Controls.Add(this.cmb_CodSucursal);
            this.Grupo.Controls.Add(this.label35);
            this.Grupo.Controls.Add(this.cmb_CodTipoUtilitario);
            this.Grupo.Controls.Add(this.label34);
            this.Grupo.Controls.Add(this.label10);
            this.Grupo.Controls.Add(this.cmbProvincia);
            this.Grupo.Controls.Add(this.txt_Ubicacion);
            this.Grupo.Controls.Add(this.label12);
            this.Grupo.Controls.Add(this.txt_NumeroInterno);
            this.Grupo.Controls.Add(this.label11);
            this.Grupo.Controls.Add(this.label9);
            this.Grupo.Controls.Add(this.cmb_CodTipoCombustible);
            this.Grupo.Controls.Add(this.label8);
            this.Grupo.Controls.Add(this.txt_Color);
            this.Grupo.Controls.Add(this.label7);
            this.Grupo.Controls.Add(this.label6);
            this.Grupo.Controls.Add(this.txt_Chasis);
            this.Grupo.Controls.Add(this.txt_Motor);
            this.Grupo.Controls.Add(this.txtCodStock);
            this.Grupo.Controls.Add(this.button1);
            this.Grupo.Controls.Add(this.txtCodAuto);
            this.Grupo.Controls.Add(this.cmb_CodCiudad);
            this.Grupo.Controls.Add(this.label5);
            this.Grupo.Controls.Add(this.txt_Kilometros);
            this.Grupo.Controls.Add(this.label4);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.txt_Descripcion);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.cmb_CodMarca);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Controls.Add(this.txt_Patente);
            this.Grupo.Controls.Add(this.lblPatente);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 41);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(801, 434);
            this.Grupo.TabIndex = 11;
            this.Grupo.TabStop = false;
            this.Grupo.Text = "Información del vehículo";
            // 
            // btnNuevoColor
            // 
            this.btnNuevoColor.Image = global::Concesionaria.Properties.Resources.page_add;
            this.btnNuevoColor.Location = new System.Drawing.Point(765, 134);
            this.btnNuevoColor.Name = "btnNuevoColor";
            this.btnNuevoColor.Size = new System.Drawing.Size(40, 28);
            this.btnNuevoColor.TabIndex = 58;
            this.btnNuevoColor.UseVisualStyleBackColor = true;
            this.btnNuevoColor.Click += new System.EventHandler(this.btnNuevoColor_Click);
            // 
            // cmb_CodColor
            // 
            this.cmb_CodColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CodColor.FormattingEnabled = true;
            this.cmb_CodColor.Location = new System.Drawing.Point(500, 138);
            this.cmb_CodColor.Name = "cmb_CodColor";
            this.cmb_CodColor.Size = new System.Drawing.Size(259, 24);
            this.cmb_CodColor.TabIndex = 57;
            // 
            // ChkAltaStock
            // 
            this.ChkAltaStock.AutoSize = true;
            this.ChkAltaStock.Location = new System.Drawing.Point(514, 272);
            this.ChkAltaStock.Name = "ChkAltaStock";
            this.ChkAltaStock.Size = new System.Drawing.Size(87, 20);
            this.ChkAltaStock.TabIndex = 56;
            this.ChkAltaStock.Text = "Alta Stock";
            this.ChkAltaStock.UseVisualStyleBackColor = true;
            // 
            // btnAgregarCiudad
            // 
            this.btnAgregarCiudad.Image = global::Concesionaria.Properties.Resources.page_add;
            this.btnAgregarCiudad.Location = new System.Drawing.Point(761, 102);
            this.btnAgregarCiudad.Name = "btnAgregarCiudad";
            this.btnAgregarCiudad.Size = new System.Drawing.Size(40, 28);
            this.btnAgregarCiudad.TabIndex = 17;
            this.btnAgregarCiudad.UseVisualStyleBackColor = true;
            this.btnAgregarCiudad.Click += new System.EventHandler(this.btnAgregarCiudad_Click);
            // 
            // btnSubirImagen
            // 
            this.btnSubirImagen.Location = new System.Drawing.Point(369, 330);
            this.btnSubirImagen.Name = "btnSubirImagen";
            this.btnSubirImagen.Size = new System.Drawing.Size(75, 34);
            this.btnSubirImagen.TabIndex = 55;
            this.btnSubirImagen.Text = "Abrir";
            this.btnSubirImagen.UseVisualStyleBackColor = true;
            this.btnSubirImagen.Visible = false;
            this.btnSubirImagen.Click += new System.EventHandler(this.btnSubirImagen_Click);
            // 
            // txt_RutaImagen
            // 
            this.txt_RutaImagen.Location = new System.Drawing.Point(514, 359);
            this.txt_RutaImagen.Name = "txt_RutaImagen";
            this.txt_RutaImagen.Size = new System.Drawing.Size(132, 22);
            this.txt_RutaImagen.TabIndex = 54;
            this.txt_RutaImagen.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 258);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 16);
            this.label13.TabIndex = 53;
            this.label13.Text = "Imagen";
            this.label13.Visible = false;
            // 
            // Imagen
            // 
            this.Imagen.Location = new System.Drawing.Point(112, 258);
            this.Imagen.Name = "Imagen";
            this.Imagen.Size = new System.Drawing.Size(246, 170);
            this.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Imagen.TabIndex = 52;
            this.Imagen.TabStop = false;
            this.Imagen.Visible = false;
            // 
            // cmb_CodSucursal
            // 
            this.cmb_CodSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CodSucursal.FormattingEnabled = true;
            this.cmb_CodSucursal.Location = new System.Drawing.Point(500, 231);
            this.cmb_CodSucursal.Name = "cmb_CodSucursal";
            this.cmb_CodSucursal.Size = new System.Drawing.Size(259, 24);
            this.cmb_CodSucursal.TabIndex = 51;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(410, 231);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(69, 16);
            this.label35.TabIndex = 50;
            this.label35.Text = "Ubicación";
            // 
            // cmb_CodTipoUtilitario
            // 
            this.cmb_CodTipoUtilitario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CodTipoUtilitario.FormattingEnabled = true;
            this.cmb_CodTipoUtilitario.Location = new System.Drawing.Point(112, 228);
            this.cmb_CodTipoUtilitario.Name = "cmb_CodTipoUtilitario";
            this.cmb_CodTipoUtilitario.Size = new System.Drawing.Size(246, 24);
            this.cmb_CodTipoUtilitario.TabIndex = 49;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(26, 231);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(36, 16);
            this.label34.TabIndex = 48;
            this.label34.Text = "Tipo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 47;
            this.label10.Text = "Provincia";
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(112, 110);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(246, 24);
            this.cmbProvincia.TabIndex = 46;
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            // 
            // txt_Ubicacion
            // 
            this.txt_Ubicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Ubicacion.Location = new System.Drawing.Point(112, 202);
            this.txt_Ubicacion.Name = "txt_Ubicacion";
            this.txt_Ubicacion.Size = new System.Drawing.Size(246, 22);
            this.txt_Ubicacion.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 16);
            this.label12.TabIndex = 44;
            this.label12.Text = "Ubicación";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // txt_NumeroInterno
            // 
            this.txt_NumeroInterno.Location = new System.Drawing.Point(500, 199);
            this.txt_NumeroInterno.MaxLength = 4;
            this.txt_NumeroInterno.Name = "txt_NumeroInterno";
            this.txt_NumeroInterno.Size = new System.Drawing.Size(246, 22);
            this.txt_NumeroInterno.TabIndex = 43;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(410, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 16);
            this.label11.TabIndex = 42;
            this.label11.Text = "Nro Interno";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 16);
            this.label9.TabIndex = 40;
            this.label9.Text = "Combustible";
            // 
            // cmb_CodTipoCombustible
            // 
            this.cmb_CodTipoCombustible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CodTipoCombustible.FormattingEnabled = true;
            this.cmb_CodTipoCombustible.Location = new System.Drawing.Point(112, 171);
            this.cmb_CodTipoCombustible.Name = "cmb_CodTipoCombustible";
            this.cmb_CodTipoCombustible.Size = new System.Drawing.Size(246, 24);
            this.cmb_CodTipoCombustible.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(410, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 38;
            this.label8.Text = "Color";
            // 
            // txt_Color
            // 
            this.txt_Color.Location = new System.Drawing.Point(513, 320);
            this.txt_Color.Name = "txt_Color";
            this.txt_Color.Size = new System.Drawing.Size(246, 22);
            this.txt_Color.TabIndex = 37;
            this.txt_Color.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "Motor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(410, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 35;
            this.label6.Text = "Chasis";
            // 
            // txt_Chasis
            // 
            this.txt_Chasis.Location = new System.Drawing.Point(500, 168);
            this.txt_Chasis.Name = "txt_Chasis";
            this.txt_Chasis.Size = new System.Drawing.Size(246, 22);
            this.txt_Chasis.TabIndex = 34;
            // 
            // txt_Motor
            // 
            this.txt_Motor.Location = new System.Drawing.Point(112, 143);
            this.txt_Motor.Name = "txt_Motor";
            this.txt_Motor.Size = new System.Drawing.Size(246, 22);
            this.txt_Motor.TabIndex = 33;
            // 
            // txtCodStock
            // 
            this.txtCodStock.Location = new System.Drawing.Point(557, 28);
            this.txtCodStock.Name = "txtCodStock";
            this.txtCodStock.Size = new System.Drawing.Size(50, 22);
            this.txtCodStock.TabIndex = 28;
            this.txtCodStock.Visible = false;
            // 
            // button1
            // 
            this.button1.Image = global::Concesionaria.Properties.Resources.page_add;
            this.button1.Location = new System.Drawing.Point(364, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 28);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCodAuto
            // 
            this.txtCodAuto.Location = new System.Drawing.Point(540, 25);
            this.txtCodAuto.Name = "txtCodAuto";
            this.txtCodAuto.Size = new System.Drawing.Size(50, 22);
            this.txtCodAuto.TabIndex = 14;
            this.txtCodAuto.Visible = false;
            // 
            // cmb_CodCiudad
            // 
            this.cmb_CodCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CodCiudad.FormattingEnabled = true;
            this.cmb_CodCiudad.Location = new System.Drawing.Point(504, 106);
            this.cmb_CodCiudad.Name = "cmb_CodCiudad";
            this.cmb_CodCiudad.Size = new System.Drawing.Size(246, 24);
            this.cmb_CodCiudad.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(410, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ciudad";
            // 
            // txt_Kilometros
            // 
            this.txt_Kilometros.Location = new System.Drawing.Point(504, 78);
            this.txt_Kilometros.Name = "txt_Kilometros";
            this.txt_Kilometros.Size = new System.Drawing.Size(246, 22);
            this.txt_Kilometros.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Año";
            // 
            // txt_Descripcion
            // 
            this.txt_Descripcion.Location = new System.Drawing.Point(504, 51);
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(246, 22);
            this.txt_Descripcion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descripción";
            // 
            // cmb_CodMarca
            // 
            this.cmb_CodMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CodMarca.FormattingEnabled = true;
            this.cmb_CodMarca.Location = new System.Drawing.Point(112, 54);
            this.cmb_CodMarca.Name = "cmb_CodMarca";
            this.cmb_CodMarca.Size = new System.Drawing.Size(246, 24);
            this.cmb_CodMarca.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Marca";
            // 
            // txt_Patente
            // 
            this.txt_Patente.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Patente.Location = new System.Drawing.Point(112, 25);
            this.txt_Patente.Name = "txt_Patente";
            this.txt_Patente.Size = new System.Drawing.Size(100, 22);
            this.txt_Patente.TabIndex = 1;
            // 
            // lblPatente
            // 
            this.lblPatente.Location = new System.Drawing.Point(26, 25);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(80, 30);
            this.lblPatente.TabIndex = 0;
            this.lblPatente.Text = "Patente";
            // 
            // cmb_CodAnio
            // 
            this.cmb_CodAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CodAnio.FormattingEnabled = true;
            this.cmb_CodAnio.Location = new System.Drawing.Point(112, 87);
            this.cmb_CodAnio.Name = "cmb_CodAnio";
            this.cmb_CodAnio.Size = new System.Drawing.Size(246, 24);
            this.cmb_CodAnio.TabIndex = 59;
            // 
            // btnAgregarAnio
            // 
            this.btnAgregarAnio.Image = global::Concesionaria.Properties.Resources.page_add;
            this.btnAgregarAnio.Location = new System.Drawing.Point(369, 87);
            this.btnAgregarAnio.Name = "btnAgregarAnio";
            this.btnAgregarAnio.Size = new System.Drawing.Size(40, 28);
            this.btnAgregarAnio.TabIndex = 60;
            this.btnAgregarAnio.UseVisualStyleBackColor = true;
            this.btnAgregarAnio.Click += new System.EventHandler(this.btnAgregarAnio_Click);
            // 
            // FrmAbmAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(829, 487);
            this.Controls.Add(this.Grupo);
            this.Controls.Add(this.BarraBotones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbmAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAbmAuto";
            this.Load += new System.EventHandler(this.FrmAbmAuto_Load);
            this.BarraBotones.ResumeLayout(false);
            this.BarraBotones.PerformLayout();
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip BarraBotones;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnAceptar;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnAbrir;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.TextBox txtCodStock;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAgregarCiudad;
        private System.Windows.Forms.TextBox txtCodAuto;
        private System.Windows.Forms.ComboBox cmb_CodCiudad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Kilometros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_CodMarca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Patente;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.TextBox txt_Motor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Chasis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Color;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_CodTipoCombustible;
        private System.Windows.Forms.TextBox txt_NumeroInterno;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Ubicacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.ComboBox cmb_CodTipoUtilitario;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ComboBox cmb_CodSucursal;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox Imagen;
        private System.Windows.Forms.TextBox txt_RutaImagen;
        private System.Windows.Forms.Button btnSubirImagen;
        private System.Windows.Forms.CheckBox ChkAltaStock;
        private System.Windows.Forms.ComboBox cmb_CodColor;
        private System.Windows.Forms.Button btnNuevoColor;
        private System.Windows.Forms.ComboBox cmb_CodAnio;
        private System.Windows.Forms.Button btnAgregarAnio;
    }
}