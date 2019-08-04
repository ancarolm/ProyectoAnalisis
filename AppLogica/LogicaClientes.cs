using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionDB;
using System.Data;

namespace AppLogica
{
    public class LogicaClientes
    {
        Conectividad M = new Conectividad();

        public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }

        public DataTable Listado()
        {
            return M.Listado("VerClientes", null);
        }

        public DataTable BuscarCliente(String objDatos, String objDato)
        {
            DataTable dt = new DataTable();
            List<Data> lst = new List<Data>();
            lst.Add(new Data("@Nombre", objDatos));
            lst.Add(new Data("@PrimerApellido", objDato));
            return dt = M.Listado("BuscarCliente", lst);
        }

        public String RegistrarCliente()
        {
            List<Data> lst = new List<Data>();
            String Mensaje = "";
            try
            {
                lst.Add(new Data("@idCliente", idCliente));
                lst.Add(new Data("@Nombre", Nombre));
                lst.Add(new Data("@SegundoNombre", SegundoNombre));
                lst.Add(new Data("@PrimerApellido", PrimerApellido));
                lst.Add(new Data("@SegundoApellido", SegundoApellido));
                lst.Add(new Data("@Email", Email));
                lst.Add(new Data("@NumeroTelefono", Telefono));
                lst.Add(new Data("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarCliente", ref lst);
                Mensaje = lst[7].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }


    }
}
