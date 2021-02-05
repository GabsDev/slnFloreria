using Capa.Datos;
using Capa.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Logica
{
    public class UsuarioBLL
    {

        public Usuario obtenerUsuario(string login, string contraseña)
        {
            try
            {
                Usuario oUsuario = new UsuarioDAO().ObtenerUsuario(login, contraseña);
                return oUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Guardar(Usuario usuario)
        {
            UsuarioDAO oUsuario = new UsuarioDAO();

            try
            {
                if (usuario.ID_Cedula == 0)
                {
                    return oUsuario.Insertar(usuario);

                }

                else
                {
                    return oUsuario.Actualizar(usuario);

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int eliminar(Usuario usuario)
        {
            UsuarioDAO oUsuario = new UsuarioDAO();

            try
            {
                return oUsuario.Eliminar(usuario);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public DataSet listado()
        {
            UsuarioDAO oUsuario = new UsuarioDAO();
            try
            {
                return oUsuario.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
