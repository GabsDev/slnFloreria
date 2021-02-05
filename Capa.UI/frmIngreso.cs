using Capa.Logica;
using Capa.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.UI
{
    public partial class frmIngreso : Form
    {
        private int cantidadIntentos = 0; //3 intentos
        public frmIngreso()
        {
            InitializeComponent();
        }

        private void frmIngreso_Load(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            cantidadIntentos++;
            Usuario oUsuario = null;
            try
            {
                string login, password;
                login = txtLogin.Text;
                password = mskPassword.Text;
                oUsuario = new UsuarioBLL().obtenerUsuario(login, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Su usuario o clave no son válidos, intente de nuevo\n"
                    + ex.Message + "\nTiene " + cantidadIntentos + " de 3 " +
                    "intentos");
                validarIntentos();
                return;
            }
            Program.perfilActivo = oUsuario.Perfil.ID_Perfil;
            //de manera global a todas las ventanas el perfil y los permisos
            Program.UsuarioActivo = oUsuario;
            this.Close(); // cierra
            foreach (Form midForm in Application.OpenForms)
            {
                if (midForm.IsMdiContainer)
                {
                    (midForm as Form).WindowState = FormWindowState.Maximized;
                }
            }
}

        private void validarIntentos()
        {
            if (cantidadIntentos == 3)
            {
                MessageBox.Show("Ha fallado " + cantidadIntentos +
                    " veces, el sistema se desconectará");
                Application.ExitThread();
            }
            else
            {
                txtLogin.SelectAll();
                mskPassword.SelectAll();
                txtLogin.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
