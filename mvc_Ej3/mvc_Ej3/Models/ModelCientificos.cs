using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace mvc_Ej3
{
    class ModelCientificos
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarCientificos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(string DNI, string NomApels)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCientificos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@DNI", DNI);
            comando.Parameters.AddWithValue("@NomApels", NomApels);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Editar(string DNI, string NomApels)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarCientificos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@DNI", DNI);
            comando.Parameters.AddWithValue("@NomApels", NomApels);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Eliminar(string DNI)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarCientificos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@DNI", DNI);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

    }
}
