using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace mvc_Ej3
{
    class ControllerAsignado_A
    {
        private ModelAsignado_A model = new ModelAsignado_A();
        public DataTable MostrarAsig()
        {
            DataTable tabla = new DataTable();
            tabla = model.Mostrar();
            return tabla;
        }
        public void InsertarAsig(string Cientifico, string Proyecto)
        {
            model.Insertar(Cientifico, Proyecto);
        }
        public void EditarAsig(string Cientifico, string Proyecto)
        {
            model.Editar(Cientifico, Proyecto);
        }
        public void EliminarAsig(string Cientifico, string Proyecto)
        {
            model.Eliminar(Cientifico, Proyecto);
        }
    }
}
