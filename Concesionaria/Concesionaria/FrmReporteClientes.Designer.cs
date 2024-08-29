namespace Concesionaria
{
    partial class FrmReporteClientes
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsReportes = new Concesionaria.DsReportes();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReporteTableAdapter = new Concesionaria.DsReportesTableAdapters.ReporteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // ReporteBindingSource
            // 
            this.ReporteBindingSource.DataMember = "Reporte";
            this.ReporteBindingSource.DataSource = this.DsReportes;
            // 
            // DsReportes
            // 
            this.DsReportes.DataSetName = "DsReportes";
            this.DsReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReporteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Concesionaria.Reportes.ReporteListadoCliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(686, 516);
            this.reportViewer1.TabIndex = 0;
            // 
            // ReporteTableAdapter
            // 
            this.ReporteTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 525);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteClientes";
            this.Text = "Reporte de Clientes";
            this.Load += new System.EventHandler(this.FrmReporteClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReporteBindingSource;
        private DsReportes DsReportes;
        private DsReportesTableAdapters.ReporteTableAdapter ReporteTableAdapter;
    }
}