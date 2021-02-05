using Capa.Logica;
using Capa.Entidades;
using System;
using System.Data;
using System.Windows.Forms;
using log4net;

namespace Capa.UI
{
    public partial class FrmUsuario : Form
    {
        private static readonly ILog _MyLogControlEventos =
          log4net.LogManager.GetLogger("MyControlEventos");

        private static DataTable dt= new DataTable();
        private static string _PasswordActual;
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                txtRepetirContrasenia.Text = "";
                cmbPerfil.DisplayMember = "Perfil";
                cmbPerfil.ValueMember = "Id";

                
                PerfilBLL miPerfilBLL  = new PerfilBLL();

                cmbPerfil.DataSource = miPerfilBLL.obtenerPerfiles();



                UsuarioBLL miUsuarioBLL = new UsuarioBLL();
                DataSet ds= miUsuarioBLL.listado();
                dt = ds.Tables[0];
                dgvUsuarios.DataSource = dt;
                


               // dgvUsuarios.Enabled = false;
                if (dt.Rows.Count > 0)
                {
                    lblDatosNoEncontrados.Visible = false;
                    dgvUsuarios_CellClick(null, null);
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
                        if (!txtContrasenia.Text.Equals(txtRepetirContrasenia.Text, StringComparison.Ordinal))
                        {
                            MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {

                            Usuario usuario = new Usuario();
                            usuario.Perfil.ID_Perfil = Convert.ToInt32(cmbPerfil.SelectedValue);
                            usuario.Login = txtNombreUsuario.Text;
                            usuario.Contraseña = txtContrasenia.Text;

                            UsuarioBLL miUsuarioBLL = new UsuarioBLL();
                            int registrosAfectados = miUsuarioBLL.Guardar(usuario);

                            if (registrosAfectados > 0)
                            {
                                MessageBox.Show("Datos insertados correctamente");
                                FrmUsuario_Load(null, null);
                                // Log de errores
                                _MyLogControlEventos.InfoFormat("Se guardo un usuario");
                            }
                        }
                    }
                    else
                    {
                        string sContrasenia = _PasswordActual;

                         if (_PasswordActual != txtContrasenia.Text)
                        {
                            if (!txtContrasenia.Text.Equals(txtRepetirContrasenia.Text, StringComparison.Ordinal))
                            {
                                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                sContrasenia=txtContrasenia.Text;
                            }
                        }



                        Usuario usuario = new Usuario();
                        usuario.ID_Cedula = Convert.ToInt32(txtId.Text);
                        usuario.Perfil.ID_Perfil = Convert.ToInt32(cmbPerfil.SelectedValue);
                        usuario.Login = txtNombreUsuario.Text;
                        usuario.Contraseña = sContrasenia;

                        UsuarioBLL miUsuarioBLL = new UsuarioBLL();
                        int registrosAfectados = miUsuarioBLL.Guardar(usuario);


                        if (registrosAfectados == 1)
                        {
                            MessageBox.Show("Datos Modificados correctamente");
                            FrmUsuario_Load(null, null);
                            // Log de errores
                            _MyLogControlEventos.InfoFormat("Se actualizo un usuario");
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
            }
        }


        public string ValidarDatos()
        {
            string Resultado = "";
          
            if (txtNombreUsuario.Text == "")
            {
                Resultado = Resultado + "Apellidos\n";
            }
            if (txtContrasenia.Text == "")
            {
                Resultado = Resultado + "Apellidos\n";
            }

            return Resultado;
        }

        public void MostrarGuardarCancelar(bool b)
        {
            btnGuardar.Visible = b;
            btnCancelar.Visible = b;
            btnNuevo.Visible = !b;
            btnEditar.Visible = !b;
            btnEliminar.Visible=!b;

            dgvUsuarios.Enabled = !b;

            cmbPerfil.Enabled = b;
            txtContrasenia.Enabled = b;
            txtRepetirContrasenia.Enabled = b;
            txtNombreUsuario.Enabled = b;


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _PasswordActual = "";
            MostrarGuardarCancelar(true);
            txtId.Text = "";
            txtNombreUsuario.Text = "";
            cmbPerfil.SelectedValue = "2";
            txtRepetirContrasenia.Text = "";
            txtContrasenia.Text = "";

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            _PasswordActual = txtContrasenia.Text;
            MostrarGuardarCancelar(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(false);
            dgvUsuarios_CellClick(null, null);
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                txtId.Text = dgvUsuarios.CurrentRow.Cells["ID_Cedula"].Value.ToString();
                cmbPerfil.SelectedValue = dgvUsuarios.CurrentRow.Cells["Perfil"].Value.ToString();
                txtContrasenia.Text = dgvUsuarios.CurrentRow.Cells["Contraseña"].Value.ToString();
                txtNombreUsuario.Text = dgvUsuarios.CurrentRow.Cells["Login"].Value.ToString();
            }

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUsuarios.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell) dgvUsuarios.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea eliminar los Usuarios seleccionados?", "Eliminacion de Usuario",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    foreach (DataGridViewRow row in dgvUsuarios.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            Usuario usuario = new Usuario();
                            usuario.ID_Cedula = Convert.ToInt32(row.Cells["Id"].Value);

                            UsuarioBLL miUsuarioBLL = new UsuarioBLL();
                            int registrosAfectados = miUsuarioBLL.eliminar(usuario);

                            if (registrosAfectados != 1)
                            {
                                MessageBox.Show("El Usuario no pudo ser eliminado", "Eliminacion de Usuario",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    FrmUsuario_Load(null, null);

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

                dgvUsuarios.DataSource = dv;

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

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (txtFlag.Text == "1")
            //{
            //    FrmVenta frmVenta = FrmVenta.GetInscance();

            //    if (dgvUsuarios.CurrentRow != null)
            //    {
            //        //frmVenta.SetUsuario(dgvUsuarios.CurrentRow.Cells[1].Value.ToString(),
            //        //    dgvUsuarios.CurrentRow.Cells[2].Value.ToString());
            //        //frmVenta.Show();
            //        //Close();
            //    }
            //}
        }
    }
}
