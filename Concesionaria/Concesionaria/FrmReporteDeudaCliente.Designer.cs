namespace Concesionaria
{
    partial class FrmReporteDeudaCliente
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsReportes = new Concesionaria.DsReportes();
            this.ReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReporteTableAdapter = new Concesionaria.DsReportesTableAdapters.ReporteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReporteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Concesionaria.Reportes.ReporteDeudaCliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, -2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(653, 670);
            this.reportViewer1.TabIndex = 0;
            // 
            // DsReportes
            // 
            this.DsReportes.DataSetName = "DsReportes";
            this.DsReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReporteBindingSource
            // 
            this.ReporteBindingSource.DataMember = "Reporte";
            this.ReporteBindingSource.DataSource = this.DsReportes;
            // 
            // ReporteTableAdapter
            // 
            this.ReporteTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteDeudaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 493);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReporteDeudaCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReporteDeudaCliente";
            this.Load += new System.EventHandler(this.FrmReporteDeudaCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReporteBindingSource;
        private DsReportes DsReportes;
        private DsReportesTableAdapters.ReporteTableAdapter ReporteTableAdapter;
    }
}