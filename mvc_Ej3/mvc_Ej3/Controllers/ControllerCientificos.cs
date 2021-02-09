using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace mvc_Ej3
{
    class ControllerCientificos
    {
        private ModelCientificos model = new ModelCientificos();
        public DataTable MostrarCient()
        {
            DataTable tabla = new DataTable();
            tabla = model.Mostrar();
            return tabla;
        }
        public void InsertarCient(string DNI, string NomApels)
        {
            model.Insertar(DNI, NomApels);
        }
        public void EditarCient(string DNI, string NomApels)
        {
            model.Editar(DNI, NomApels);
        }
        public void EliminarCient(string DNI)
        {
            model.Eliminar(DNI);
        }

    }
}
