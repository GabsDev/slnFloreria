using Capa.Logica;
using Capa.Entidades;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Capa.UI.Reportes;

namespace Capa.UI
{


    /// <summary>
    /// 1- Realice TODAS las validaciones necesarias tanto de tipo como de dato requerido utilizando ErrorProvider
    /// 2- Cree una ventana de busqueda de los art/culos a como funciona con F2 sobre el c/digo del cliente
    /// 3- Valide que un mismo articulo no se incluya dos veces en la misma factura
    /// 4- En caso que la factura sea de contado debe mostrar un mensaje al facturar que muestre el monto a pagar 
    ///    y el monto recibido y muestre el vuelto correspondiente. 
    /// 5- Documente todos los m/todos de la BLL y de la DAL
    /// 6- Coloque toolTips a todos los objetos importantes
    /// 
    /// </summary>
    partial class frmFacturar : Form
    {
        private Cliente _Cliente;
        private Producto _Producto;
        private PedidoBLL _PedidoBLL;

        public frmFacturar()
        {
            InitializeComponent();
        }

       

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteBLL _ClienteBLL = new ClienteBLL();
             
                _Cliente = _ClienteBLL.ObtenerCliente(int.Parse(this.mskIdCliente.Text));

                if (_Cliente != null)
                {
                    this.txtNombreCliente.Text = string.Format("{0}", _Cliente.Nombre);
                    PedidoEncabezado oEncabezado = new PedidoEncabezado()
                    {
                        Id_Cliente = _Cliente,
                       Direccion = _Cliente.Domicilio,
                       Autorizado = _Cliente.Nombre
                    };
                    if (rbtCompraEnvio.Checked)
                    {
                        oEncabezado.Direccion = txtAutorizadoEnvio.Text;
                        oEncabezado.Autorizado = txtDireccionEnvio.Text;
                    }


                    _PedidoBLL.AgregarEncabezado(oEncabezado);
                    //this.mskCodigoProducto.Focus();
                    this.btnBuscarCliente.Enabled = false;

                }
                else
                    MessageBox.Show("El Cliente No existe !", "Anteción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);

                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoBLL _ProductoBLL = new ProductoBLL();

                _Producto = _ProductoBLL.ObtenerProducto(int.Parse(this.mskCodigoProducto.Text));

                if (_Producto != null)
                {
                    this.txtNombreProducto.Text = _Producto.Descripcion;
                    this.txtPrecio.Text = _Producto.Precio.ToString("0.00");
                    this.mskCantidad.Focus();
                }
                else
                    MessageBox.Show("El Producto No existe !", "Anteción", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);


                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                  
                if (_Producto == null)
                {
                    MessageBox.Show("El Producto No existe !", "Anteción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PedidoDetalle oPedidoDetalle = new PedidoDetalle()
                {

                    _Producto = _Producto,
                    Cantidad = int.Parse(mskCantidad.Text),
                    Precio = _Producto.Precio,
                    No_Linea = this.dgvDatos.Rows.Count

                    //  No_Linea = this.dgvDatos.Rows.Count,

                };

                oPedidoDetalle = _PedidoBLL.AgregarDetalle(oPedidoDetalle);


                string[] item = { oPedidoDetalle._Producto.Descripcion, oPedidoDetalle.Cantidad.ToString(), oPedidoDetalle.Precio.ToString(), _PedidoBLL.ObtenerSubTotal().ToString("###.00") };

                dgvDatos.Rows.Add(item);

                this.txtImpuestosColones.Text = _PedidoBLL.ObtenerImpuesto().ToString("###.00");
                this.txtSubTotalColones.Text = _PedidoBLL.ObtenerSubTotal().ToString("###.00");
                this.txtTotalColones.Text = _PedidoBLL.ObtenerTotalColones().ToString("###.00");
               


                this.mskCodigoProducto.Clear();
                this.txtNombreProducto.Clear();
                this.mskCantidad.Clear();
                this.mskCodigoProducto.Focus();
                this.txtPrecio.Clear();
                _Producto = null;

            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void toolStripBtnFacturar_Click(object sender, EventArgs e)
        {
            int numeroFactura = 0;
            string imagen = @"c:\temp\imagen.png";

            try
            {
                 
                if (!_PedidoBLL.IsEncabezadoAsignado())
                {
                    MessageBox.Show("Error no se ha asignado el encabezado de la factura", "Atenci/n", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
                numeroFactura = _PedidoBLL.SalvarPedido();


                if (!Directory.Exists(@"c:\temp"))
                    Directory.CreateDirectory(@"c:\temp");


                // Si existe borrelo
                if (File.Exists(imagen))
                    File.Delete(imagen);

                // Crear imagen quickresponse
                Image quickResponseImage = Util.QuickResponse.QuickResponseGenerador(numeroFactura.ToString(), 53);

                // Salvarla en c:\temp
                quickResponseImage.Save(imagen, ImageFormat.Png);

                // Mostrar 
                frmReporteFacturacion ofrmReporteFacturacion = new frmReporteFacturacion(numeroFactura);
                ofrmReporteFacturacion.Show();

                ResetUI();


            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                _PedidoBLL = new PedidoBLL();

                _PedidoBLL._Pedido = new Pedido();
                ResetUI();
                rdbContado.Focus();


            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void ResetUI()
        {

            this.txtNombreCliente.Clear();
            this.txtNombreProducto.Clear();
            this.txtNoTarjeta.Clear();
            this.mskCantidad.Clear();
            this.mskCodigoProducto.Clear();
            this.mskIdCliente.Clear();
            this.dgvDatos.Rows.Clear();
            this.btnBuscarCliente.Enabled = true;
            this.txtPrecio.Clear();
            this.txtSubTotalColones.Clear();
            this.txtDireccionEnvio.Clear();
            this.txtDireccionEnvio.Clear();
            
            this.txtTotalColones.Clear();
            
            this.txtImpuestosColones.Clear();
            

        }

        private void mskIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.F2)
            //    {

            //        frmFiltroCliente ofrmFiltroCliente = new frmFiltroCliente();
            //        ofrmFiltroCliente.ShowDialog(this);

            //        if (ofrmFiltroCliente.DialogResult == System.Windows.Forms.DialogResult.OK)
            //        {

            //            _Cliente = ofrmFiltroCliente._Cliente;
            //            this.mskIdCliente.Text = _Cliente.Id_Cliente.ToString();
            //            this.txtNombreCliente.Text = _Cliente.Nombre.ToString();

            //        }

            //    }

            //    if (e.KeyCode == Keys.F3)
            //    {

            //        Process.Start("osk.exe");

            //    }

            //}
            //catch (Exception er)
            //{

            //    StringBuilder msg = new StringBuilder();
            //    msg.AppendFormat("Message        {0}\n", er.Message);
            //    MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}

        }

        private void frmFacturar_Load(object sender, EventArgs e)
        {
            try
            {
                _PedidoBLL = new PedidoBLL();

                if (!Directory.Exists(@"c:\temp\"))
                    Directory.CreateDirectory(@"c:\temp\");
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void verProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (_Producto != null)
                {
                    if (_Producto.Imagen != null)
                    {

                        notifyIcon.ShowBalloonTip(1000);

                        if (!Directory.Exists(@"C:\temp"))
                            Directory.CreateDirectory(@"C:\temp");


                        File.WriteAllBytes(@"C:\temp\Producto.pdf", _Producto.Imagen);
                        Process.Start(@"C:\temp\Producto.pdf");

                    }
                    else
                    {
                        MessageBox.Show("Atención", "No existe ningun documento asociado !");
                    }
                }



            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rbtCompraEnvio_CheckedChanged(object sender, EventArgs e)
        {
            txtDireccionEnvio.Enabled = true;
            txtAutorizadoEnvio.Enabled = true;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rdbCredito_CheckedChanged(object sender, EventArgs e)
        {
            txtNoTarjeta.Enabled = true;
           
        }
    }
}
