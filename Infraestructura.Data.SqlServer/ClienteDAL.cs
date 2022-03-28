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
    public class ClienteDAL
    {
        public List<Cliente> ConsultarCliente(string empresa, DateTime fechaIni, DateTime FechaFin, string ruc, string estado, string codVend, bool anulado)
        {
            List<Cliente> listClientes = new List<Cliente>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_MST01FAC_Q11", ruc, /* 20210831*/fechaIni.ToString("yyyyMMdd"), /*20210901*/ FechaFin.ToString("yyyyMMdd"), estado, codVend, anulado);
                while (lector.Read())
                {
                    Cliente obj = new Cliente();
                    obj.nroComprobante = lector.GetString(0);
                    obj.tipoComprobante = lector.GetString(1);
                    obj.fecha = lector.GetDateTime(2);
                    obj.cliente = lector.GetString(3);
                    obj.condVenta = lector.GetString(4);
                    obj.moneda = lector.GetString(5);
                    obj.vendedor = lector.GetString(6);
                    obj.total = lector.GetDecimal(7);
                    obj.id = lector.GetString(8);

                    listClientes.Add(obj);
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
 
            return listClientes;
        }

        public List<Comprobante> ConsultarComprobante(string empresa, DateTime fechaIni, DateTime FechaFin,string id)
        {
            List<Comprobante> listComprobante = new List<Comprobante>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_DTL01FAC_Q11", id, fechaIni.ToString("yyyyMMdd"), FechaFin.ToString("yyyyMMdd"));
                while (lector.Read())
                {
                    Comprobante obj = new Comprobante();
                    obj.codigo = lector.GetString(0);
                    obj.marca = lector.GetString(1);
                    obj.descripcion = lector.GetString(2);
                    obj.cantidad = lector.GetDecimal(3);
                    obj.um = lector.GetString(4);
                    obj.precio = lector.GetDecimal(5);
                    obj.total = lector.GetDecimal(6);
                    obj.stockFisico = lector.GetDecimal(7);
                    obj.stockRelativo = lector.GetDecimal(8);

                    listComprobante.Add(obj);
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

            return listComprobante;
        }


    }
}
