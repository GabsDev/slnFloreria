namespace Capa.UI.Reportes
{
    partial class frmReporteFacturacion
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
            this.facturarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetFloristeria = new Capa.UI.Reportes.DataSetFloristeria();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.facturarTableAdapter = new Capa.UI.Reportes.DataSetFloristeriaTableAdapters.FacturarTableAdapter();
            this.tableAdapterManager = new Capa.UI.Reportes.DataSetFloristeriaTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.facturarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFloristeria)).BeginInit();
            this.SuspendLayout();
            // 
            // facturarBindingSource
            // 
            this.facturarBindingSource.DataMember = "Facturar";
            this.facturarBindingSource.DataSource = this.dataSetFloristeria;
            this.facturarBindingSource.CurrentChanged += new System.EventHandler(this.facturarBindingSource_CurrentChanged);
            // 
            // dataSetFloristeria
            // 
            this.dataSetFloristeria.DataSetName = "DataSetFloristeria";
            this.dataSetFloristeria.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetFacturacion";
            reportDataSource1.Value = this.facturarBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Capa.UI.Reportes.rptFacturacion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(873, 498);
            this.reportViewer1.TabIndex = 0;
            // 
            // facturarTableAdapter
            // 
            this.facturarTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = Capa.UI.Reportes.DataSetFloristeriaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmReporteFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 530);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteFacturacion";
            this.Text = "frmReporteFacturacion";
            this.Load += new System.EventHandler(this.frmReporteFacturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.facturarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFloristeria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetFloristeria dataSetFloristeria;
        private System.Windows.Forms.BindingSource facturarBindingSource;
        private DataSetFloristeriaTableAdapters.FacturarTableAdapter facturarTableAdapter;
        private DataSetFloristeriaTableAdapters.TableAdapterManager tableAdapterManager;
    }
}