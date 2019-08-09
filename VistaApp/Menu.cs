using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaApp
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario ventana = new Inventario();
            ventana.Show();
            this.Hide();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {

            RegistroEmpleado ventana = new RegistroEmpleado();
            ventana.Show();
            this.Hide();
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            Facturas Fac = new Facturas();
            Fac.Show();
        }
    }
}
