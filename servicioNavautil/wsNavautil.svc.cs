using Dominio.Entidades;
using Dominio.MainModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace servicioNavautil
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "wsNavautil" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione wsNavautil.svc o wsNavautil.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class wsNavautil : IwsNavautil
    {
        public List<DetallePedido> listarDetallePedido(string empresa,string cdocu, string ndocu)
        {
            return new PedidosManager().listarDetallePedido(empresa,cdocu, ndocu);
        }
        
        public List<Pedido> ListarPedido(string empresa, DateTime fechaIni, DateTime FechaFin, string nroPedido, string estado, string vendedor, string ruc, bool anulados)
        {
            return new PedidosManager().ListarPedido(empresa, fechaIni, FechaFin, nroPedido, estado, vendedor,ruc, anulados);
        }

        public List<Vendedor> ListarVendedor(string empresa)
        {
            return new DatosFiltraManager().ListarVendedor(empresa);
        }

        public Usuario ValidarUsuarioNavaUtil(string empresa, string strNomAcceso, string strClave, ref string jellyBean)
        {
            return new UsuarioManager().ValidarUsuarioNavaUtil(empresa,strNomAcceso,strClave,ref jellyBean);
        }

        public List<Guía> ListarGuia(string empresa, DateTime fechaIni, DateTime FechaFin, string nroGuia, string estado, string vendedor, bool anulados)
        {
            return new GuiaManager().ListarGuia(empresa,fechaIni,FechaFin,nroGuia,estado,vendedor,anulados);
        }

        public List<DetalleGuia> ListarDetalleGuia(string empresa, string cdocu, string ndocu)
        {
            return new GuiaManager().ListarDetalleGuia(empresa,cdocu,ndocu);
        }

        public List<Almacen> ListarAlmacen(string empresa)
        {
            return new DatosFiltraManager().ListarAlmacen(empresa);
        }

        public List<Familia> ListarFamilia(string empresa)
        {
            return new DatosFiltraManager().ListarFamilia(empresa);
        }

        public List<SubFamilia> ListarSubFamilia(string empresa, string codFam)
        {
            return new DatosFiltraManager().ListarSubFamilia(empresa,codFam);
        }

        public List<Grupo> ListarGrupo(string empresa, string codSub)
        {
            return new DatosFiltraManager().ListarGrupo(empresa, codSub);
        }

        public List<Producto> ListarProdStockCAB(string empresa, string codSubFam, string codFam, string desGrupo, string codAlmac, string estado, string codProdu, string descProdu)
        {
            return new ProductoManager().ListarProdStockCAB(empresa, codSubFam, codFam, desGrupo, codAlmac, estado, codProdu, descProdu);
        }

        public List<Movimiento> ListarMovProdu(string empresa, string codProdu, string chk)
        {
            return new ProductoManager().ListarMovProdu(empresa,codProdu,chk);
        }

        public Producto DatosProducto(string empresa, string codProdu)
        {
            return new ProductoManager().DatosProducto(empresa,codProdu);
        }
        public Producto DatosProductoCotiz(string empresa, string codProdu, string precioPro, string costPro, string mstoPro, string moneitemPro, string aigvPro)
        {
            return new ProductoManager().DatosProductoCotiz(empresa, codProdu,  precioPro, costPro,mstoPro,  moneitemPro,  aigvPro);
        }

        public bool ActualizarProducto(string empresa, string codprodu, decimal uca)
        {
            return new ProductoManager().ActualizarProducto(empresa,codprodu,uca);
        }

        public Respuesta ImpresionTicket(string empresa, string ndocu, string comentario, bool tipoDoc)
        {
            return new ImpresionManager().ImpresionTicket(empresa,ndocu,comentario,tipoDoc);
        }

        public Respuesta ImprimirEtiqueta(Guía datosPrint, int cantBultos)
        {
            return new ImpresionManager().ImprimirEtiqueta(datosPrint,cantBultos);
        }

        public List<Cliente> consultarCliente(string empresa, DateTime fechaIni, DateTime FechaFin, string ruc, string estado, string codVend, bool anulado)
        {
            return new ClientesManager().consultarCliente(empresa, fechaIni, FechaFin, ruc, estado, codVend, anulado);
        }

        public List<Comprobante> ConsultarComprobante(string empresa, DateTime fechaIni, DateTime FechaFin, string id)
        {
            return new ClientesManager().ConsultarComprobante(empresa,fechaIni,FechaFin,id);
        }

        public bool GrabarCotizacion(string empresa, CabeceraCotizacion objCabeCotizacion, List<DetalleCotizacion> listDetaCotizacion)
        {
            return new CotizacionManager().GrabarCotizacion(empresa, objCabeCotizacion, listDetaCotizacion);
        }

        public List<ClienteCotizacion> consultarClienteCotizacion(string empresa, string ruc,  string codVend)
        {
            return new CotizacionManager().consultarClienteCotizacion(empresa, ruc,  codVend);
        }

        public List<ComboGeneral> ListarComboGeneral(string empresa, string strFiltroCombo,  string strSegundoFiltro)
        {
            return new DatosFiltraManager().ListarComboGeneral(empresa, strFiltroCombo, strSegundoFiltro);
        }

        public List<Producto> ListarProdStockCotiz(string empresa, string codSubFam, string codFam, string desGrupo, string codAlmac, string estado, string codProdu, string descProdu, string tcam, string mone)
        {
            return new CotizacionManager().ListarProdStockCotiz(empresa, codSubFam, codFam, desGrupo, codAlmac, estado, codProdu, descProdu, tcam, mone);
        }
        //
        public List<Correlativo> getCorrelativoCotizacion(string empresa, ref string cNroDocu)
        {
            return new CotizacionManager().getCorrelativoCotizacion(empresa, ref cNroDocu);
        }
        //AÑADIDO 02.11.2021
        public List<Emisor> ListarEmisor(string empresa)
        {
            return new CotizacionManager().ListarEmisor(empresa);
        }

    }
}
