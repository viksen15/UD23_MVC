using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace mvc_Ej3
{
    class ModelProyectos
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProyectos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(string ID, string Nombre, int Horas)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProyectos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID", ID);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Horas", Horas);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Editar(string ID, string Nombre, int Horas)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarProyectos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID", ID);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Horas", Horas);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Eliminar(string ID)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProyectos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID", ID);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

    }
}
