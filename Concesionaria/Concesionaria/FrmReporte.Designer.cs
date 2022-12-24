namespace Concesionaria
{
    partial class FrmReporte
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
            this.CONCESIONARIADataSet = new Concesionaria.CONCESIONARIADataSet();
            this.ReporteTableAdapter = new Concesionaria.CONCESIONARIADataSetTableAdapters.ReporteTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsReportes = new Concesionaria.DsReportes();
            this.Reporte1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Reporte1TableAdapter = new Concesionaria.DsReportesTableAdapters.Reporte1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CONCESIONARIADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReporteBindingSource
            // 
            this.ReporteBindingSource.DataMember = "Reporte";
            this.ReporteBindingSource.DataSource = this.CONCESIONARIADataSet;
            // 
            // CONCESIONARIADataSet
            // 
            this.CONCESIONARIADataSet.DataSetName = "CONCESIONARIADataSet";
            this.CONCESIONARIADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReporteTableAdapter
            // 
            this.ReporteTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Reporte1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Concesionaria.Reportes.ReporteBoletoCompraventa.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(791, 618);
            this.reportViewer1.TabIndex = 0;
            // 
            // DsReportes
            // 
            this.DsReportes.DataSetName = "DsReportes";
            this.DsReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Reporte1BindingSource
            // 
            this.Reporte1BindingSource.DataMember = "Reporte1";
            this.Reporte1BindingSource.DataSource = this.DsReportes;
            // 
            // Reporte1TableAdapter
            // 
            this.Reporte1TableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 642);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReporte";
            this.Load += new System.EventHandler(this.FrmReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CONCESIONARIADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource ReporteBindingSource;
        private CONCESIONARIADataSet CONCESIONARIADataSet;
        private CONCESIONARIADataSetTableAdapters.ReporteTableAdapter ReporteTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Reporte1BindingSource;
        private DsReportes DsReportes;
        private DsReportesTableAdapters.Reporte1TableAdapter Reporte1TableAdapter;
    }
}