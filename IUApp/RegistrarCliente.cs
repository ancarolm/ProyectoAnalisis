using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
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

        private void button1_Click(object sender, EventArgs e)// registra el cliente a la base de datos una vez que haya completado todos los espacios
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
                                    MessageBox.Show(C.RegistrarCliente(), "Factura.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                    //MessageBoxEx.Show(C.ActualizarCliente(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Limpiar();
                                }
                            }
                            
                     
                        else
                        {
                            MessageBox.Show("Por Favor Ingrese Dirección del Cliente.", "Factura.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textEmail.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por Favor Ingrese Nombre(s) del Cliente.", "Factura.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textApellido.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese Apellidos del Cliente.", "Factura.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNombre.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese N° de D.N.I del Cliente.", "Factura.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void button2_Click(object sender, EventArgs e)// cierra la ventana de registrar un cliente nuevo
        {
            this.Close();
        }
    }
}
