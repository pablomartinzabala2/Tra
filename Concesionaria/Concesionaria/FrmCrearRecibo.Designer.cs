namespace Concesionaria
{
    partial class FrmCrearRecibo
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
            this.SuspendLayout();
            // 
            // FrmCrearRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(390, 261);
            this.Name = "FrmCrearRecibo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.ComboBox cmbDocumento;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView GrillaTransferencia;
        private System.Windows.Forms.Button btnquitarTransferencia;
        private System.Windows.Forms.Button btnAgregarTransferencia;
        private System.Windows.Forms.ComboBox cmbBancoTransferencia;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.TextBox txtNumeroTransferencia;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TextBox txtImporteTransferencia;
        private System.Windows.Forms.Label txtImporte;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button btnNuevaEntidadPrendaria;
        private System.Windows.Forms.DateTimePicker dpFechaVencimientoPrenda;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.DataGridView GrillaPrendas;
        private System.Windows.Forms.ComboBox CmbEntidadPrendaria;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtImportePrenda;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btnEliminarPrenda;
        private System.Windows.Forms.Button btnAgregarPrenda;
        private System.Windows.Forms.Button btnAbrircPrenda;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.DateTimePicker dpFechaCompromiso;
        private System.Windows.Forms.TextBox txtCuotasCobranza;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.DataGridView GrillaCobranza;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox txtImporteCobranza;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button BtnAgregarCobranza;
        private System.Windows.Forms.Button btnAbrirCobranzas;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.Button btnBorrarCheque;
        private System.Windows.Forms.DataGridView GrillaCheques;
        private System.Windows.Forms.ComboBox CmbBanco;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtImporteCheque;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Button BtnAgregarCheque;
        private System.Windows.Forms.Button btnNuevaBanco;
        private System.Windows.Forms.TabPage tabPage17;
        private System.Windows.Forms.Button btnNuevaTarjeta;
        private System.Windows.Forms.TextBox txtMontoTarjeta;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.DataGridView GrillaTarjeta;
        private System.Windows.Forms.TextBox txtImporteTarjeta;
        private System.Windows.Forms.ComboBox cmbTarjeta;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Button btnQuitarTarjeta;
        private System.Windows.Forms.Button btnAgregarTarjeta;
        private System.Windows.Forms.DateTimePicker dpFechaVencimiento;
        private System.Windows.Forms.Button btnGuardarRecibo;
    }
}