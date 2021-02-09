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
    public partial class Elegir : Form
    {
        public Elegir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cientificos cientificos = new Cientificos();
            cientificos.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Asignado_A asignado = new Asignado_A();
            asignado.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Proyectos proyectos = new Proyectos();
            proyectos.Show();
        }
    }
}
