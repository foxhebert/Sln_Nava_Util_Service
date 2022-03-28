using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.SqlServer.Util
{
    public class _Rpt_Parametro
    {
        public string ParametroName { get; set; }
        public string ParametroText { get; set; }
        public int ParametroTamaño { get; set; }

        public _Rpt_Parametro(string parametroName, string parametroText, int parametroTamaño)
        {
            ParametroName = parametroName;
            ParametroText = parametroText;
            ParametroTamaño = parametroTamaño;
        }

        public _Rpt_Parametro(string parametroName, string parametroText)
        {
            ParametroName = parametroName;
            ParametroText = parametroText;
        }

        public _Rpt_Parametro()
        {
        }
    }
}
