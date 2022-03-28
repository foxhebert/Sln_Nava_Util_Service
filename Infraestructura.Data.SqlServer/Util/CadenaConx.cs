using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.SqlServer.Util
{
    public class CadenaConx
    {
        public static string enlaceBD(string empresa)
        {
            return ConfigurationManager.ConnectionStrings[empresa].ConnectionString;
        }
    }
}
