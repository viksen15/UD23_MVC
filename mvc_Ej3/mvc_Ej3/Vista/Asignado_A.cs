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
    public partial class Asignado_A : Form
    {
        ControllerAsignado_A control = new ControllerAsignado_A();
        private string Cientifico, Proyecto = null;
        private bool edito = false;

        public Asignado_A()
        {
            InitializeComponent();
        }
        private void Asignado_A_Load(object sender, EventArgs e)
        {
            MostrarAsignado_A();
        }

        private void MostrarAsignado_A()
        {
            ControllerAsignado_A objeto = new ControllerAsignado_A();
            dataGridView1.DataSource = objeto.MostrarAsig();
        }
        private void limpiarForm()
        {
            cTxt.Clear();
            pTxt.Clear();
        }

        private void save_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (edito == false)
            {
                try
                {
                    control.InsertarAsig(cTxt.Text, pTxt.Text);
                    MessageBox.Show("Insertado correctamente");
                    MostrarAsignado_A();
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
                    control.EditarAsig(cTxt.Text, pTxt.Text);
                    MessageBox.Show("Editado correctamente");
                    MostrarAsignado_A();
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
                cTxt.Text = dataGridView1.CurrentRow.Cells["Cientifico"].Value.ToString();
                pTxt.Text = dataGridView1.CurrentRow.Cells["Proyecto"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Cientifico = dataGridView1.CurrentRow.Cells["Cientifico"].Value.ToString();
                Proyecto = dataGridView1.CurrentRow.Cells["Proyecto"].Value.ToString();
                control.EliminarAsig(Cientifico, Proyecto);
                MessageBox.Show("Eliminado correctamente");
                MostrarAsignado_A();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }


    }
}
