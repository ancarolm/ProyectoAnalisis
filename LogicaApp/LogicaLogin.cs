using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ConexionBD;

namespace LogicaApp
{
    public class LogicaLogin
    {
         Conexion M = new Conexion();

        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int idEmpleado { get; set; }
        public string Nombre { get; set; }
        public string PrimeApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
  


        public String IniciarSesion()
        {
            List<Datos> lst = new List<Datos>();
            String Mensaje = "";
            lst.Add(new Datos("@Usuario", Usuario));
            lst.Add(new Datos("@Contraseña", Contraseña));
            lst.Add(new Datos("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
            M.EjecutarSP("IniciarSesion", ref lst);
            return Mensaje = lst[2].Valor.ToString();

        }

        public String RegistroEmpleados()
        {
            List<Datos> lst = new List<Datos>();
            String Mensaje = "";
            try
            {
                lst.Add(new Datos("@idEmpleado", idEmpleado));
                lst.Add(new Datos("@Nombre", Nombre));
                lst.Add(new Datos("@PrimerApellido", PrimeApellido));
                lst.Add(new Datos("@SegundoApellido", SegundoApellido));
                lst.Add(new Datos("@Telefono", Telefono));
                lst.Add(new Datos("@Email", Email));
                lst.Add(new Datos("@Usuario", Usuario));
                lst.Add(new Datos("@Contraseña", Contraseña));
                lst.Add(new Datos("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistroEmpleados", ref lst);
                return Mensaje = lst[8].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
