using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mvc_Ej2
{
    public partial class Videos : Form
    {
        ControllerVideos control = new ControllerVideos();
        private string ID = null;
        private bool edito = false;

        public Videos()
        {
            InitializeComponent();
        }

        private void Videos_Load(object sender, EventArgs e)
        {
            MostrarVideos();
        }

        private void MostrarVideos()
        {
            ControllerVideos objeto = new ControllerVideos();
            dataGridView1.DataSource = objeto.MostrarVid();
        }
        private void limpiarForm()
        {
            titleTxt.Clear();
            direcTxt.Clear();
            cliIDtxt.Clear();
        }

        private void save_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (edito == false)
            {
                try
                {
                    control.InsertarVid(titleTxt.Text, direcTxt.Text, int.Parse(cliIDtxt.Text));
                    MessageBox.Show("Insertado correctamente");
                    MostrarVideos();
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
                    control.EditarVid(titleTxt.Text, direcTxt.Text, int.Parse(cliIDtxt.Text), int.Parse(ID));
                    MessageBox.Show("Editado correctamente");
                    MostrarVideos();
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
                titleTxt.Text = dataGridView1.CurrentRow.Cells["Title"].Value.ToString();
                direcTxt.Text = dataGridView1.CurrentRow.Cells["Director"].Value.ToString();
                cliIDtxt.Text = dataGridView1.CurrentRow.Cells["Cli_ID"].Value.ToString();
                ID = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ID = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                control.EliminarVid(int.Parse(ID));
                MessageBox.Show("Eliminado correctamente");
                MostrarVideos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

    }
}
