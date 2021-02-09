using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace mvc_Ej2
{
    class ControllerVideos
    {
        private ModelVideos model = new ModelVideos();
        public DataTable MostrarVid()
        {
            DataTable tabla = new DataTable();
            tabla = model.Mostrar();
            return tabla;
        }
        public void InsertarVid(string Title, string Director, int Cli_ID)
        {
            model.Insertar(Title, Director, Cli_ID);
        }
        public void EditarVid(string Title, string Director, int Cli_ID, int ID)
        {
            model.Editar(Title, Director, Cli_ID, ID);
        }
        public void EliminarVid(int ID)
        {
            model.Eliminar(Convert.ToInt32(ID));
        }

    }
}
