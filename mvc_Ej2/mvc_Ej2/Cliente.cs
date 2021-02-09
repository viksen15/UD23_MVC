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

namespace mvc_Ej2
{
    public partial class Cliente : Form
    {
        ControllerCliente control = new ControllerCliente();
        private string ID = null;
        private bool edito = false;

        public Cliente()
        {
            InitializeComponent();
        }
        private void Cliente_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void MostrarClientes()
        {
            ControllerCliente objeto = new ControllerCliente();
            dataGridView1.DataSource = objeto.MostrarClient();
        }
        private void limpiarForm()
        {
            nombreTxt.Clear();
            apellidoTxt.Clear();
            dirTxt.Clear();
            dniTxt.Clear();
        }

        private void save_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (edito == false)
            {
                try
                {
                    control.InsertarClient(nombreTxt.Text, apellidoTxt.Text, dirTxt.Text, int.Parse(dniTxt.Text), fechaTxt.Value);
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
                    control.EditarClient(nombreTxt.Text, apellidoTxt.Text, dirTxt.Text, int.Parse(dniTxt.Text), fechaTxt.Value, int.Parse(ID));
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
                fechaTxt.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
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

