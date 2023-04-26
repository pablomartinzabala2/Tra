namespace Concesionaria
{
    partial class FrmReporteResumenProveedor
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
            this.ReporteResumenCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsReportes = new Concesionaria.DsReportes();
            this.ReporteResumenCuentaTableAdapter = new Concesionaria.DsReportesTableAdapters.ReporteResumenCuentaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteResumenCuentaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReporteResumenCuentaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Concesionaria.Reportes.ReporteResumenCuenta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(712, 476);
            this.reportViewer1.TabIndex = 0;
            // 
            // ReporteResumenCuentaBindingSource
            // 
            this.ReporteResumenCuentaBindingSource.DataMember = "ReporteResumenCuenta";
            this.ReporteResumenCuentaBindingSource.DataSource = this.DsReportes;
            // 
            // DsReportes
            // 
            this.DsReportes.DataSetName = "DsReportes";
            this.DsReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReporteResumenCuentaTableAdapter
            // 
            this.ReporteResumenCuentaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteResumenProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 493);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReporteResumenProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReporteResumenProveedor";
            this.Load += new System.EventHandler(this.FrmReporteResumenProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteResumenCuentaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReporteResumenCuentaBindingSource;
        private DsReportes DsReportes;
        private DsReportesTableAdapters.ReporteResumenCuentaTableAdapter ReporteResumenCuentaTableAdapter;
    }
}