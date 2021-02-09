using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mvc
{
    public partial class Cliente : Form
    {
        Controller control = new Controller();
        private string ID = null;
        private bool edito = false;

        public Cliente()
        {
            InitializeComponent();
        }

        private void MostrarClientes()
        {
            Controller objeto = new Controller();
            dataGridView1.DataSource = objeto.MostrarClient();
        }
        private void limpiarForm()
        {
            nombreTxt.Clear();
            apellidoTxt.Clear();
            dirTxt.Clear();
            dniTxt.Clear();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void save_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (edito == false)
            {
                try
                {
                    control.InsertarClient(nombreTxt.Text, apellidoTxt.Text, dirTxt.Text, int.Parse(dniTxt.Text), fecha.Value);
                    MessageBox.Show("Insertado correctamente");
                    MostrarClientes();
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
                    control.EditarClient(nombreTxt.Text, apellidoTxt.Text, dirTxt.Text, int.Parse(dniTxt.Text), fecha.Value, int.Parse(ID));
                    MessageBox.Show("Editado correctamente");
                    MostrarClientes();
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
                nombreTxt.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                apellidoTxt.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
                dirTxt.Text = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();
                dniTxt.Text = dataGridView1.CurrentRow.Cells["DNI"].Value.ToString();
                fecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
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
                control.EliminarClient(int.Parse(ID));
                MessageBox.Show("Eliminado correctamente");
                MostrarClientes();
            }
            else
                MessageBox.Show("seleccione una fila por favor");

        }
    }
}
