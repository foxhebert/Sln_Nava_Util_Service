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
   public class GuiaDAL
    {
        public List<Guía> listarGuia(string empresa, DateTime fechaIni, DateTime FechaFin, string nroGuia, string estado, string vendedor, bool anulados)
        {
            List<Guía> lisGuia = new List<Guía>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_mst01gui_Q01", nroGuia, fechaIni.ToString("yyyyMMdd"), FechaFin.ToString("yyyyMMdd"), estado, vendedor, anulados);
                while (lector.Read())
                {
                    Guía obj = new Guía();
                    obj.nroGuia = lector.GetString(0);
                    obj.fecha = lector.GetDateTime(1);
                    obj.rzCliente = lector.GetString(2);
                    obj.motivo = lector.GetString(3);
                    obj.condVenta = lector.GetString(4);
                    obj.moneda = lector.GetString(5);
                    if(!lector.IsDBNull(6))
                        obj.transp = lector.GetString(6);
                    obj.vendedor = lector.GetString(7);
                    obj.tipCambio = lector.GetDecimal(8);
                    obj.montoTotal = lector.GetDecimal(9);
                    obj.situacion = lector.GetInt32(10);
                    obj.facBol = lector.GetString(11);
                    obj.docRef = lector.GetString(12);
                    obj.ruccli = lector.GetString(13);
                    obj.dirent = lector.GetString(14);

                    lisGuia.Add(obj);
                }
                //GC.Collect();

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

            return lisGuia;
        }

        public List<DetalleGuia> ListarDetalleGuia(string empresa, string cdocu, string ndocu)
        {
            List<DetalleGuia> listDetailGuia = new List<DetalleGuia>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_dtl01gui_Q01", cdocu, ndocu);
                while (lector.Read())
                {
                    DetalleGuia obj = new DetalleGuia();
                    obj.codProd = lector.GetString(0);
                    obj.marcaProd = lector.GetString(1);
                    obj.descProd = lector.GetString(2);
                    obj.cantProd = lector.GetDecimal(3);
                    obj.UM = lector.GetString(4);
                    obj.preUni = lector.GetDecimal(5);
                    obj.montoTotal = lector.GetDecimal(6);
                    obj.dscto = lector.GetDecimal(7);
                    obj.codAlmac = lector.GetString(8);

                    listDetailGuia.Add(obj);
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
            return listDetailGuia;
        }

    }
}
