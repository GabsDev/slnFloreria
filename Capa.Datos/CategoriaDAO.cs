﻿using Capa.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Datos
{
    public class CategoriaDAO
    {
        public DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Categoria_GetAll", dbParams);

        }


        public int Insertar(Categoria categoria)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Descripcion", SqlDbType.VarChar, 0, categoria.Descripcion)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Categoria_Insertar", dbParams));

        }

        public int Actualizar(Categoria categoria)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, categoria.Id),
                    FDBHelper.MakeParam("@Descripcion", SqlDbType.VarChar, 0, categoria.Descripcion)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Categoria_Actualizar", dbParams));

        }

        public int Eliminar(Categoria categoria)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, categoria.Id),

                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Categoria_Eliminar", dbParams));

        }

    }
}
