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
    public partial class RegistrarCliente : Form
    {
        private LogicaClientes C = new LogicaClientes();
         
        public RegistrarCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textID.Text.Trim() != "")
            {
                if (txtNombre.Text.Trim() != "")
                {
                    if (textApellido.Text.Trim() != "")
                    {
                        if (textEmail.Text.Trim() != "")
                        {
                           

                                if (Program.Evento == 0)
                                {
                                    C.idCliente = Convert.ToInt32(textID.Text);
                                    C.Nombre = txtNombre.Text;
                                    C.SegundoNombre = textSegNombre.Text;
                                    C.PrimerApellido = textApellido.Text;
                                    C.SegundoApellido = textSegApellido.Text;
                                    C.Email = textEmail.Text;
                                    C.Telefono = Convert.ToInt32(textTelefono.Text);
                                    DevComponents.DotNetBar.MessageBoxEx.Show(C.RegistrarCliente(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Limpiar();
                                }
                                else
                                {
                                    C.idCliente = Convert.ToInt32(textID.Text);
                                    C.Nombre = txtNombre.Text;
                                    C.SegundoNombre = textSegNombre.Text;
                                    C.PrimerApellido = textApellido.Text;
                                    C.SegundoApellido = textSegApellido.Text;
                                    C.Email = textEmail.Text;
                                    C.Telefono = Convert.ToInt32(textTelefono.Text);
                                //DevComponents.DotNetBar.MessageBoxEx.Show(C.ActualizarCliente(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Limpiar();
                                }
                            }
                            
                     
                        else
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Dirección del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textEmail.Focus();
                        }
                    }
                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Nombre(s) del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textApellido.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese Apellidos del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNombre.Focus();
                }
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Ingrese N° de D.N.I del Cliente.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textID.Focus();
            }
        }

        private void Limpiar()
        {
            textID.Clear();
            txtNombre.Clear();
            textSegNombre.Clear();
            textApellido.Clear();
            textSegApellido.Clear();
            textEmail.Clear();
            textTelefono.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
