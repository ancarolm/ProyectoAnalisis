using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLogica;

namespace IUApp
{
    public partial class Factura : Form
    {
        private Platillo C = new Platillo();
        private LogicaVenta V = new LogicaVenta();

        public Factura()
        {
            InitializeComponent();
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            ListarElementos();
            ListarPago();
        }

        private List<Venta> lst = new List<Venta>();

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarClientes ventana = new BuscarClientes();
            ventana.Show();
        }
        private void ListarElementos()
        {
      
                cbxCategoria.DisplayMember = "Nombre";
                cbxCategoria.ValueMember = "idPlatillo";
                cbxCategoria.DataSource = C.Listado();
        }

        private void ListarPago()
        {

            comboBox.DisplayMember = "Tipo";
            comboBox.ValueMember = "idPago";
            comboBox.DataSource = V.Listado();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }


        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
