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
   public class ProductoDAL
    {
        public List<Producto> ListarProductoSTK(string empresa,string codSubFam, string codFam,string desGrupo, string codAlmac, string estado, string codProdu, string descProdu)
        {
            List<Producto> listProdu = new List<Producto>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_prd0101_Q01", codSubFam,codFam ,desGrupo, codAlmac, estado, codProdu,descProdu);
                while (lector.Read())
                {
                    Producto obj = new Producto();
                    obj.codProdu = lector.GetString(0);
                    obj.marcaProdu = lector.GetString(1);
                    obj.descProdu = lector.GetString(2);
                    obj.UM = lector.GetString(3);
                    obj.stockFisico = lector.GetDecimal(4);
                    obj.stockDispon = lector.GetDecimal(5);
                    obj.pedido = lector.GetDecimal(6);
                    obj.prePEN = lector.GetDecimal(7);
                    obj.preUSD = lector.GetDecimal(8);
                    obj.stockOtr = lector.GetDecimal(9);
                    obj.almacen = lector.GetString(10);
                    obj.estado = lector.GetInt32(11);
                    obj.idProdu = lector.GetString(12);

                    listProdu.Add(obj);
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

            return listProdu;
        }


        public List<Movimiento> ListarMovProdu(string empresa, string codProdu, string chk)
        {
            List<Movimiento> listProdu = new List<Movimiento>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_kdd0101_Q01",codProdu,chk);
                while (lector.Read())
                {
                    Movimiento obj = new Movimiento();
                    obj.fecha = lector.GetDateTime(0);
                    obj.doc = lector.GetString(1);
                    obj.nom = lector.GetString(2);
                    obj.salida = lector.GetDecimal(3);
                    obj.stock = lector.GetDecimal(4);
                    obj.preUnd = lector.GetDecimal(5);
                    obj.glosa = lector.GetString(6);
                    obj.referencia = lector.GetString(7);
                    obj.ordCompra = lector.GetString(8);
                    obj.docRegis = lector.GetString(9);
                    obj.tipoMov = lector.GetString(10);

                    listProdu.Add(obj);
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

            return listProdu;
        }

        public Producto DatosProducto(string empresa, string codProdu)
        {
            Producto obj = null;
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_prd0101_Q11", codProdu);
                if (lector.Read())
                {
                    obj = new Producto();
                    obj.codProdu = lector.GetString(0);
                    obj.descProdu = lector.GetString(1);
                    obj.marcaProdu = lector.GetString(2);
                    obj.stockFisico = lector.GetDecimal(3);
                    obj.UM = lector.GetString(4);
                    obj.uca1 = lector.GetDecimal(5);                    
                    obj.nomfam = lector.GetString(7);
                    obj.nomsub = lector.GetString(8);
                    obj.nomgrup = lector.GetString(9);
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
            return obj;
        }

        public Producto DatosProductoCotiz(string empresa, string codProdu, string precioPro, string costPro, string mstoPro, string moneitemPro, string aigvPro )
        {
            Producto obj = null;
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_prd0101_Q12", codProdu);
                if (lector.Read())
                {
                    obj = new Producto();
                    obj.idProdu = lector.GetString(0);
                    obj.codProdu = lector.GetString(1);
                    obj.descProdu = lector.GetString(2);
                    obj.marcaProdu = lector.GetString(3);
                    obj.stockFisico = lector.GetDecimal(4);
                    obj.stockDispon = lector.GetDecimal(5);
                    obj.UM = lector.GetString(6);
                    obj.uca1 = lector.GetDecimal(7);                    
                    obj.nomfam = lector.GetString(8);
                    obj.nomsub = lector.GetString(9);
                    obj.nomgrup = lector.GetString(10);

                    obj.precio     =  Convert.ToDecimal(precioPro);
                    obj.cost       =  Convert.ToDecimal(costPro);
                    obj.msto       = mstoPro;
                    obj.moneitem   = moneitemPro;
                    obj.aigv       = aigvPro;


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
            return obj;
        }

        public bool ActualizarProducto(string empresa,string codprodu,decimal uca)
        {
            bool update = false;
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                int ok = SqlHelper.ExecuteNonQuery(cnx, "TSP_TMPRODU_U01",codprodu,uca);
                update = true;
            }
            catch (Exception ex)
            {
                LogWrite.writeLog(ex);
                throw new Exception(ex.Message);
            }
            return update;
        }
               
        
    }
}
