namespace UI
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDdbtnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitariosSMUtilitarios = new System.Windows.Forms.ToolStripMenuItem();
            this.calculadoraToolStripMenuItemCalculadora = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientosTSMMantenimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.ProvedoresToolStripMenuItemAutores = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItemCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.materialToolStripMenuItemLibro = new System.Windows.Forms.ToolStripMenuItem();
            this.nacionalidadToolStripMenuItemNacionalidad = new System.Windows.Forms.ToolStripMenuItem();
            this.editorialToolStripMenuItemEditorial = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesosTSMProcesos = new System.Windows.Forms.ToolStripMenuItem();
            this.facturarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagoComisiónAutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesTSMReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionTSMCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.salirTSMSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDdbtnInicio,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 486);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1017, 67);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStripBarraPrincipal";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // toolStripDdbtnInicio
            // 
            this.toolStripDdbtnInicio.BackColor = System.Drawing.Color.White;
            this.toolStripDdbtnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripDdbtnInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDdbtnInicio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem,
            this.utilitariosSMUtilitarios,
            this.mantenimientosTSMMantenimientos,
            this.procesosTSMProcesos,
            this.reportesTSMReportes,
            this.cerrarSesionTSMCerrarSesion,
            this.salirTSMSalir});
            this.toolStripDdbtnInicio.Image = global::Capa.UI.Properties.Resources.Windows_8_1;
            this.toolStripDdbtnInicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDdbtnInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDdbtnInicio.Name = "toolStripDdbtnInicio";
            this.toolStripDdbtnInicio.Size = new System.Drawing.Size(74, 64);
            this.toolStripDdbtnInicio.ToolTipText = "Inicio\r\n";
            this.toolStripDdbtnInicio.Click += new System.EventHandler(this.toolStripDdbtnInicio_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Image = global::Capa.UI.Properties.Resources.Help;
            this.acercaDeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(221, 56);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.ToolTipText = "Acerca de..";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // utilitariosSMUtilitarios
            // 
            this.utilitariosSMUtilitarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculadoraToolStripMenuItemCalculadora});
            this.utilitariosSMUtilitarios.Image = global::Capa.UI.Properties.Resources.Task_Manager_alt_1;
            this.utilitariosSMUtilitarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.utilitariosSMUtilitarios.Name = "utilitariosSMUtilitarios";
            this.utilitariosSMUtilitarios.Size = new System.Drawing.Size(221, 56);
            this.utilitariosSMUtilitarios.Text = "Utilitarios";
            this.utilitariosSMUtilitarios.ToolTipText = "Utilitarios";
            // 
            // calculadoraToolStripMenuItemCalculadora
            // 
            this.calculadoraToolStripMenuItemCalculadora.Image = global::Capa.UI.Properties.Resources.Android_Smartphone;
            this.calculadoraToolStripMenuItemCalculadora.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.calculadoraToolStripMenuItemCalculadora.Name = "calculadoraToolStripMenuItemCalculadora";
            this.calculadoraToolStripMenuItemCalculadora.Size = new System.Drawing.Size(211, 56);
            this.calculadoraToolStripMenuItemCalculadora.Text = "Calculadora";
            this.calculadoraToolStripMenuItemCalculadora.Click += new System.EventHandler(this.calculadoraToolStripMenuItemCalculadora_Click);
            // 
            // mantenimientosTSMMantenimientos
            // 
            this.mantenimientosTSMMantenimientos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProvedoresToolStripMenuItemAutores,
            this.clienteToolStripMenuItemCliente,
            this.materialToolStripMenuItemLibro,
            this.nacionalidadToolStripMenuItemNacionalidad,
            this.editorialToolStripMenuItemEditorial,
            this.usuarioToolStripMenuItem});
            this.mantenimientosTSMMantenimientos.Image = global::Capa.UI.Properties.Resources.Configure_alt_1;
            this.mantenimientosTSMMantenimientos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mantenimientosTSMMantenimientos.Name = "mantenimientosTSMMantenimientos";
            this.mantenimientosTSMMantenimientos.Size = new System.Drawing.Size(221, 56);
            this.mantenimientosTSMMantenimientos.Text = "Mantenimientos";
            this.mantenimientosTSMMantenimientos.ToolTipText = "Mantenimientos";
            // 
            // ProvedoresToolStripMenuItemAutores
            // 
            this.ProvedoresToolStripMenuItemAutores.Image = global::Capa.UI.Properties.Resources.User_With_Frame;
            this.ProvedoresToolStripMenuItemAutores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ProvedoresToolStripMenuItemAutores.Name = "ProvedoresToolStripMenuItemAutores";
            this.ProvedoresToolStripMenuItemAutores.Size = new System.Drawing.Size(225, 70);
            this.ProvedoresToolStripMenuItemAutores.Text = "Provedor";
            this.ProvedoresToolStripMenuItemAutores.ToolTipText = "Autores";
            this.ProvedoresToolStripMenuItemAutores.Click += new System.EventHandler(this.provedorToolStripMenuItemAutores_Click);
            // 
            // clienteToolStripMenuItemCliente
            // 
            this.clienteToolStripMenuItemCliente.Image = global::Capa.UI.Properties.Resources.Personal;
            this.clienteToolStripMenuItemCliente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clienteToolStripMenuItemCliente.Name = "clienteToolStripMenuItemCliente";
            this.clienteToolStripMenuItemCliente.Size = new System.Drawing.Size(225, 70);
            this.clienteToolStripMenuItemCliente.Text = "Cliente";
            this.clienteToolStripMenuItemCliente.Click += new System.EventHandler(this.clienteToolStripMenuItemCliente_Click);
            // 
            // materialToolStripMenuItemLibro
            // 
            this.materialToolStripMenuItemLibro.Image = global::Capa.UI.Properties.Resources.Screen_Resolution;
            this.materialToolStripMenuItemLibro.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.materialToolStripMenuItemLibro.Name = "materialToolStripMenuItemLibro";
            this.materialToolStripMenuItemLibro.Size = new System.Drawing.Size(225, 70);
            this.materialToolStripMenuItemLibro.Text = "Material";
            this.materialToolStripMenuItemLibro.Click += new System.EventHandler(this.materialToolStripMenuItemLibro_Click);
            // 
            // nacionalidadToolStripMenuItemNacionalidad
            // 
            this.nacionalidadToolStripMenuItemNacionalidad.Image = global::Capa.UI.Properties.Resources.Xbox_360;
            this.nacionalidadToolStripMenuItemNacionalidad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nacionalidadToolStripMenuItemNacionalidad.Name = "nacionalidadToolStripMenuItemNacionalidad";
            this.nacionalidadToolStripMenuItemNacionalidad.Size = new System.Drawing.Size(225, 70);
            this.nacionalidadToolStripMenuItemNacionalidad.Text = "Producto";
            this.nacionalidadToolStripMenuItemNacionalidad.Click += new System.EventHandler(this.nacionalidadToolStripMenuItemNacionalidad_Click);
            // 
            // editorialToolStripMenuItemEditorial
            // 
            this.editorialToolStripMenuItemEditorial.Image = global::Capa.UI.Properties.Resources.Bookmarks_alt;
            this.editorialToolStripMenuItemEditorial.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editorialToolStripMenuItemEditorial.Name = "editorialToolStripMenuItemEditorial";
            this.editorialToolStripMenuItemEditorial.Size = new System.Drawing.Size(225, 70);
            this.editorialToolStripMenuItemEditorial.Text = "Categoria";
            this.editorialToolStripMenuItemEditorial.Click += new System.EventHandler(this.editorialToolStripMenuItemEditorial_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Image = global::Capa.UI.Properties.Resources.User;
            this.usuarioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(225, 70);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // procesosTSMProcesos
            // 
            this.procesosTSMProcesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturarToolStripMenuItem,
            this.pagoComisiónAutorToolStripMenuItem,
            this.crearUsuariosToolStripMenuItem});
            this.procesosTSMProcesos.Image = global::Capa.UI.Properties.Resources.Configure;
            this.procesosTSMProcesos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.procesosTSMProcesos.Name = "procesosTSMProcesos";
            this.procesosTSMProcesos.Size = new System.Drawing.Size(221, 56);
            this.procesosTSMProcesos.Text = "Procesos";
            this.procesosTSMProcesos.ToolTipText = "Procesos";
            // 
            // facturarToolStripMenuItem
            // 
            this.facturarToolStripMenuItem.Image = global::Capa.UI.Properties.Resources.Power___Hibernate;
            this.facturarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.facturarToolStripMenuItem.Name = "facturarToolStripMenuItem";
            this.facturarToolStripMenuItem.Size = new System.Drawing.Size(254, 56);
            this.facturarToolStripMenuItem.Text = "Facturar";
            this.facturarToolStripMenuItem.Click += new System.EventHandler(this.facturarToolStripMenuItem_Click);
            // 
            // pagoComisiónAutorToolStripMenuItem
            // 
            this.pagoComisiónAutorToolStripMenuItem.Image = global::Capa.UI.Properties.Resources.Xbox_360;
            this.pagoComisiónAutorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pagoComisiónAutorToolStripMenuItem.Name = "pagoComisiónAutorToolStripMenuItem";
            this.pagoComisiónAutorToolStripMenuItem.Size = new System.Drawing.Size(254, 56);
            this.pagoComisiónAutorToolStripMenuItem.Text = "Pago Comisión Autor";
            // 
            // crearUsuariosToolStripMenuItem
            // 
            this.crearUsuariosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.crearUsuariosToolStripMenuItem.Name = "crearUsuariosToolStripMenuItem";
            this.crearUsuariosToolStripMenuItem.Size = new System.Drawing.Size(254, 56);
            this.crearUsuariosToolStripMenuItem.Text = "Seguridad";
          //  this.crearUsuariosToolStripMenuItem.Click += new System.EventHandler(this.crearUsuariosToolStripMenuItem_Click);
            // 
            // reportesTSMReportes
            // 
            this.reportesTSMReportes.Image = global::Capa.UI.Properties.Resources.Share_alt_1;
            this.reportesTSMReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reportesTSMReportes.Name = "reportesTSMReportes";
            this.reportesTSMReportes.Size = new System.Drawing.Size(221, 56);
            this.reportesTSMReportes.Text = "Reportes";
            // 
            // cerrarSesionTSMCerrarSesion
            // 
            this.cerrarSesionTSMCerrarSesion.Image = global::Capa.UI.Properties.Resources.Personal;
            this.cerrarSesionTSMCerrarSesion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cerrarSesionTSMCerrarSesion.Name = "cerrarSesionTSMCerrarSesion";
            this.cerrarSesionTSMCerrarSesion.Size = new System.Drawing.Size(221, 56);
            this.cerrarSesionTSMCerrarSesion.Text = "Cerrar Sesion";
            this.cerrarSesionTSMCerrarSesion.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // salirTSMSalir
            // 
            this.salirTSMSalir.Image = global::Capa.UI.Properties.Resources.Power___Shut_Down;
            this.salirTSMSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salirTSMSalir.Name = "salirTSMSalir";
            this.salirTSMSalir.Size = new System.Drawing.Size(221, 56);
            this.salirTSMSalir.Text = "Salir";
            this.salirTSMSalir.ToolTipText = "Salir de la Aplicacion";
            this.salirTSMSalir.Click += new System.EventHandler(this.salirTSMSalir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 67);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1017, 553);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Floristeria";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmPrincipal_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDdbtnInicio;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitariosSMUtilitarios;
        private System.Windows.Forms.ToolStripMenuItem procesosTSMProcesos;
        private System.Windows.Forms.ToolStripMenuItem mantenimientosTSMMantenimientos;
        private System.Windows.Forms.ToolStripMenuItem ProvedoresToolStripMenuItemAutores;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirTSMSalir;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItemCliente;
        private System.Windows.Forms.ToolStripMenuItem nacionalidadToolStripMenuItemNacionalidad;
        private System.Windows.Forms.ToolStripMenuItem editorialToolStripMenuItemEditorial;
        private System.Windows.Forms.ToolStripMenuItem materialToolStripMenuItemLibro;
        private System.Windows.Forms.ToolStripMenuItem facturarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagoComisiónAutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesTSMReportes;
        private System.Windows.Forms.ToolStripMenuItem calculadoraToolStripMenuItemCalculadora;
        private System.Windows.Forms.ToolStripMenuItem crearUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionTSMCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
    }
}

