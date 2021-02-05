
using Capa.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Capa.UI;

namespace UI
{
    public partial class frmPrincipal : Form
    {
        private static readonly ILog _MyLogControlEventos =
            log4net.LogManager.GetLogger("MyControlEventos");

        #region Constructor
        public frmPrincipal()
        {
            InitializeComponent();
        }
        #endregion

        #region UI
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                frmIngreso oFrmIngreso = new frmIngreso();
                oFrmIngreso.ShowDialog();
                // Log de errores
                _MyLogControlEventos.InfoFormat("Entro a la aplicación");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar permisos\n" + ex.Message);
                Application.ExitThread();
            }
        }

        private void habilitarDeshabilitarOpciones()
        {
            try
            {
                if (Program.UsuarioActivo != null)
                {
                    foreach (var item in toolStrip1.Items)
                    {
                        if (item is ToolStripDropDownButton)
                        {
                            ((ToolStripDropDownButton)item).Enabled =
                           Program.UsuarioActivo.Perfil.buscarMenu(((ToolStripDropDownButton)item).Name);
                            foreach (var subitem in ((ToolStripDropDownButton)item).DropDownItems)
                            {
                                if (subitem is ToolStripMenuItem)
                                {
                                    ((ToolStripMenuItem)subitem).Enabled =
                                  Program.UsuarioActivo.Perfil.buscarMenu(((ToolStripMenuItem)subitem).Name);
                                }
                            }
                        }

                        if (item is ToolStripButton)
                        {
                            ((ToolStripButton)item).Enabled =
                          Program.UsuarioActivo.Perfil.buscarMenu(((ToolStripButton)item).Name);
                        }

                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }



      

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Desea salir de la aplicacion Floristeria", "Floristeria Tulipanes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                e.Cancel = false;
            else
                e.Cancel = true;

        }

        private void salirTSMSalir_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void calculadoraToolStripMenuItemCalculadora_Click(object sender, EventArgs e)
        {
            Process.Start("Calc.exe");
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAcercade ofrmAcercade = new frmAcercade();
                ofrmAcercade.MdiParent = this;
                ofrmAcercade.Show();
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("\n\rMessage        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());

                MessageBox.Show("Ocurrion un error, favor revisar \n" + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                frmFacturar ofrmFacturar = new frmFacturar();
                ofrmFacturar.MdiParent = this;
                ofrmFacturar.Show();
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("\n\rMessage        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());

                MessageBox.Show("Ocurrion un error, favor revisar \n" + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private void crearUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSeguridad ofrmSeguridad = new frmSeguridad();
            //ofrmSeguridad.MdiParent = this;
            //ofrmSeguridad.Show();
        }

        #endregion

       
 
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.UsuarioActivo = null;
            this.WindowState = FormWindowState.Minimized;
            frmIngreso ventana = new frmIngreso();
            ventana.ShowDialog();
        }

        private void frmPrincipal_Activated(object sender, EventArgs e)
        {
            habilitarDeshabilitarOpciones();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void clienteToolStripMenuItemCliente_Click(object sender, EventArgs e)
        {
            FrmCliente ofrmCliente = new FrmCliente();
            ofrmCliente.MdiParent = this;
            ofrmCliente.Show();
        }

        private void toolStripDdbtnInicio_Click(object sender, EventArgs e)
        {

        }

        private void provedorToolStripMenuItemAutores_Click(object sender, EventArgs e)
        {
            try
            {
                FrmProvedor ofrmProvedor = new FrmProvedor();
                ofrmProvedor.MdiParent = this;
                ofrmProvedor.Show();

            }

            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("\n\rMessage        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());

                MessageBox.Show("Ocurrion un error, favor revisar \n" + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void nacionalidadToolStripMenuItemNacionalidad_Click(object sender, EventArgs e)
        {
            FrmProducto ofrmProducto = FrmProducto.GetInscance();
            ofrmProducto.MdiParent = this;
            ofrmProducto.Show();
        }

        private void editorialToolStripMenuItemEditorial_Click(object sender, EventArgs e)
        {
            FrmCategoria ofrmCategoria = new FrmCategoria();
            ofrmCategoria.MdiParent = this;
            ofrmCategoria.Show();
        }

        private void materialToolStripMenuItemLibro_Click(object sender, EventArgs e)
        {
            FrmMaterial ofrmMaterial = new FrmMaterial();
            ofrmMaterial.MdiParent = this;
            ofrmMaterial.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario ofrmUsuario = new FrmUsuario();
            ofrmUsuario.MdiParent = this;
            ofrmUsuario.Show();
        }
    }
}
