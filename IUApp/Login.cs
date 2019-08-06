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
using DevComponents.DotNetBar;

namespace IUApp
{
    public partial class Login : Form
    {
        LogicaPersonas U = new LogicaPersonas();

        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textUsuario.Text.Trim() != "")
            {
                if (textContraseña.Text.Trim() != "")
                {
                    String Mensaje = "";
                    U.Usuario = textUsuario.Text;
                    U.Contraseña = textContraseña.Text;
                    Mensaje = U.IniciarSesion();
                    if (Mensaje == "Su Contraseña es Incorrecta.")
                    {
                        MessageBoxEx.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        //textUsuario.Clear();
                        textContraseña.Clear();
                        textContraseña.Focus();
                    }
                    else
                         if (Mensaje == "El Nombre de Usuario no Existe.")
                        {
                            MessageBoxEx.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            textUsuario.Clear();
                            textContraseña.Clear();
                            textUsuario.Focus();
                    }
                    else
                    {
                        //MessageBoxEx.Show(Mensaje);
                        Factura ventana = new Factura();
                        ventana.Show();
                        textContraseña.Clear();
                        textUsuario.Clear();
                        //this.Hide();
                    }
                }
                else
                {
                    MessageBoxEx.Show("Por Favor Ingrese su Contraseña.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textContraseña.Focus();
                }
            }
            else
            {
                MessageBoxEx.Show("Por Favor Ingrese Nombre de Usuario.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textUsuario.Focus();
            }
        }
    }
    
}
