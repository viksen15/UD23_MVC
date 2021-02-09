using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mvc_Ej3
{
    public partial class Proyectos : Form
    {
        ControllerProyectos control = new ControllerProyectos();
        private string ID = null;
        private bool edito = false;

        public Proyectos()
        {
            InitializeComponent();
        }
        private void Proyectos_Load(object sender, EventArgs e)
        {
            MostrarProyectos();
        }

        private void MostrarProyectos()
        {
            ControllerProyectos objeto = new ControllerProyectos();
            dataGridView1.DataSource = objeto.MostrarProy();
        }
        private void limpiarForm()
        {
            idTxt.Clear();
            nombreTxt.Clear();
            horasTxt.Clear();
        }

        private void save_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (edito == false)
            {
                try
                {
                    control.InsertarProy(idTxt.Text, nombreTxt.Text, int.Parse(horasTxt.Text));
                    MessageBox.Show("Insertado correctamente");
                    MostrarProyectos();
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
                    control.EditarProy(idTxt.Text, nombreTxt.Text, int.Parse(horasTxt.Text));
                    MessageBox.Show("Editado correctamente");
                    MostrarProyectos();
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
                idTxt.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                nombreTxt.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                horasTxt.Text = dataGridView1.CurrentRow.Cells["Horas"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ID = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                control.EliminarProy(ID);
                MessageBox.Show("Eliminado correctamente");
                MostrarProyectos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }
}
