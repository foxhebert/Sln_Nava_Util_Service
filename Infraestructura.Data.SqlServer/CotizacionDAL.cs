using Dominio.Entidades;
using Infraestructura.Data.SqlServer.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Configuration;



namespace Infraestructura.Data.SqlServer
{
   public class CotizacionDAL
    {

        public List<Producto> ListarProductoSTKCotiz(string empresa, string codSubFam, string codFam, string desGrupo, string codAlmac, string estado, string codProdu, string descProdu, string tcam, string mone)
        {
            List<Producto> listProdu = new List<Producto>();
            try
            {
                //Double tc = Convert.ToDouble(tcam);
                Decimal tcam_ = Convert.ToDecimal(tcam);

                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_prd0101_Q02", codSubFam, codFam, desGrupo, codAlmac, estado, codProdu, descProdu, tcam_, mone); //modificado
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
                    obj.precio    = lector.GetDecimal(13);
                    obj.cost      = lector.GetDecimal(14);
                    obj.msto      = lector.GetString(15);
                    obj.moneitem  = lector.GetString(16);
                    obj.aigv      = lector.GetString(17);

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

        public bool GrabarCotizacion1111(string empresa, CabeceraCotizacion objCabeCotizacion, List<DetalleCotizacion> listDetaCotizacion)
        {
            bool insert = false;
            bool insertDeta = false;
            //bool insertDeta = false;
            try
            {

                string cnx = CadenaConx.enlaceBD(empresa);
                SqlParameter[] pnrInfoParms = new SqlParameter[1];
                pnrInfoParms[1] = new SqlParameter("@ndocu", "");
                //Set the parameter direction as output
                pnrInfoParms[7].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteDataset(cnx, CommandType.StoredProcedure, "TSP_GrabaMstCotFac_NavaUtil_IU01"
                    , pnrInfoParms
                    );
                Convert.ToInt32(pnrInfoParms[1].Value);



                //string cnx = CadenaConx.enlaceBD(empresa);
                //string ndocu1 = "";
                //string ndocu = "";
                int Cabecera = SqlHelper.ExecuteNonQuery(cnx, "TSP_GrabaMstCotFac_NavaUtil_IU01"

                    , ""//ndocu//CabeCotizacion.ndocu
                    , objCabeCotizacion.codcli
                    , objCabeCotizacion.nomcli
                    , objCabeCotizacion.ruccli
                    , objCabeCotizacion.atte  //del combo atencion
                    , objCabeCotizacion.nrefe //vacio
                    , objCabeCotizacion.requ  //vacio
                    , objCabeCotizacion.mone
                    , objCabeCotizacion.tcam
                    , objCabeCotizacion.tota
                    , objCabeCotizacion.toti
                    , objCabeCotizacion.totn
                    , objCabeCotizacion.flag //siempre como cero
                    , objCabeCotizacion.codven
                    , objCabeCotizacion.codcdv
                    , objCabeCotizacion.cond //cadena vacia
                    , objCabeCotizacion.dura //del input 
                    , objCabeCotizacion.cOperacion
                    , objCabeCotizacion.obser
                    , objCabeCotizacion.estado
                    , objCabeCotizacion.obsere
                    , objCabeCotizacion.word
                    , objCabeCotizacion.obser2
                    , objCabeCotizacion.dirent
                    , objCabeCotizacion.codscc
                    , 0 //result  --- output--1: exitoso
                    );

                //ndocu1 = ndocu;

                //int ok = SqlHelper.ExecuteNonQuery(cnx, "TSP_TMPRODU_U01", codprodu, uca);
                insert = true;



                /*********************************************************************
                 * * ********************************************************************/
                if (insert == true)
                {

                    for (int i = 0; i < listDetaCotizacion.Count; i++)
                    {
                        //string strCodLocal     = tb.Rows[i][1].ToString();

                        DateTime fecha = Convert.ToDateTime("12/12/2021");//DateTime.Now;// DateTime.Now.ToString("dd/MM/yy HH:mm:ss"); //DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");  
                        string cdocu = "";//31
                                          //string  ndocu2   = "";//001-00000033  //Codigo generado despues de guardar la Cotizacion
                        string codcli = objCabeCotizacion.codcli;
                        Double tcam = Convert.ToDouble(objCabeCotizacion.tcam);
                        string mone = objCabeCotizacion.mone;//S   
                        string moneitm = listDetaCotizacion[i].moneitem; //****OK****//
                        string aigv = listDetaCotizacion[i].aigv;      //****OK****////"S";                   //S   Falta Identificar???
                        Double item = 1;//Convert.ToDouble(DetaCotizacion[i].cantProdu ); //?? null Cantidad??
                        string codi = listDetaCotizacion[i].idProdu; //0102-030056

                        string codf = ""; //Ejemplo(TT000400-150-13)   --> No existe en el listado de producos

                        string marc = listDetaCotizacion[i].marcaProdu; //ARG ---> ok 
                        string umed = listDetaCotizacion[i].UM;         //MLL ---> ok 
                        string descr = listDetaCotizacion[i].descProdu;  //DESC---> ok 

                        Double cant = Convert.ToDouble(listDetaCotizacion[i].cantProdu);//1.0000
                        Double preu = Convert.ToDouble(listDetaCotizacion[i].precio);    //223.0000	
                        Double tota = Convert.ToDouble(listDetaCotizacion[i].tota);//223.0000;   //223.0000
                        Double dsct = Convert.ToDouble(listDetaCotizacion[i].dsctPercent);//0.0000  DESCUENTO DESDE EL NUEVO CONTROL "Descuento"
                        Double totn = Convert.ToDouble(listDetaCotizacion[i].totn);    //265.3700

                        string AnulaDetalle = "";
                        string codalm = ""; //01
                        Double cost = Convert.ToDouble(listDetaCotizacion[i].cost); // 0;  //6.9500 //****OK****//
                        string msto = listDetaCotizacion[i].dsctPercent;//""; //S //****OK****//

                        //PARAMETROS DE ENTRADA
                        string cnx2 = CadenaConx.enlaceBD(empresa);
                        int Datalle = SqlHelper.ExecuteNonQuery(cnx2, "GrabaDtlCotFac"

                            , fecha
                            , cdocu
                            , ""//ndocu
                            , codcli
                            , tcam
                            , mone
                            , moneitm
                            , aigv
                            , item
                            , codi
                            , codf
                            , marc
                            , umed
                            , descr
                            , cant
                            , preu
                            , tota
                            , dsct
                            , totn
                            , AnulaDetalle
                            , codalm
                            , cost
                            , msto

                            );

                    }
                    insertDeta = true;
                }


            }
            catch (Exception ex)
            {
                //{"Instrucción INSERT en conflicto con la restricción FOREIGN KEY 'FK_dtl01cot_ndocu'. El conflicto ha aparecido en la base de datos 'BdNava01', tabla 'dbo.mst01cot'.\r\nSe terminó la instrucción."}
                LogWrite.writeLog(ex);
                throw new Exception(ex.Message);
            }
            return insert;
        }

        public bool GrabarCotizacion(string empresa, CabeceraCotizacion objCabeCotizacion, List<DetalleCotizacion> listDetaCotizacion)
        {
            bool insert = false;
            bool insertDeta = false;
            //bool insertDeta = false;
            try
            {


                string cnx = CadenaConx.enlaceBD(empresa);
                //int inputParam = 1;
                //int result;
                //SqlParameter[] paramCollection = SqlHelperParameterCache.GetSpParameterSet(cnx, "SP");
                //paramCollection[0].Value = inputParam;
                //SqlHelper.ExecuteNonQuery(cnx, CommandType.StoredProcedure, "SP", paramCollection);
                //result =  Convert.ToInt16(paramCollection[1].Value);
                //SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_CONSUMO_Q01", cnx);
                //cmd.CommandType = CommandType.StoredProcedure;
                ////cnx.Open()
                //Dictionary<string, object> param = new Dictionary<string, object>();
                //param.Add("@intIdSesion", objSession.intIdSesion);
                ////salida
                //param.Add("@intResult", 0);
                //param.Add("@strMsjDB", "");
                //param.Add("@strMsjUsuario", "");



                SqlParameter[] pnrInfoParms = new SqlParameter[1];
                pnrInfoParms[1] = new SqlParameter("@ndocu", "");
                //Set the parameter direction as output
                pnrInfoParms[7].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteDataset(cnx, CommandType.StoredProcedure, "TSP_GrabaMstCotFac_NavaUtil_IU01"



                    , pnrInfoParms






                    );

                Convert.ToInt32(pnrInfoParms[1].Value);




                //string cnx = CadenaConx.enlaceBD(empresa);
                //string ndocu1 = "";
                string ndocu = "";
                int Cabecera = SqlHelper.ExecuteNonQuery(cnx,"TSP_GrabaMstCotFac_NavaUtil_IU01"

                    , ndocu//CabeCotizacion.ndocu
                    ,objCabeCotizacion.codcli
                    ,objCabeCotizacion.nomcli
                    ,objCabeCotizacion.ruccli
                    ,objCabeCotizacion.atte  //del combo atencion
                    ,objCabeCotizacion.nrefe //vacio
                    ,objCabeCotizacion.requ  //vacio
                    ,objCabeCotizacion.mone  
                    ,objCabeCotizacion.tcam
                    ,objCabeCotizacion.tota
                    ,objCabeCotizacion.toti
                    ,objCabeCotizacion.totn
                    ,objCabeCotizacion.flag //siempre como cero
                    ,objCabeCotizacion.codven
                    ,objCabeCotizacion.codcdv
                    ,objCabeCotizacion.cond //cadena vacia
                    ,objCabeCotizacion.dura //del input 
                    ,objCabeCotizacion.cOperacion
                    ,objCabeCotizacion.obser
                    ,objCabeCotizacion.estado
                    ,objCabeCotizacion.obsere
                    ,objCabeCotizacion.word
                    ,objCabeCotizacion.obser2
                    ,objCabeCotizacion.dirent
                    ,objCabeCotizacion.codscc
                    ,0 //result  --- output--1: exitoso
                    );

                    //ndocu1 = ndocu;

                //int ok = SqlHelper.ExecuteNonQuery(cnx, "TSP_TMPRODU_U01", codprodu, uca);
                insert = true;



                /*********************************************************************
                 * * ********************************************************************/
                if (insert == true)
             {

                 for (int i = 0; i < listDetaCotizacion.Count; i++)
                 {
                     //string strCodLocal     = tb.Rows[i][1].ToString();

                     DateTime fecha  = Convert.ToDateTime("12/12/2021");//DateTime.Now;// DateTime.Now.ToString("dd/MM/yy HH:mm:ss"); //DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");  
                     string  cdocu   = "";//31
                     //string  ndocu2   = "";//001-00000033  //Codigo generado despues de guardar la Cotizacion
                     string  codcli  = objCabeCotizacion.codcli;
                     Double  tcam    = Convert.ToDouble(objCabeCotizacion.tcam);
                     string  mone    = objCabeCotizacion.mone;//S   
                     string  moneitm = listDetaCotizacion[i].moneitem; //****OK****//
                     string  aigv    = listDetaCotizacion[i].aigv;      //****OK****////"S";                   //S   Falta Identificar???
                     Double  item    = 1;//Convert.ToDouble(DetaCotizacion[i].cantProdu ); //?? null Cantidad??
                     string  codi    = listDetaCotizacion[i].idProdu; //0102-030056

                     string  codf    = ""; //Ejemplo(TT000400-150-13)   --> No existe en el listado de producos

                     string  marc    = listDetaCotizacion[i].marcaProdu; //ARG ---> ok 
                     string  umed    = listDetaCotizacion[i].UM;         //MLL ---> ok 
                     string  descr   = listDetaCotizacion[i].descProdu;  //DESC---> ok 

                     Double  cant    = Convert.ToDouble(listDetaCotizacion[i].cantProdu);//1.0000
                     Double  preu    = Convert.ToDouble(listDetaCotizacion[i].precio);    //223.0000	
                     Double  tota    = Convert.ToDouble(listDetaCotizacion[i].tota);//223.0000;   //223.0000
                     Double  dsct    = Convert.ToDouble(listDetaCotizacion[i].dsctPercent);//0.0000  DESCUENTO DESDE EL NUEVO CONTROL "Descuento"
                     Double  totn    = Convert.ToDouble(listDetaCotizacion[i].totn);    //265.3700

                     string AnulaDetalle = "";
                     string codalm   = ""; //01
                     Double cost     = Convert.ToDouble(listDetaCotizacion[i].cost); // 0;  //6.9500 //****OK****//
                     string msto     = listDetaCotizacion[i].dsctPercent;//""; //S //****OK****//

                     //PARAMETROS DE ENTRADA
                     string cnx2 = CadenaConx.enlaceBD(empresa);
                     int Datalle = SqlHelper.ExecuteNonQuery(cnx2, "GrabaDtlCotFac"

                         , fecha
                         , cdocu
                         , ndocu
                         , codcli
                         , tcam
                         , mone
                         , moneitm
                         , aigv
                         , item
                         , codi
                         , codf
                         , marc
                         , umed
                         , descr
                         , cant
                         , preu
                         , tota
                         , dsct
                         , totn
                         , AnulaDetalle
                         , codalm
                         , cost
                         , msto

                         );

                 }
                 insertDeta = true;
             }        

             
            }
            catch (Exception ex)
            {
                //{"Instrucción INSERT en conflicto con la restricción FOREIGN KEY 'FK_dtl01cot_ndocu'. El conflicto ha aparecido en la base de datos 'BdNava01', tabla 'dbo.mst01cot'.\r\nSe terminó la instrucción."}
                LogWrite.writeLog(ex);
                throw new Exception(ex.Message);
            }
            return insert;
        }

        public List<ClienteCotizacion> ConsultarClienteCotizacion(string empresa, string ruc, string codVend)
        {
            List<ClienteCotizacion> listClientes = new List<ClienteCotizacion>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_MST01CLI_Q01", /*TSP_MST01FAC_Q11 */ruc,  codVend);
                while (lector.Read())
                {
                    ClienteCotizacion obj = new ClienteCotizacion();

                    obj.codcli = lector.GetString(0);
                    obj.nomcli = lector.GetString(1);
                    obj.dircli = lector.GetString(2);
                    obj.ruccli = lector.GetString(3);
                    obj.nrodni = lector.GetString(4);
                    obj.telcli = lector.GetString(5);
                    obj.faxcli = lector.GetString(6);
                    obj.codven = lector.GetString(7);
                    obj.codcdv = lector.GetString(8);
                    obj.dirent = lector.GetString(9);
                    obj.codcat = lector.GetString(10);
                    obj.estado = lector.GetInt32(11);
                    obj.codgrp = lector.GetString(12);
                    obj.tipocl = lector.GetString(13);
                    obj.dsctxv = lector.GetDecimal(14);
                    obj.dsctcr = lector.GetDecimal(15);
                    obj.codpai = lector.GetString(16);
                    obj.coddep = lector.GetString(17);
                    obj.codpro = lector.GetString(18);
                    obj.coddis = lector.GetString(19);
                    obj.nomven = lector.GetString(20);


                    //obj.nroComprobante = lector.GetString(0);
                    //obj.tipoComprobante = lector.GetString(1);
                    //obj.fecha = lector.GetDateTime(2);
                    //obj.cliente = lector.GetString(3);
                    //obj.condVenta = lector.GetString(4);
                    //obj.moneda = lector.GetString(5);
                    //obj.vendedor = lector.GetString(6);
                    //obj.total = lector.GetDecimal(7);
                    //obj.id = lector.GetString(8);

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

        public List<Correlativo> getCorrelativoCotizacion_o(string empresa)
        {
            List<Correlativo> list = new List<Correlativo>();
            try
            {

                String cCodpto = "01";
                String cNomDocu = "COTIZACIONES";
                String  cNroDocu = "";
                //Double tc = Convert.ToDouble(tcam);
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "RefNroDoc", cCodpto, cNomDocu, cNroDocu);
                while (lector.Read())
                {
                    Correlativo obj = new Correlativo();
                    obj.codcorrelativo = lector.GetString(0);

                    list.Add(obj);
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

            return list;
        }
        
        public List<Correlativo> getCorrelativoCotizacion(string empresa, ref string cNroDocu)
        {

            List<Correlativo> list = new List<Correlativo>();
            string cnx = CadenaConx.enlaceBD(empresa);
            using(SqlConnection cn = new SqlConnection(cnx)) //modificado 02.11.2021 Se retira Cadena antigua porque esta no es fija sino variable.
            {
                SqlCommand cmd = new SqlCommand("RefNroDoc", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@cCodpto", "01");
                param.Add("@cNomDocu", "COTIZACIONES");
                param.Add("@cNroDocu", cNroDocu);
                AsignarParametros(cmd, param);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Correlativo obj = new Correlativo();
                    obj.codcorrelativo = reader.GetString(0);
                    list.Add(obj);

                }
                reader.Close();

                //intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                cNroDocu = cmd.Parameters["@cNroDocu"].Value.ToString();
                cn.Close();

            }
            return list;

        }


        protected void AsignarParametros(SqlCommand cmd, Dictionary<string, object> parametros)
        {
            // descubrir los parametros del SqlCommand enviado
            SqlCommandBuilder.DeriveParameters(cmd);

            foreach (KeyValuePair<string, object> item in parametros)
            {
                if (cmd.Parameters[item.Key].SqlDbType == SqlDbType.Structured)
                {
                    string typeName = cmd.Parameters[item.Key].TypeName;
                    int positionDot = typeName.LastIndexOf(".");
                    positionDot = positionDot > 0 ? positionDot + 1 : 0;
                    cmd.Parameters[item.Key].TypeName = typeName.Substring(positionDot);
                }

                cmd.Parameters[item.Key].Value = item.Value;
            }

        }


        //AÑADIDO 02.11.2021 ES
        public List<Emisor> ListarEmisor(string empresa)
        {
            List<Emisor> list = new List<Emisor>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_EMISOR_Q01", empresa);

                while (lector.Read())
                {
                    Emisor obj = new Emisor();
                    obj.RUC = lector.GetString(0);
                    obj.DIRECCION = lector.GetString(1);
                    obj.TLF = lector.GetString(2);
                    obj.WSP = lector.GetString(3);
                    obj.EMAIL = lector.GetString(4);
                    obj.LOGO = lector.GetString(5);

                    list.Add(obj);
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

            return list;
        }

    }
}
