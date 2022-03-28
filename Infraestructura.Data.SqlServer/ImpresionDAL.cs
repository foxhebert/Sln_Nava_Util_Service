using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Entidades;
using System.Configuration;
using System.Data.SqlClient;
using Infraestructura.Data.SqlServer.Util;
using System.Net.Sockets;
using System.Net;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using TecFlex.PrinterAPI;
using System.Collections;
using BIXOLON_SamplePg;

namespace Infraestructura.Data.SqlServer
{
    public class ImpresionDAL
    {
        #region métodos públicos
        public Respuesta ImpresionTicket(string empresa, string ndocu, string comentario, bool tipoDoc)
        {
            Respuesta response = new Respuesta();
            string message = "";
            string type = "error";
            try
            {

                List<DatosImprime> datosPrint = DatosImpresion(empresa, ndocu, tipoDoc);
                if (datosPrint.Count > 0)
                    if (BixolonPrint(datosPrint, empresa, comentario, tipoDoc))
                    {
                        message = "La etiqueta se imprimió correctamente";
                        type = "success";
                    }                        
                    else
                        message = "No se pudo realizar la impresión";

            }
            catch (Exception ex)
            {
                LogWrite.writeLog(ex);
                message = "No se pudo realizar la impresión";
            }
            response.type = type;
            response.message = message;

            return response;
        }

        public Respuesta ImprimirEtiqueta(Guía datosPrint, int cantBultos)
        {
            Respuesta response = new Respuesta();
                        
            int correctos = 0;
            try
            {
                List<_Rpt_Parametro> parámetros;

                string[] split = datosPrint.nroGuia.Split('-');
                string codBarras = Convert.ToInt32(split[1]).ToString();


                string clienteLinea1 = datosPrint.rzCliente;
                string clienteLinea2 = "";

                if (clienteLinea1.Length > 30)
                {
                    clienteLinea2 = clienteLinea1.Substring(30);
                    clienteLinea1 = clienteLinea1.Substring(0, 30);

                    if (clienteLinea2.Length > 30)
                        clienteLinea2 = clienteLinea2.Substring(0,30);
                }

                string direccion1 = datosPrint.dirent;
                string direccion2 = "";
                string direccion3 = "";


                if (direccion1.Length > 31)
                {
                    direccion2 = direccion1.Substring(31);
                    direccion1 = direccion1.Substring(0, 31);

                    if (direccion2.Length > 31)
                    {
                        direccion3 = direccion2.Substring(31);
                        direccion2 = direccion2.Substring(0, 31);
                    }
                }

                for (int i = 1; i <= cantBultos; i++)
                {
                    parámetros = new List<_Rpt_Parametro>();
                    parámetros.Add(new _Rpt_Parametro("@rasonSocial", datosPrint.transp));
                    parámetros.Add(new _Rpt_Parametro("@codBarras", codBarras));
                    parámetros.Add(new _Rpt_Parametro("@contador", i + ""));
                    parámetros.Add(new _Rpt_Parametro("@cantBultos", cantBultos + ""));
                    parámetros.Add(new _Rpt_Parametro("@rucCliente", datosPrint.ruccli));
                    parámetros.Add(new _Rpt_Parametro("@clienteLn1", clienteLinea1));
                    parámetros.Add(new _Rpt_Parametro("@clienteLn2", clienteLinea2));
                    parámetros.Add(new _Rpt_Parametro("@direccionLn1", direccion1));
                    parámetros.Add(new _Rpt_Parametro("@direccionLn2", direccion2));
                    parámetros.Add(new _Rpt_Parametro("@referencia", direccion3));
                    parámetros.Add(new _Rpt_Parametro("@fecha", DateTime.Now.ToString("dd/MM/yyyy HH:MM")));

                    if (Etiquetas_Imprimir(parámetros, 1))
                        correctos += 1;

                    parámetros = null;

                }

                response.type = "success";

                if (correctos == cantBultos)
                    response.message = "Se imprimió correctamente " + cantBultos + (cantBultos > 1 ? " etiquetas" : " etiqueta");
                else if(correctos>0)
                    response.message = "se imprimieron " + correctos + " etiqueta de " + cantBultos + " bultos";
                else
                {
                    response.message = "No se realizó la impresión, intente nuevamente";
                    response.type = "error";
                }


                
            }
            catch (Exception ex)
            {
                LogWrite.writeLog(ex);
                response.message = "No se pudo realizar la impresión de la Etiqueta";
                response.type = "error";
            }
            return response;
        }

        #endregion #métodos públicos


                          
        #region métodos PRIVATE

        private bool Etiquetas_Imprimir(List<_Rpt_Parametro> pObjParametros, int pIntNumCopias)
        {
            bool todoOK = false;

            string strEtiqueta = string.Empty;
            ArrayList LstLab = new ArrayList();
            byte[] arregloEtiqueta;
            string strPlantillaEtiqueta = string.Empty;
            string[] stringSeparators = new string[] { "\r\n" };

            try
            {
                string strRutaFormato = ConfigurationManager.AppSettings["pathFormatPrint"];

                if (!File.Exists(strRutaFormato))
                    throw new Exception("No se encontró el archivo formato de impresión en la ruta: " + strRutaFormato);

                arregloEtiqueta = File.ReadAllBytes(strRutaFormato);
                strPlantillaEtiqueta = string.Empty;
                for (int intPos = 0; intPos < arregloEtiqueta.GetUpperBound(0); intPos++)
                {
                    strPlantillaEtiqueta += Convert.ToChar(arregloEtiqueta[intPos]).ToString();
                }

                //Numero de Copias de Cada Etiqueta
                for (int intContador = 1; intContador <= pIntNumCopias; intContador++)
                {
                    strEtiqueta = strPlantillaEtiqueta;
                    LstLab.Clear();
                    foreach (_Rpt_Parametro objParametro in pObjParametros)
                    {
                        if ((strEtiqueta.LastIndexOf(objParametro.ParametroName) >= 0))
                        {
                            if (objParametro.ParametroTamaño <= 0)
                            {
                                strEtiqueta = strEtiqueta.Replace(objParametro.ParametroName, objParametro.ParametroText);
                            }
                            else
                            {
                                strEtiqueta = strEtiqueta.Replace(objParametro.ParametroName, Etiquetas_FormatearTexto(objParametro.ParametroText, objParametro.ParametroTamaño));
                            }
                        }
                    }

                    string[] arrayEtiqueta = strEtiqueta.Split(stringSeparators, StringSplitOptions.None);
                    LstLab.AddRange(arrayEtiqueta);

                    string pStrNombreImpresora = ConfigurationManager.AppSettings["printerName"];

                    todoOK = ImprimeEtiqueta(pStrNombreImpresora, LstLab, true);
                }
            }
            catch (IOException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if ((LstLab != null))
                {
                    LstLab = null;
                }
            }

            return todoOK;
        }

        private bool ImprimeEtiqueta(string strNombreImpresora, ArrayList arrLab, bool blnFinImpresion = false)
        {
            bool todoOk = false;
            try
            {
                int nLin = arrLab.Count;
                string strCad = string.Empty;
                int ii = 0;

                Printer oPrinter = new Printer();
                oPrinter.PrinterName = strNombreImpresora;
                

                for (ii = 0; ii <= (nLin - 1); ii++)
                {
                    strCad = arrLab[ii].ToString();
                    oPrinter.PrintDataLn(strCad);
                }
                if (ii > 0)
                {
                    oPrinter.PrintNewPage();
                }

                if (blnFinImpresion)
                {
                    todoOk= oPrinter.PrintEndDoc();
                    oPrinter = null;
                }
                
            }
            catch (Exception ex)
            {
                todoOk = false;
                throw new Exception(ex.Message);
            }
            return todoOk;
        }


        private static string Etiquetas_FormatearTexto(string Texto, int Tamaño)
        {
            string objRetVal = string.Empty;
            //
            try
            {
                objRetVal = Texto.ToUpper().Trim();
                objRetVal = objRetVal.Replace("Á", "A");
                objRetVal = objRetVal.Replace("É", "E");
                objRetVal = objRetVal.Replace("Í", "I");
                objRetVal = objRetVal.Replace("Ó", "O");
                objRetVal = objRetVal.Replace("Ú", "U");
                objRetVal = objRetVal.Replace("Ñ", "N");
                objRetVal = objRetVal.PadRight(Tamaño, ' ');
                objRetVal = objRetVal.Substring(0, Tamaño).Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRetVal;
        }

        private void ImprimirTicket(DataTable data, string rzsocial, string comentario, string tipoDoc)
        {
            try
            {
                ReportDocument reporte = new ReportDocument();
                reporte.Load(@"F:\PROYECTOS\VS2017\NAVA UTIL\Servicio windows\sol_servicioNavautil\Infraestructura.Data.SqlServer\Crystal report\reporteNavUtil.rpt");
                reporte.SetDataSource(data);
                reporte.SetParameterValue("RazonSocial", rzsocial);
                reporte.SetParameterValue("tipoDocu", tipoDoc);
                reporte.SetParameterValue("comentario", comentario);
                reporte.PrintOptions.PrinterName = "\\DESKTOP-CJDMI9O.tecflex.com\\SATO CL4NX (203 dpi)";//"Star BSC10 (Copiar 1)"; //"BIXOLON SRP-350plusIII";
                reporte.PrintToPrinter(1, false, 0, 0);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<DatosImprime> DatosImpresion(string empresa, string ndocu, bool tipoDoc)
        {
            List<DatosImprime> datosPrint = new List<DatosImprime>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "ConsultarDetalle_Impresion", ndocu, tipoDoc);
                while (lector.Read())
                {
                    DatosImprime obj = new DatosImprime();
                    obj.ndocu = lector.GetString(0);
                    obj.fecha = lector.GetString(1);
                    obj.nomcli = lector.GetString(2);
                    obj.cant = lector.GetDecimal(3);
                    obj.codf = lector.GetString(4);
                    obj.descr = lector.GetString(5);
                    obj.uca1 = lector.GetDecimal(6);
                    obj.rollos = lector.GetString(7);

                    datosPrint.Add(obj);
                }

                lector.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                LogWrite.writeLog(ex);
                throw new Exception(ex.Message);
            }

            return datosPrint;
        }

        private DataTable DatosImpresionTable(string empresa, string ndocu)
        {
            DataTable datosPrint = new DataTable();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                datosPrint = SqlHelper.ExecuteDataTable(cnx, "ConsultarDetalle_Impresion", ndocu);

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return datosPrint;
        }


        private void sendFileToPrint()
        {
            string file = "C:\\Temp\\EtiqBultoNava.txt";

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.NoDelay = true;

            IPAddress ip = IPAddress.Parse("192.168.1.12");
            IPEndPoint ipep = new IPEndPoint(ip, 7653);
            clientSocket.Connect(ipep);

            byte[] fileBytes = File.ReadAllBytes(file);

            clientSocket.Send(fileBytes);
            clientSocket.Close();
        }

        private bool BixolonPrint(List<DatosImprime> datos, string empresa, string comentario, bool tipoDoc)
        {
            bool ok = false;
            try
            {
                string IP = ConfigurationManager.AppSettings["IPPrinterTicket"];
                int PUERTO = Convert.ToInt32(ConfigurationManager.AppSettings["PuertoPrinterTicket"]);

                if (IP.Equals("") && PUERTO == 0)
                    throw new Exception("Falta configurar la dirección IP y puerto para la impresión de Tickets");

                if (BXLAPI.PrinterOpen(BXLAPI.ILan, IP, PUERTO, 0, 0, 0) != BXLAPI.BXL_SUCCESS)
                    throw new Exception("Conexión fallida [TCP/IP] para la impresión");


                if (empresa.Equals("tecflex"))
                    empresa = "TECFLEX S.A.C";
                else
                    empresa = "CODBAR S.A.C";

                string strTipoDocu = "Pedido";

                if (tipoDoc)
                    strTipoDocu = "Guía  ";

                strTipoDocu += " No: ";

                BXLAPI.TransactionStart();

                BXLAPI.InitializePrinter();
                BXLAPI.SetCharacterSet(BXLAPI.BXL_CS_WPC1252);
                BXLAPI.SetInterChrSet(BXLAPI.BXL_ICS_USA);


                BXLAPI.PrintText(empresa + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(strTipoDocu, BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText(datos[0].ndocu + " ", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText(" Fecha: " + datos[0].fecha + "\n", BXLAPI.BXL_ALIGNMENT_RIGHT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText(datos[0].nomcli + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(comentario + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_REVERSE, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(new string('=', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(" CANTIDAD |   CÓDIGO  |\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(" D E S C R I P C I Ó N \n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(new string('=', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                for (int i = 0; i < datos.Count(); i++)
                {
                    if ((datos[i].cant % 1) == 0)
                        BXLAPI.PrintText(Convert.ToInt32(datos[i].cant) + "  ", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                    else
                        BXLAPI.PrintText(datos[i].cant + "  ", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);

                    int vacias = (15 - datos[i].codf.Length);
                    if (vacias < 0)
                        vacias = 0;
                    BXLAPI.PrintText(" " + datos[i].codf + new string(' ', vacias) + " \n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_REVERSE | BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                    BXLAPI.PrintText(datos[i].descr + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                    if (!datos[i].rollos.Equals(""))
                        BXLAPI.PrintText(datos[i].rollos + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                    BXLAPI.PrintText(new string('_', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                    BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                }

                BXLAPI.CutPaper();

                if (BXLAPI.TransactionEnd(true, 3000 /* 3 seconds */) != BXLAPI.BXL_SUCCESS)
                {
                    // failed to read a response from the printer after sending the print-data.                    
                    throw new Exception("TransactionEnd failed, No se pudo Imprimir la etiqueta");
                }
                ok = true;


            }
            catch (Exception ex)
            {
                ok = false;
                LogWrite.writeLog(ex);
            }
            finally
            {
                BXLAPI.PrinterClose();
            }
            return ok;
        }


        #endregion métodos PRIVATE

    }
}
