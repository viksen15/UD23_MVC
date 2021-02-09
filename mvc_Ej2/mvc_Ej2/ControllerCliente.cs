using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace mvc_Ej2
{
    class ControllerCliente
    {
        private ModelCliente model = new ModelCliente();
        public DataTable MostrarClient()
        {
            DataTable tabla = new DataTable();
            tabla = model.Mostrar();
            return tabla;
        }
        public void InsertarClient(string Nombre, string Apellido, string Direccion, int DNI, DateTime Fecha)
        {
            model.Insertar(Nombre, Apellido, Direccion, DNI, Fecha);
        }
        public void EditarClient(string Nombre, string Apellido, string Direccion, int DNI, DateTime Fecha, int ID)
        {
            model.Editar(Nombre, Apellido, Direccion, DNI, Fecha, ID);
        }
        public void EliminarClient(int ID)
        {
            model.Eliminar(Convert.ToInt32(ID));
        }

    }
}
