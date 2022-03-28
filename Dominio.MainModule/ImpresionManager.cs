using Dominio.Entidades;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.MainModule
{
  public  class ImpresionManager
    {
        public Respuesta ImpresionTicket(string empresa, string ndocu, string comentario, bool tipoDoc)
        {
            return new ImpresionDAL().ImpresionTicket(empresa,ndocu,comentario,tipoDoc);
        }

        public Respuesta ImprimirEtiqueta(Guía datosPrint, int cantBultos)
        {
            return new ImpresionDAL().ImprimirEtiqueta(datosPrint,cantBultos);
        }

    }
}
