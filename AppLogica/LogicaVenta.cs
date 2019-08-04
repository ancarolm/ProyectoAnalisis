using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionDB;
using System.Data;

namespace AppLogica
{
    public class LogicaVenta
    {
        Conectividad M = new Conectividad();

        
        public int idPlatillo { get; set; }
        public int idPago { get; set; }
        public string Tipo { get; set; }

        public DataTable Listado()
        {
            return M.Listado("ListarPago", null);
        }

        public DataTable AgregarVenta(int objDato)
        {
            DataTable dt = new DataTable();
            List<Data> lst = new List<Data>();
            lst.Add(new Data("@idPlatillo", objDato));
            return dt = M.Listado("VenderPlatillo", lst);
        }

        


    }
}
