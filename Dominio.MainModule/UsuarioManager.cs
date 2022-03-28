using Dominio.Entidades;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.MainModule
{
    public class UsuarioManager
    {
        public Usuario ValidarUsuarioNavaUtil(string empresa, string strNomAcceso, string strClave, ref string jellyBean)
        {
            return new UsuarioDAL().ValidarUsuarioNavaUtil(empresa,strNomAcceso,strClave,ref jellyBean);
        }

    }
}
