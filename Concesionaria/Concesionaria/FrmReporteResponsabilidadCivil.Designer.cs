namespace Concesionaria
{
    partial class FrmReporteResponsabilidadCivil
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
            this.AutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsReportes = new Concesionaria.DsReportes();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.AutoTableAdapter = new Concesionaria.DsReportesTableAdapters.AutoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.AutoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // AutoBindingSource
            // 
            this.AutoBindingSource.DataMember = "Auto";
            this.AutoBindingSource.DataSource = this.DsReportes;
            // 
            // DsReportes
            // 
            this.DsReportes.DataSetName = "DsReportes";
            this.DsReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.AutoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Concesionaria.Reportes.ReporteResponsabilidadCivil.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(822, 651);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // AutoTableAdapter
            // 
            this.AutoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteResponsabilidadCivil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 667);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteResponsabilidadCivil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReporteResponsabilidadCivil";
            this.Load += new System.EventHandler(this.FrmReporteResponsabilidadCivil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AutoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource AutoBindingSource;
        private DsReportes DsReportes;
        private DsReportesTableAdapters.AutoTableAdapter AutoTableAdapter;
    }
}