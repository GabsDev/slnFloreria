using System;
using System.Data;
using System.Windows.Forms;
using Capa.Entidades;
using Capa.Logica;
using log4net;

namespace Capa.UI
{
    public partial class FrmProvedor : Form
    {
        private static readonly ILog _MyLogControlEventos =
           log4net.LogManager.GetLogger("MyControlEventos");

        private static DataTable dt= new DataTable();
        public FrmProvedor()
        {
            InitializeComponent();
        }

        private void FrmProvedor_Load(object sender, EventArgs e)
        {
            try
            {
               ProvedorBLL oProvedor = new ProvedorBLL();
               DataSet ds= oProvedor.listado();
                dt = ds.Tables[0];
                dgvProvedor.DataSource = dt;
               // dgvClientes.Enabled = false;
                if (dt.Rows.Count > 0)
                {
                    lblDatosNoEncontrados.Visible = false;
                    dgvProvedores_CellClick(null, null);
                }
                else
                {
                    lblDatosNoEncontrados.Visible = true;
                }

                MostrarGuardarCancelar(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
              string  sResultado = ValidarDatos();

                if (sResultado == "")
                {
                    if (txtId.Text == "")
                    {
                        Provedor provedor = new Provedor();
                        provedor.Descripcion = txtDescripcion.Text;
                        provedor.Telefono = txtTelefono.Text;
                        provedor.Email = txtEmail.Text;
                        provedor.Domicilio = txtDomicilio.Text;

                        ProvedorBLL miProvedorBLL = new ProvedorBLL();
                        int registrosAfectados = miProvedorBLL.Guardar(provedor);

                        if (registrosAfectados > 0)
                        {
                            MessageBox.Show("Datos Modificados correctamente");
                            FrmProvedor_Load(null, null);
                            // Log de errores
                            _MyLogControlEventos.InfoFormat("Se guardo un provedor");
                        }

                        
                    }
                    else
                    {
                        Provedor provedor = new Provedor();
                        provedor.Id = Convert.ToInt32(txtId.Text);
                        provedor.Descripcion = txtDescripcion.Text;
                        provedor.Telefono = txtTelefono.Text;
                        provedor.Email = txtEmail.Text;
                        provedor.Domicilio = txtDomicilio.Text;

                        ProvedorBLL miProvedorBLL = new ProvedorBLL();
                        int registrosAfectados = miProvedorBLL.Guardar(provedor);

                        if (registrosAfectados == 1)
                        {
                            MessageBox.Show("Datos Modificados correctamente");
                            FrmProvedor_Load(null, null);
                            // Log de errores
                            _MyLogControlEventos.InfoFormat("Se guardo un provedor");
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Faltan cargar Datos: \n" + sResultado);
                    
                }

            }
            catch (Exception ex)
            {
                
                  MessageBox.Show(ex.Message + ex.StackTrace);
                // Log de errores
                _MyLogControlEventos.InfoFormat("Error al guardar un provedor");
            }
        }


        public string ValidarDatos()
        {
            string Resultado = "";
            if (txtDescripcion.Text == "")
            {
                Resultado = Resultado + " Descripcion \n";
            }
          
            return Resultado;
        }

        public void MostrarGuardarCancelar(bool b)
        {
            btnGuardar.Visible = b;
            btnCancelar.Visible = b;
            btnNuevo.Visible = !b;
            btnEditar.Visible = !b;
            btnEliminar.Visible = !b; 

            dgvProvedor.Enabled = !b;

            txtDescripcion.Enabled = b;
            txtTelefono.Enabled = b;
            txtEmail.Enabled = b;
            txtDomicilio.Enabled = b;
           


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDomicilio.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(false);
            dgvProvedores_CellClick(null, null);
        }

        private void dgvProvedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProvedor.CurrentRow != null)
            {
                txtId.Text = dgvProvedor.CurrentRow.Cells[1].Value.ToString();
                txtDescripcion.Text = dgvProvedor.CurrentRow.Cells[2].Value.ToString();
                txtTelefono.Text = dgvProvedor.CurrentRow.Cells[3].Value.ToString();
                txtEmail.Text = dgvProvedor.CurrentRow.Cells[4].Value.ToString();
                txtDomicilio.Text = dgvProvedor.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void dgvProvedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProvedor.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell) dgvProvedor.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea eliminar los provedores seleccionados?", "Eliminacion de provedor",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    foreach (DataGridViewRow row in dgvProvedor.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            Provedor provedor = new Provedor();
                            provedor.Id = Convert.ToInt32(row.Cells["Id"].Value);

                            ProvedorBLL miProvedorBLL = new ProvedorBLL();
                            int registrosAfectados = miProvedorBLL.eliminar(provedor);

                            if (registrosAfectados != 1)
                            {
                                MessageBox.Show("El provedor no pudo ser eliminado", "Eliminacion de provedor",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    FrmProvedor_Load(null, null);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv=new DataView(dt.Copy());
                dv.RowFilter = cmbBuscar.Text + " Like '" + txtBuscar.Text + "%'";

                dgvProvedor.DataSource = dv;

                if (dv.Count == 0)
                {
                    lblDatosNoEncontrados.Visible = true;
                }
                else
                {
                    lblDatosNoEncontrados.Visible = false;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }



        internal void SetFlag(string band)
        {
            txtFlag.Text = band;
        }

        private void dgvProvedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (txtFlag.Text == "1")
            //{
            //    FrmVenta frmVenta = FrmVenta.GetInscance();

            //    if (dgvClientes.CurrentRow != null)
            //    {
            //        frmVenta.SetCliente(dgvClientes.CurrentRow.Cells[1].Value.ToString(),
            //            dgvClientes.CurrentRow.Cells[2].Value.ToString());
            //        frmVenta.Show();
            //        Close();
            //    }
            //}
        }
    }
}
