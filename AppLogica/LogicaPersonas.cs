using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionDB;
using System.Data;

namespace AppLogica
{
    public class LogicaPersonas
    {
        Conectividad M = new Conectividad();

        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public String IniciarSesion()
        {
            List<Data> lst = new List<Data>();
            String Mensaje = "";
            lst.Add(new Data("@Usuario", Usuario));
            lst.Add(new Data("@Contraseña", Contraseña));
            lst.Add(new Data("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
            M.EjecutarSP("IniciarSesion", ref lst);
            return Mensaje = lst[2].Valor.ToString();

        }
    }
}
