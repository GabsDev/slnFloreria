using System;
using System.Data;
using System.Windows.Forms;
using Capa.Entidades;
using Capa.Logica;
using log4net;

namespace Capa.UI
{
    public partial class FrmCliente : Form
    {
        private static readonly ILog _MyLogControlEventos =
          log4net.LogManager.GetLogger("MyControlEventos");


        private static DataTable dt= new DataTable();
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            try
            {
               ClienteBLL oCliente = new ClienteBLL();
               DataSet ds= oCliente.listado();
                dt = ds.Tables[0];
                dgvClientes.DataSource = dt;
               // dgvClientes.Enabled = false;
                if (dt.Rows.Count > 0)
                {
                    lblDatosNoEncontrados.Visible = false;
                    dgvClientes_CellClick(null, null);
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
                        Cliente cliente = new Cliente();
                        cliente.Nombre = txtNombre.Text;
                        cliente.Telefono = txtTelefono.Text;
                        cliente.Email = txtEmail.Text;
                        cliente.Domicilio = txtDomicilio.Text;

                        ClienteBLL miClienteBLL = new ClienteBLL();
                        int registrosAfectados = miClienteBLL.Guardar(cliente);

                        if (registrosAfectados > 0)
                        {
                            MessageBox.Show("Datos Modificados correctamente");
                            FrmCliente_Load(null, null);
                            // Log de errores
                            _MyLogControlEventos.InfoFormat("Se guardo un Cliente");
                        }

                        
                    }
                    else
                    {
                        Cliente cliente = new Cliente();
                        cliente.Id = Convert.ToInt32(txtId.Text);
                        cliente.Nombre = txtNombre.Text;
                        cliente.Telefono = txtTelefono.Text;
                        cliente.Email = txtEmail.Text;
                        cliente.Domicilio = txtDomicilio.Text;

                        ClienteBLL miClienteBLL = new ClienteBLL();
                        int registrosAfectados = miClienteBLL.Guardar(cliente);

                        if (registrosAfectados == 1)
                        {
                            MessageBox.Show("Datos Modificados correctamente");
                            FrmCliente_Load(null, null);
                            // Log de errores
                            _MyLogControlEventos.InfoFormat("Se guardo un Cliente");

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
                _MyLogControlEventos.InfoFormat("Error al guardar un Cliente");
            }
        }


        public string ValidarDatos()
        {
            string Resultado = "";
            if (txtNombre.Text == "")
            {
                Resultado = Resultado + " Nombre \n";
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

            dgvClientes.Enabled = !b;

            txtNombre.Enabled = b;
            txtTelefono.Enabled = b;
            txtEmail.Enabled = b;
            txtDomicilio.Enabled = b;
           


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);
            txtId.Text = "";
            txtNombre.Text = "";
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
            dgvClientes_CellClick(null, null);
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                txtId.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                txtTelefono.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                txtEmail.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                txtDomicilio.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                
            }

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvClientes.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell) dgvClientes.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea eliminar los clientes seleccionados?", "Eliminacion de Cliente",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    foreach (DataGridViewRow row in dgvClientes.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            Cliente cliente = new Cliente();
                            cliente.Id = Convert.ToInt32(row.Cells["Id"].Value);

                            ClienteBLL miClienteBLL = new ClienteBLL();
                            int registrosAfectados = miClienteBLL.eliminar(cliente);

                            if (registrosAfectados != 1)
                            {
                                MessageBox.Show("El cliente no pudo ser eliminado", "Eliminacion de Cliente",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    FrmCliente_Load(null, null);

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

                dgvClientes.DataSource = dv;

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

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
