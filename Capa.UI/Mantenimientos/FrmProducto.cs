using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa.Logica;
using Capa.Entidades;
using Capa.UI.Properties;
using log4net;

namespace Capa.UI
{
    public partial class FrmProducto : Form
    {
        private static readonly ILog _MyLogControlEventos =
          log4net.LogManager.GetLogger("MyControlEventos");

        private static DataTable dt = new DataTable();
        private static FrmProducto _instancia = null;
        private Material _Material;
        private Producto _Producto;
        private List<Material> misMateriales;
       

        public FrmProducto()
        {
            InitializeComponent();
            misMateriales = new List<Material>();
            _Producto = new Producto();
        }

        public static FrmProducto GetInscance()
        {
            if(_instancia==null)
                _instancia= new FrmProducto();
            return _instancia;
        }

        public void SetFlag(string sValor)
        {
            txtFlag.Text = sValor;
        }

        public void SetCategoria(string id, string descripcion)
        {
            txtCategoriaId.Text = id;
            txtCategoriaDescripcion.Text = descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string sResultado = ValidarDatos();

                if (sResultado == "")
                {
                    if (txtId.Text == "")
                    {
                        
                        _Producto.Categoria.Id = Convert.ToInt32( txtCategoriaId.Text);
                        _Producto.Categoria.Descripcion = txtCategoriaDescripcion.Text;
                        _Producto.Descripcion = txtDescripcion.Text;
                        _Producto.Precio = Convert.ToDouble(txtPrecioVenta.Text);
                        _Producto.Imagen = (byte[]) this.Imagen.Tag;

                        MemoryStream ms= new MemoryStream();

                        if (Imagen.Image != null)
                        {
                            Imagen.Image.Save(ms,Imagen.Image.RawFormat);
                        }
                        else
                        {
                            Imagen.Image = Resources.Transparente;
                            Imagen.Image.Save(ms, Imagen.Image.RawFormat);
                        }
                       
                        ProductoBLL miProductoBLL = new ProductoBLL();
                        miProductoBLL.SalvarProducto(_Producto);
                                              
                        MessageBox.Show("Datos insertados correctamente");
                        FrmProducto_Load(null, null);
                        // Log de errores
                        _MyLogControlEventos.InfoFormat("Se guardo un producto");

                        this.dgvListaMateriales.Rows.Clear();
                        misMateriales = null;

                    }
                    else
                    {
                        
                        _Producto.Id = Convert.ToInt32(txtId.Text);
                        _Producto.Categoria.Id = Convert.ToInt32(txtCategoriaId.Text);
                        _Producto.Categoria.Descripcion = txtCategoriaDescripcion.Text;
                        _Producto.Descripcion = txtDescripcion.Text;
                        _Producto.Precio = Convert.ToDouble(txtPrecioVenta.Text);
                        _Producto.Imagen = (byte[])this.Imagen.Tag;

                        MemoryStream ms = new MemoryStream();

                        if (Imagen.Image != null)
                        {
                            Imagen.Image.Save(ms, Imagen.Image.RawFormat);
                        }
                        else
                        {
                            Imagen.Image = Resources.Transparente;
                            Imagen.Image.Save(ms, Imagen.Image.RawFormat);
                        }

                      

                        ProductoBLL miProductoBLL = new ProductoBLL();
                        miProductoBLL.SalvarProducto(_Producto);

                        MessageBox.Show("Datos insertados correctamente");
                        FrmProducto_Load(null, null);
                        // Log de errores
                        _MyLogControlEventos.InfoFormat("Se guardo un producto");

                        this.dgvListaMateriales.Rows.Clear();
                        misMateriales = null;
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
                _MyLogControlEventos.InfoFormat("Error al guardar un producto");
            }
        }

        public string ValidarDatos()
        {
            string Resultado = "";
            if (txtDescripcion.Text == "")
            {
                Resultado = Resultado + " Nombre \n";
            }
           

            return Resultado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(false);
            dgvProducto_CellClick(null, null);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);
            txtId.Text = "";
            txtCategoriaId.Text = "";
            txtCategoriaDescripcion.Text = "";
            txtMaterialId.Text = "";
            txtMaterialDescripcion.Text = "";
            txtDescripcion.Text = "";
            txtPrecioVenta.Text = "";
            txtUMedidaMaterial.Text = "";
            txtCantidadMaterial.Text = "";
            Imagen.BackgroundImage = Resources.Transparente;
            Imagen.Image = null;
            Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea eliminar los productos seleccionados?", "Eliminacion de Productos",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    foreach (DataGridViewRow row in dgvProducto.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            Producto producto = new Producto();
                            producto.Id = Convert.ToInt32(row.Cells["Id"].Value);

                            ProductoBLL miProductoBLL = new ProductoBLL();
                            int registrosAfectados = miProductoBLL.eliminar(producto);

                            if (registrosAfectados != 1)
                            {
                                MessageBox.Show("El Producto no pudo ser eliminado", "Eliminacion de Producto",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    FrmProducto_Load(null, null);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                Imagen.BackgroundImage = null;
                Imagen.Image = new Bitmap(dialogo.FileName);
                Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            Imagen.BackgroundImage = Resources.Transparente;
            Imagen.Image = null;
            Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            FrmCategoria frmcate= new FrmCategoria();
            frmcate.SetFlag("1");
            frmcate.ShowDialog();

        }

        private void dgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            this.dgvListaMateriales.Rows.Clear();
            Producto miProducto = new Producto();
            ProductoBLL miProductoBLL = new ProductoBLL();
            if (dgvProducto.CurrentRow != null)
            {
                //									
                txtId.Text = dgvProducto.CurrentRow.Cells["Id"].Value.ToString();
                txtCategoriaId.Text = dgvProducto.CurrentRow.Cells["CategoriaId"].Value.ToString();
                txtCategoriaDescripcion.Text = dgvProducto.CurrentRow.Cells["CategoriaDescripcion"].Value.ToString();
                               
                txtDescripcion.Text = dgvProducto.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecioVenta.Text = dgvProducto.CurrentRow.Cells["PrecioVenta"].Value.ToString();

                Imagen.BackgroundImage = null;
                byte[] b = (byte[]) dgvProducto.CurrentRow.Cells["Imagen"].Value;
                MemoryStream ms= new MemoryStream(b);
                Imagen.Image = Image.FromStream(ms);
                Imagen.SizeMode = PictureBoxSizeMode.StretchImage;


                miProducto = miProductoBLL.ObtenerProducto(Convert.ToInt32(dgvProducto.CurrentRow.Cells["Id"].Value));
                foreach (var item in miProducto.Req_Productos)
                {

                    string[] item2 = { item.Material.Id.ToString(), item.Material.Descripcion, item.Material.Uni_Medida,
                    item.Material.Precio.ToString(), item.Cantidad.ToString(), item.Costo.ToString()};

                    dgvListaMateriales.Rows.Add(item2);
                }
            }
        }

        private void dgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProducto.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)dgvProducto.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        internal void SetMaterial(string id, string descripcion, string unidad)
        {
          
             try
            {
                MaterialBLL _MaterialBLL = new MaterialBLL();

                _Material = _MaterialBLL.ObtenerMaterial(int.Parse(id));
               

                if (_Material != null)
                {
                    txtMaterialId.Text = id;
                    txtMaterialDescripcion.Text = descripcion;
                    txtUMedidaMaterial.Text = unidad;
                    this.txtCantidadMaterial.Focus();
                }
                else
                    MessageBox.Show("El Material No existe !", "Anteción", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);


                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            try
            {
                ProductoBLL miProductoBLL = new ProductoBLL();

                DataSet ds = miProductoBLL.listado();
                dt = ds.Tables[0];
                
                dgvProducto.DataSource = dt;
                

                // dgvClientes.Enabled = false;
                if (dt.Rows.Count > 0)
                {
                    dgvProducto.Columns["Imagen"].Visible = false;
                    lblDatosNoEncontrados.Visible = false;
                    dgvProducto_CellClick(null, null);
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

        public void MostrarGuardarCancelar(bool b)
        {
            btnGuardar.Visible = b;
            btnCancelar.Visible = b;
            btnNuevo.Visible = !b;
            btnEditar.Visible = !b;

            dgvProducto.Enabled = !b;

            btnCambiar.Visible = b;
            btnQuitar.Visible = b;
            btnBuscarCategoria.Visible = b;
            btnBuscarMaterial.Visible = b;
            btnAgregarMaterial.Visible = b;


            txtId.Enabled = b;
            txtCategoriaId.Enabled = b;
            txtCategoriaDescripcion.Enabled = b;
            txtMaterialId.Enabled = b;
            txtMaterialDescripcion.Enabled = b;
            txtUMedidaMaterial.Enabled = b;
            txtCantidadMaterial.Enabled = b;
            txtDescripcion.Enabled = b;
            txtPrecioVenta.Enabled = b;



        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (txtFlag.Text == "1")
            //{
            //    FrmDetalleVenta frmDetVenta = FrmDetalleVenta.GetInstance();

            //    if (dgvProducto.CurrentRow != null)
            //    {
            //        Producto producto=new Producto();
            //        producto.Id = Convert.ToInt32(dgvProducto.CurrentRow.Cells["Id"].Value.ToString());
            //        producto.Nombre = dgvProducto.CurrentRow.Cells["Nombre"].Value.ToString();
            //        producto.Stock =Convert.ToDouble(  dgvProducto.CurrentRow.Cells["Stock"].Value.ToString());
            //        producto.PrecioVenta = Convert.ToDouble(dgvProducto.CurrentRow.Cells["PrecioVenta"].Value.ToString());

            //        frmDetVenta.SetProducto(producto);
            //        frmDetVenta.Show();
            //        Close();
            //    }
            //}
        }

        private void btnBuscarMaterial_Click(object sender, EventArgs e)
        {
            FrmMaterial frmMaterial = new FrmMaterial();
            frmMaterial.SetFlag("1");
            frmMaterial.ShowDialog();
            btnAgregarMaterial.Visible = true;
        }

        private void btnAgregarMaterial_Click(object sender, EventArgs e)
        {
            btnAgregarMaterial.Visible = false;
            try
            {
                _Producto.Id = Convert.ToInt32(txtId.Text);
                _Producto.Categoria.Id = Convert.ToInt32(txtCategoriaId.Text);
                _Producto.Categoria.Descripcion = txtCategoriaDescripcion.Text;
                
                MaterialBLL _MaterialBLL = new MaterialBLL();

                _Material = _MaterialBLL.ObtenerMaterial(int.Parse(this.txtMaterialId.Text));
                misMateriales.Add(_Material);


                if (_Material == null)
                {
                    MessageBox.Show("El Material No existe !", "Anteción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                DetalleMaterial oDetalleMaterial = new DetalleMaterial()
                {

                    Producto = _Producto,
                    Material = _Material,
                    UnidadMedidad = txtUMedidaMaterial.Text,
                    Cantidad = int.Parse(txtCantidadMaterial.Text),
                    Costo = 0
                    //  No_Linea = this.dgvDatos.Rows.Count,

                };
                _Producto.AgregarMaterial(oDetalleMaterial);


                oDetalleMaterial = _Producto.AgregarMaterial(oDetalleMaterial);

                txtPrecioVenta.Text = "";
                txtPrecioVenta.Text = _Producto.CalcularPrecioProducto().ToString();

                string[] item = { oDetalleMaterial.Material.Id.ToString(), oDetalleMaterial.Material.Descripcion, oDetalleMaterial.Material.Uni_Medida,
                    oDetalleMaterial.Material.Precio.ToString(), oDetalleMaterial.Cantidad.ToString(), oDetalleMaterial.Costo.ToString()};

                dgvListaMateriales.Rows.Add(item);

                this.txtMaterialId.Clear();
                this.txtMaterialDescripcion.Clear();
                this.txtUMedidaMaterial.Clear();
                this.txtCantidadMaterial.Clear();

                _Material = null;


            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void txtCategoriaDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
