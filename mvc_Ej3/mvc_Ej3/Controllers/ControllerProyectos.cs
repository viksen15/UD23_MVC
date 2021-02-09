using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace mvc_Ej3
{
    class ControllerProyectos
    {
        private ModelProyectos model = new ModelProyectos();
        public DataTable MostrarProy()
        {
            DataTable tabla = new DataTable();
            tabla = model.Mostrar();
            return tabla;
        }
        public void InsertarProy(string ID, string Nombre, int Horas)
        {
            model.Insertar(ID, Nombre, Horas);
        }
        public void EditarProy(string ID, string Nombre, int Horas)
        {
            model.Editar(ID, Nombre, Horas);
        }
        public void EliminarProy(string ID)
        {
            model.Eliminar(ID);
        }

    }
}
