using System;
using System.Windows.Forms;
using Capa.Entidades;
using Capa.Logica;
using System.Data;
using log4net;

namespace Capa.UI
{
    public partial class FrmMaterial : Form
    {
        private static readonly ILog _MyLogControlEventos =
          log4net.LogManager.GetLogger("MyControlEventos");

        private static DataTable dt= new DataTable();
        public FrmMaterial()
        {
            InitializeComponent();
        }

        private void FrmMaterial_Load(object sender, EventArgs e)
        {
            try
            {
               MaterialBLL oMaterial = new MaterialBLL();
               DataSet ds= oMaterial.listado();
                dt = ds.Tables[0];
                dgvMaterial.DataSource = dt;
               // dgvClientes.Enabled = false;
                if (dt.Rows.Count > 0)
                {
                    lblDatosNoEncontrados.Visible = false;
                    dgvMaterial_CellClick(null, null);
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
                        Material material = new Material();
                        material.Descripcion = txtDescripcion.Text;
                        material.Uni_Medida = cmbUnidadMedida.Text;
                        material.Cant_Min = Convert.ToInt32(txtCantMinima.Text);
                        material.Cant_Max = Convert.ToInt32(txtCantMaxima.Text);
                        material.Precio = Convert.ToInt32(txtPrecio.Text);

                        MaterialBLL miMaterialBLL = new MaterialBLL();
                        int registrosAfectados = miMaterialBLL.Guardar(material);

                        if (registrosAfectados > 0)
                        {
                            MessageBox.Show("Datos Modificados correctamente");
                            FrmMaterial_Load(null, null);
                            // Log de errores
                            _MyLogControlEventos.InfoFormat("Se guardo un material");
                        }

                        
                    }
                    else
                    {
                        Material material = new Material();
                        material.Id = Convert.ToInt32(txtId.Text);
                        material.Descripcion = txtDescripcion.Text;
                        material.Uni_Medida = cmbUnidadMedida.Text;
                        material.Cant_Min = Convert.ToInt32(txtCantMinima.Text);
                        material.Cant_Max = Convert.ToInt32(txtCantMaxima.Text);
                        material.Precio = Convert.ToInt32(txtPrecio.Text);

                        MaterialBLL miMaterialBLL = new MaterialBLL();
                        int registrosAfectados = miMaterialBLL.Guardar(material);

                        if (registrosAfectados == 1)
                        {
                            MessageBox.Show("Datos Modificados correctamente");
                            FrmMaterial_Load(null, null);
                            // Log de errores
                            _MyLogControlEventos.InfoFormat("Se guardo un material");

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
                _MyLogControlEventos.InfoFormat("Error al guardar un material");
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

            dgvMaterial.Enabled = !b;

            txtDescripcion.Enabled = b;
            cmbUnidadMedida.Enabled = b;
            txtCantMinima.Enabled = b;
            txtCantMaxima.Enabled = b;
            txtPrecio.Enabled = b;


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);
            txtId.Text = "";
            txtDescripcion.Text = "";
            cmbUnidadMedida.SelectedIndex = 0;
            txtCantMinima.Text = "";
            txtCantMaxima.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(false);
            dgvMaterial_CellClick(null, null);
        }

        private void dgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaterial.CurrentRow != null)
            {
                txtId.Text = dgvMaterial.CurrentRow.Cells[1].Value.ToString();
                txtDescripcion.Text = dgvMaterial.CurrentRow.Cells[2].Value.ToString();
                string unidad = dgvMaterial.CurrentRow.Cells[3].Value.ToString();
                switch (unidad.Trim())
                {
                    case "centimetros":
                        cmbUnidadMedida.SelectedIndex = 0;
                        break;
                    case "metros":
                        cmbUnidadMedida.SelectedIndex = 1;
                        break;
                    case "gramos":
                        cmbUnidadMedida.SelectedIndex = 2;
                        break;
                    case "kilogramos":
                        cmbUnidadMedida.SelectedIndex = 3;
                        break;
                    case "Unidad":
                        cmbUnidadMedida.SelectedIndex = 4;
                        break;
                    default:
                        break;
                }

                txtCantMinima.Text = dgvMaterial.CurrentRow.Cells[4].Value.ToString();
                txtCantMaxima.Text = dgvMaterial.CurrentRow.Cells[5].Value.ToString();
                txtPrecio.Text = dgvMaterial.CurrentRow.Cells[6].Value.ToString();
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea eliminar los materiales seleccionados?", "Eliminacion de material",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    foreach (DataGridViewRow row in dgvMaterial.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            Material material = new Material();
                            material.Id = Convert.ToInt32(row.Cells["Id"].Value);

                            MaterialBLL miMaterialBLL = new MaterialBLL();
                            int registrosAfectados = miMaterialBLL.eliminar(material);

                            if (registrosAfectados != 1)
                            {
                                MessageBox.Show("El material no pudo ser eliminado", "Eliminacion de material",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    FrmMaterial_Load(null, null);

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

                dgvMaterial.DataSource = dv;

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

              
        private void dgvMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMaterial.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)dgvMaterial.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void dgvMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtFlag.Text == "1")
            {
                FrmProducto frmProd = FrmProducto.GetInscance();

                if (dgvMaterial.CurrentRow != null)
                {
                   
                    frmProd.SetMaterial(dgvMaterial.CurrentRow.Cells[1].Value.ToString(),
                        dgvMaterial.CurrentRow.Cells[2].Value.ToString(), dgvMaterial.CurrentRow.Cells[3].Value.ToString().Trim());
                    frmProd.Show();
                    Close();
                }
            }

            //if (txtFlag.Text == "2")
            //{
            //    FrmInvetario frmProd = FrmInvetario.GetInscance();

            //    if (dgvMaterial.CurrentRow != null)
            //    {
            //        string unidad = dgvMaterial.CurrentRow.Cells[3].Value.ToString();
            //        unidad.Trim();

            //        frmProd.SetMaterial(dgvMaterial.CurrentRow.Cells[1].Value.ToString(),
            //            dgvMaterial.CurrentRow.Cells[2].Value.ToString(), unidad);
            //        frmProd.Show();
            //        Close();
            //    }
            //}


        }
    }
}
