using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Capa.UI.Reportes
{
    public partial class frmReporteFacturacion : Form
    {

        public frmReporteFacturacion()
        {
            InitializeComponent();
        }

        public frmReporteFacturacion(int pNumeroFactura)
        {
            InitializeComponent();
            try
            {


                // Se le asigna el No de factura por Par/metro
                this.facturarTableAdapter.Fill(this.dataSetFloristeria.Facturar, pNumeroFactura);

                string ruta = @"file:///" + @"C:/TEMP/imagen.png";

                // Habilitar imagenes externas
                this.reportViewer1.LocalReport.EnableExternalImages = true;

                ReportParameter param = new ReportParameter("quickresponse", ruta);

                this.reportViewer1.LocalReport.SetParameters(param);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmReporteFacturacion_Load(object sender, EventArgs e)
        {
            
        }

        private void facturarBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
