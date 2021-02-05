using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidades
{
    public class Provedor
    {
        
        private int _id;
        private string _descripcion;
        private string _telefono;
        private string _email;
        private string _domicilio;
        private List<Material> _lista_materiales;
               
     
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }


        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }

        public List<Material> Material
        {
            get { return _lista_materiales; }
            set { _lista_materiales = value; }
        }

        
        public Provedor()
        {
        }

        public Provedor(int id, string descripcion, string telefono, string email, string domicilio, List<Material> material)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._telefono = telefono;
            this._email = email;
            this._domicilio = domicilio;
            this._lista_materiales = material;
                    
        }





    }
}
