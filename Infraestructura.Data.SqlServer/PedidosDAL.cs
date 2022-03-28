using Dominio.Entidades;
using Infraestructura.Data.SqlServer.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.SqlServer
{
    public class PedidosDAL
    {

        public List<Pedido> ListarPedido(string empresa, DateTime fechaIni, DateTime FechaFin, string nroPedido, string estado, string vendedor,string ruc, bool anulados)
        {
            List<Pedido> listPedidos = new List<Pedido>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_MST01Ped_Q01", nroPedido, fechaIni.ToString("yyyyMMdd"), FechaFin.ToString("yyyyMMdd"), estado, vendedor,ruc, anulados);
                while (lector.Read())
                {
                    Pedido obj = new Pedido();
                    obj.nroPedido = lector.GetString(0);
                    obj.fechaEmicion = lector.GetDateTime(1);
                    obj.fechaEntrega = lector.GetDateTime(2);
                    obj.cliente = lector.GetString(3);
                    obj.vendedor = lector.GetString(4);
                    obj.moneda = lector.GetString(5);
                    obj.tipoCambio = lector.GetDecimal(6);
                    obj.montoTotal = lector.GetDecimal(7);
                    obj.estado = lector.GetString(8);
                    obj.situacion = lector.GetInt32(9);
                    obj.cotizacion = lector.GetString(10);
                    obj.facBolGuia = lector.GetString(11);

                    listPedidos.Add(obj);
                }

                lector.Close();
            }
            catch (SqlException ex)
            {
                LogWrite.writeLog(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                LogWrite.writeLog(ex);
                throw new Exception(ex.Message);
            }

            return listPedidos;
        }


        public List<DetallePedido> listarDetallePedido(string empresa, string cdocu, string ndocu)
        {
            List<DetallePedido> listaDet = new List<DetallePedido>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_dtl01ped_Q01", cdocu, ndocu);
                while (lector.Read())
                {
                    DetallePedido obj = new DetallePedido();
                    obj.codProdu = lector.GetString(0);
                    obj.marca = lector.GetString(1);
                    obj.descricpcion = lector.GetString(2);
                    obj.undMedida = lector.GetString(3);
                    obj.solicitado = lector.GetDecimal(4);
                    obj.aprobado = lector.GetDecimal(5);
                    obj.entregado = lector.GetDecimal(6);
                    obj.pendiente = lector.GetDecimal(7);
                    obj.porcentaje = lector.GetString(8);
                    obj.preUni = lector.GetDecimal(9);
                    obj.total = lector.GetDecimal(10);
                    obj.dscto = lector.GetDecimal(11);
                    obj.almacen = lector.GetString(12);

                    listaDet.Add(obj);
                }
                lector.Close();
            }
            catch (SqlException ex)
            {
                LogWrite.writeLog(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                LogWrite.writeLog(ex);
                throw new Exception(ex.Message);
            }
            return listaDet;
        }

    }
}
