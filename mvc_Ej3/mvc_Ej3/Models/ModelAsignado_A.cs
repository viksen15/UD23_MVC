using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace mvc_Ej3
{
    class ModelAsignado_A
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarAsignado_A";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(string Cientifico, string Proyecto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarAsignado_A";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cientifico", Cientifico);
            comando.Parameters.AddWithValue("@Proyecto", Proyecto);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Editar(string Cientifico, string Proyecto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarAsignado_A";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cientifico", Cientifico);
            comando.Parameters.AddWithValue("@Proyecto", Proyecto);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Eliminar(string Cientifico, string Proyecto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarAsignado_A";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cientifico", Cientifico);
            comando.Parameters.AddWithValue("@Proyecto", Proyecto);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

    }
}
