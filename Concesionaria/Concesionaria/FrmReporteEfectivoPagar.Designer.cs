namespace Concesionaria
{
    partial class FrmReporteEfectivoPagar
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
            this.reporte1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsReportesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsReportes = new Concesionaria.DsReportes();
            this.reporteAutoTableAdapter1 = new Concesionaria.CONCESIONARIADataSetTableAdapters.ReporteAutoTableAdapter();
            this.reporte1TableAdapter = new Concesionaria.DsReportesTableAdapters.Reporte1TableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.reporte1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // reporte1BindingSource
            // 
            this.reporte1BindingSource.DataMember = "Reporte1";
            this.reporte1BindingSource.DataSource = this.dsReportesBindingSource;
            // 
            // dsReportesBindingSource
            // 
            this.dsReportesBindingSource.DataSource = this.dsReportes;
            this.dsReportesBindingSource.Position = 0;
            // 
            // dsReportes
            // 
            this.dsReportes.DataSetName = "DsReportes";
            this.dsReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteAutoTableAdapter1
            // 
            this.reporteAutoTableAdapter1.ClearBeforeFill = true;
            // 
            // reporte1TableAdapter
            // 
            this.reporte1TableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reporte1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Concesionaria.Reportes.ReporteEfectivoPagar.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(853, 472);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmReporteEfectivoPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 472);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteEfectivoPagar";
            this.Text = "FrmReporteEfectivoPagar";
            this.Load += new System.EventHandler(this.FrmReporteEfectivoPagar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reporte1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CONCESIONARIADataSetTableAdapters.ReporteAutoTableAdapter reporteAutoTableAdapter1;
        private DsReportes dsReportes;
        private System.Windows.Forms.BindingSource dsReportesBindingSource;
        private System.Windows.Forms.BindingSource reporte1BindingSource;
        private DsReportesTableAdapters.Reporte1TableAdapter reporte1TableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}