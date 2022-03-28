using Dominio.Entidades;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.MainModule
{
    public class CotizacionManager
    {


        public List<Producto> ListarProdStockCotiz(string empresa, string codSubFam, string codFam, string desGrupo, string codAlmac, string estado, string codProdu, string descProdu, string tcam, string mone)
        {
            return new CotizacionDAL().ListarProductoSTKCotiz(empresa, codSubFam, codFam, desGrupo, codAlmac, estado, codProdu, descProdu, tcam, mone);
        }

        public bool GrabarCotizacion(string empresa, CabeceraCotizacion CabeCotizacion, List<DetalleCotizacion> DetaCotizacion)
        {
            return new CotizacionDAL().GrabarCotizacion(empresa, CabeCotizacion,  DetaCotizacion);
        }

        public List<ClienteCotizacion> consultarClienteCotizacion(string empresa, string ruc, string codVend)
        {
            return new CotizacionDAL().ConsultarClienteCotizacion(empresa, ruc, codVend);
        }

        public List<Correlativo>  getCorrelativoCotizacion(string empresa, ref string cNroDocu)
        {
            return new CotizacionDAL().getCorrelativoCotizacion(empresa, ref cNroDocu);
        }
        //AÑADIDO 02.11.2021
        public List<Emisor> ListarEmisor(string empresa)
        {
            return new CotizacionDAL().ListarEmisor(empresa);
        }

    }
}
