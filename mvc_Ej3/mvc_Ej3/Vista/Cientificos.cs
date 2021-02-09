using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace mvc_Ej3
{
    public partial class Cientificos : Form
    {
        ControllerCientificos control = new ControllerCientificos();
        private string DNI = null;
        private bool edito = false;

        public Cientificos()
        {
            InitializeComponent();
        }
        private void Cientificos_Load(object sender, EventArgs e)
        {
            MostrarCientificos();
        }

        private void MostrarCientificos()
        {
            ControllerCientificos objeto = new ControllerCientificos();
            dataGridView1.DataSource = objeto.MostrarCient();
        }
        private void limpiarForm()
        {
            dniTxt.Clear();
            nomApelsTxt.Clear();
        }

        private void save_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (edito == false)
            {
                try
                {
                    control.InsertarCient(dniTxt.Text, nomApelsTxt.Text);
                    MessageBox.Show("Insertado correctamente");
                    MostrarCientificos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR
            if (edito == true)
            {
                try
                {
                    control.EditarCient(dniTxt.Text, nomApelsTxt.Text);
                    MessageBox.Show("Editado correctamente");
                    MostrarCientificos();
                    limpiarForm();
                    edito = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudieron editar los datos por: " + ex);
                }
            }

        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                edito = true;
                nomApelsTxt.Text = dataGridView1.CurrentRow.Cells["NomApels"].Value.ToString();
                dniTxt.Text = dataGridView1.CurrentRow.Cells["DNI"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DNI = dataGridView1.CurrentRow.Cells["DNI"].Value.ToString();
                control.EliminarCient(DNI);
                MessageBox.Show("Eliminado correctamente");
                MostrarCientificos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

    }
}

