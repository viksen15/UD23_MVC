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
    public partial class Elegir : Form
    {
        public Elegir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente clientes = new Cliente();
            clientes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Videos videos = new Videos();
            videos.Show();
        }
    }
}
