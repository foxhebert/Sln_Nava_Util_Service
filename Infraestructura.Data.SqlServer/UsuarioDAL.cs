using Dominio.Entidades;
using Infraestructura.Data.SqlServer.Util;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.SqlServer
{
    public class UsuarioDAL
    {
        public Usuario ValidarUsuarioNavaUtil(string empresa, string strNomAcceso, string strClave, ref string jellyBean)
        {
            Usuario objUsuario = null;
            try
            {
                string cnx = CadenaConx.enlaceBD(empresa);
                SqlDataReader lector = SqlHelper.ExecuteReader(cnx, "TSP_VALIDAR_USUARIO_FCU0000", strNomAcceso);
                if (lector.Read())
                {
                    objUsuario = new Usuario();
                    objUsuario.codusu = lector.GetString(0);
                    objUsuario.clausu = lector.GetString(1);
                    objUsuario.nomacc = lector.GetString(2);
                    objUsuario.nomusu = lector.GetString(3);
                    objUsuario.codpto = lector.GetString(4);
                    objUsuario.codgru = lector.GetString(5);
                    objUsuario.codven = lector.GetString(6);
                    objUsuario.codalm = lector.GetString(7);
                    objUsuario.vtadir = lector.GetInt32(8);
                    objUsuario.cdocu = lector.GetString(9);
                    objUsuario.online = lector.GetInt32(10);
                    objUsuario.vtasoloalm = lector.GetInt32(11);
                    objUsuario.Email = lector.GetString(12);
                }
                lector.Close();

                if (objUsuario != null)
                {
                    if (strClave.Equals(validarContraseNava(objUsuario.clausu)))
                        return objUsuario;
                    else
                    {
                        objUsuario = null;
                        jellyBean = "Contraseña incorrecta";
                    }

                }
                else
                    jellyBean = "El usuario "+strNomAcceso+" no existe";
            }
            catch (SqlException ex)
            {
                LogWrite.writeLog(ex);
            }
            catch (Exception ex)
            {
                LogWrite.writeLog(ex);
                throw new Exception(ex.Message);
            }
            return objUsuario;
        }

        private string validarContraseNava(string strCifrada)
        {
            string strDescifrada = "";

            strCifrada = strCifrada.Trim(' ');
            if (Operators.CompareString(strCifrada, "", false) == 0)
                return "";
            int num1 = 0;
            int num2 = checked(strCifrada.Length - 1);
            int startIndex = num1;
            while (startIndex <= num2)
            {
                string str2 = Conversions.ToString(Strings.Chr(checked(Strings.Asc(strCifrada.Substring(startIndex, 1)) - 105)));
                strDescifrada += str2;
                checked { ++startIndex; }
            }
            return strDescifrada;
        }


    }
}
