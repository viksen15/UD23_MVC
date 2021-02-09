using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace mvc_Ej2
{
    class ModelVideos
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarVideos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(string Title, string Director, int Cli_ID)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarVideos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Title", Title);
            comando.Parameters.AddWithValue("@Director", Director);
            comando.Parameters.AddWithValue("@Cli_ID", Cli_ID);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Editar(string Title, string Director, int Cli_ID, int ID)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarVideos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Title", Title);
            comando.Parameters.AddWithValue("@Director", Director);
            comando.Parameters.AddWithValue("@Cli_ID", Cli_ID);
            comando.Parameters.AddWithValue("@ID", ID);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Eliminar(int ID)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarVideos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID", ID);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

    }
}
