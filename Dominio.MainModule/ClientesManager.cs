using Dominio.Entidades;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.MainModule
{
    public class ClientesManager
    {
        public List<Cliente> consultarCliente(string empresa, DateTime fechaIni, DateTime FechaFin, string ruc, string estado, string codVend, bool anulado)
        {
            return new ClienteDAL().ConsultarCliente(empresa,fechaIni,FechaFin,ruc,estado,codVend,anulado);
        }

        public List<Comprobante> ConsultarComprobante(string empresa, DateTime fechaIni, DateTime FechaFin, string id)
        {
            return new ClienteDAL().ConsultarComprobante(empresa,fechaIni,FechaFin,id);
        }


    }
}
