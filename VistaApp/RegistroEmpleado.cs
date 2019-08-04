using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaApp;

namespace VistaApp
{
    public partial class RegistroEmpleado : Form
    {

        LogicaLogin E = new LogicaLogin();

        public RegistroEmpleado()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            E.idEmpleado = Convert.ToInt32(textID.Text);
            E.Nombre = textNombre.Text;
            E.PrimeApellido = textPrimApellido.Text;
            E.SegundoApellido = textSegApellido.Text;
            E.Telefono = Convert.ToInt32(textTelefono.Text);
            E.Email = textEmail.Text;
            E.Usuario = textUsuario.Text;
            E.Contraseña = textContraseña.Text;
            
            MessageBox.Show(E.RegistroEmpleados());
            Limpiar();

        }

        private void Limpiar()
        {
            textID.Clear();
            textNombre.Clear();
            textPrimApellido.Clear();
            textSegApellido.Clear();
            textTelefono.Clear();
            textEmail.Clear();
            textUsuario.Clear();
            textContraseña.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu ventana = new Menu();
            ventana.Show();
            this.Close();
        }
    }
}
