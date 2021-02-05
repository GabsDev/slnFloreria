using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidades
{
    public class Cliente
    {
        private int _id;
        private string _nombre;
        private string _telefono;
        private string _email;
        private string _domicilio;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
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

       
       
        public Cliente()
        {
        }

        public Cliente(int id, string nombre, string telefono, string email, string domicilio)
        {
            this._id = id;
            this._nombre = nombre;
            this._telefono = telefono;
            this._email = email;
            this._domicilio = domicilio;
          
        }
    }

}

