using Dominio.Entidades;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.MainModule
{
    public class PedidosManager
    {

        public List<Pedido> ListarPedido(string empresa, DateTime fechaIni, DateTime FechaFin, string nroPedido, string estado, string vendedor, string ruc, bool anulados)
        {
            return new PedidosDAL().ListarPedido(empresa, fechaIni, FechaFin, nroPedido, estado, vendedor,ruc, anulados);
        }

        public List<DetallePedido> listarDetallePedido(string empresa, string cdocu, string ndocu)
        {
            return new PedidosDAL().listarDetallePedido(empresa, cdocu, ndocu);
        }
    }
}
