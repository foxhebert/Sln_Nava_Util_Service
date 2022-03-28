using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace servicioNavautil
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IwsNavautil" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IwsNavautil
    {
        [OperationContract]
        List<Pedido> ListarPedido(string empresa, DateTime fechaIni, DateTime FechaFin, string nroPedido, string estado, string vendedor, string ruc, bool anulados);

        [OperationContract]
        List<DetallePedido> listarDetallePedido(string empresa,string cdocu, string ndocu);

        [OperationContract]
        List<Vendedor> ListarVendedor(string empresa);

        [OperationContract]
        Usuario ValidarUsuarioNavaUtil(string empresa, string strNomAcceso, string strClave, ref string jellyBean);

        [OperationContract]
        List<Guía> ListarGuia(string empresa, DateTime fechaIni, DateTime FechaFin, string nroGuia, string estado, string vendedor, bool anulados);

        [OperationContract]
        List<DetalleGuia> ListarDetalleGuia(string empresa, string cdocu, string ndocu);

        [OperationContract]
        List<Almacen> ListarAlmacen(string empresa);

        [OperationContract]
        List<Familia> ListarFamilia(string empresa);

        [OperationContract]
        List<SubFamilia> ListarSubFamilia(string empresa, string codFam);

        [OperationContract]
        List<Grupo> ListarGrupo(string empresa, string codSub);

        [OperationContract]
        List<Producto> ListarProdStockCAB(string empresa, string codSubFam, string codFam, string desGrupo, string codAlmac, string estado, string codProdu, string descProdu);

        [OperationContract]
        List<Movimiento> ListarMovProdu(string empresa, string codProdu, string chk);

        [OperationContract]
        Producto DatosProducto(string empresa, string codProdu);

        [OperationContract]
        Producto DatosProductoCotiz(string empresa, string codProdu, string precioPro, string costPro, string mstoPro, string moneitemPro, string aigvPro  );


        [OperationContract]
        bool ActualizarProducto(string empresa, string codprodu, decimal uca);

        [OperationContract]
        Respuesta ImpresionTicket(string empresa, string ndocu, string comentario, bool tipoDoc);

        [OperationContract]
        Respuesta ImprimirEtiqueta(Guía datosPrint, int cantBultos);

        [OperationContract]
        List<Cliente> consultarCliente(string empresa, DateTime fechaIni, DateTime FechaFin, string ruc, string estado, string codVend, bool anulado);

        [OperationContract]
        List<Comprobante> ConsultarComprobante(string empresa, DateTime fechaIni, DateTime FechaFin, string id);

        // ActualizarProducto
        [OperationContract]
        bool GrabarCotizacion(string empresa, CabeceraCotizacion objCabeCotizacion, List<DetalleCotizacion> listDetaCotizacion);

        //Consultar Cliente Cotizacion
        [OperationContract]
        List<ClienteCotizacion> consultarClienteCotizacion(string empresa, string ruc, string codVend);
      
        //Llenar Combo Condicion de Venta
        [OperationContract]
        List<ComboGeneral> ListarComboGeneral(string empresa, string strFiltroCombo, string strSegundoFiltro);

        [OperationContract]
        List<Producto> ListarProdStockCotiz(string empresa, string codSubFam, string codFam, string desGrupo, string codAlmac, string estado, string codProdu, string descProdu, string tcam, string mone);


        [OperationContract]
        List<Correlativo> getCorrelativoCotizacion(string empresa, ref string cNroDocu);
        //añadido 02.11.2021
        [OperationContract]
        List<Emisor> ListarEmisor(string empresa);


    }
}
