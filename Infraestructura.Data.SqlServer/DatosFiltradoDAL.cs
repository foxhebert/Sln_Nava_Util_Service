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
    public class DatosFiltradoDAL
    {
        public List<Vendedor> ListarVendedor(string empresa)
        {
            List<Vendedor> listaVendedor = new List<Vendedor>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "ListarVendedor");
                while (lector.Read())
                {
                    Vendedor obj = new Vendedor();
                    obj.codven = lector.GetString(0);
                    obj.nomven = lector.GetString(1);
                    listaVendedor.Add(obj);
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

            return listaVendedor;

        }

        public List<Almacen> ListarAlmacen(string empresa)
        {
            List<Almacen> listAlmac = new List<Almacen>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "ListarAlmacenes_tbl01alm");
                while (lector.Read())
                {
                    Almacen obj = new Almacen();
                    obj.codalm = lector.GetString(0);
                    obj.nomalm = lector.GetString(1);
                    listAlmac.Add(obj);
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

            return listAlmac;

        }

        public List<Familia> ListarFamilia(string empresa)
        {
            List<Familia> listFamily = new List<Familia>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "ListarFamilia_tbl01fam");
                while (lector.Read())
                {
                    Familia obj = new Familia();
                    obj.codfam = lector.GetString(0);
                    obj.nomfam = lector.GetString(1);
                    listFamily.Add(obj);
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

            return listFamily;

        }

        public List<SubFamilia> ListarSubFamilia(string empresa,string codFam)
        {
            List<SubFamilia> listSubFamily = new List<SubFamilia>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "ListarSubFamilia_tbl01sbf",codFam);
                while (lector.Read())
                {
                    SubFamilia obj = new SubFamilia();
                    obj.codsub = lector.GetString(0);
                    obj.nomsub = lector.GetString(1);
                    listSubFamily.Add(obj);
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

            return listSubFamily;

        }

        public List<Grupo> ListarGrupo(string empresa, string codSub)
        {
            List<Grupo> listGroup = new List<Grupo>();
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "ListarGrupos_SubFamilia_tbl01grp", codSub);
                while (lector.Read())
                {
                    Grupo obj = new Grupo();
                    obj.codgru = lector.GetString(0);
                    obj.nomgru = lector.GetString(1);
                    listGroup.Add(obj);
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

            return listGroup;

        }

        public List<ComboGeneral> ListarComboGeneral(string empresa, string strFiltroCombo, string strSegundoFiltro)
        {
            List<ComboGeneral> lista = new List<ComboGeneral>();
            try
            {
                    string cnx = CadenaConx.enlaceBD(empresa);
                    SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_CBOGENERAL_Q01", strFiltroCombo, strSegundoFiltro);
                    while (lector.Read())
                    {
                        ComboGeneral obj = new ComboGeneral();
                        obj.cboCod = lector.GetString(0);
                        obj.cboDes = lector.GetString(1);
                        lista.Add(obj);
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

            return lista;

        }


    }
}
