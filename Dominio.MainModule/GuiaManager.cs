using Dominio.Entidades;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.MainModule
{
   public class GuiaManager
    {
        public List<Guía> ListarGuia(string empresa, DateTime fechaIni, DateTime FechaFin, string nroGuia, string estado, string vendedor, bool anulados)
        {
            return new GuiaDAL().listarGuia(empresa,fechaIni,FechaFin,nroGuia,estado,vendedor,anulados);
        }

        public List<DetalleGuia> ListarDetalleGuia(string empresa, string cdocu, string ndocu)
        {
            return new GuiaDAL().ListarDetalleGuia(empresa, cdocu, ndocu);
        }
    }
}
