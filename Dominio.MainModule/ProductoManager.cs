using Dominio.Entidades;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.MainModule
{
   public class ProductoManager
    {
        public List<Producto> ListarProdStockCAB(string empresa, string codSubFam, string codFam, string desGrupo, string codAlmac, string estado, string codProdu, string descProdu)
        {
            return new ProductoDAL().ListarProductoSTK(empresa, codSubFam, codFam, desGrupo, codAlmac, estado, codProdu, descProdu);
        }
        public List<Movimiento> ListarMovProdu(string empresa, string codProdu, string chk)
        {
            return new ProductoDAL().ListarMovProdu(empresa,codProdu,chk);
        }
        public Producto DatosProducto(string empresa, string codProdu)
        {
            return new ProductoDAL().DatosProducto(empresa,codProdu);
        }
        public Producto DatosProductoCotiz(string empresa, string codProdu, string precioPro, string costPro, string mstoPro, string moneitemPro, string aigvPro)
        {
            return new ProductoDAL().DatosProductoCotiz(empresa, codProdu,  precioPro,  costPro, mstoPro, moneitemPro, aigvPro);
        }
        public bool ActualizarProducto(string empresa, string codprodu, decimal uca)
        {
            return new ProductoDAL().ActualizarProducto(empresa,codprodu,uca);
        }
    }
}
