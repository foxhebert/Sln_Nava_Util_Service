using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Cliente
    {
        public string nroComprobante { get; set; }
        public string tipoComprobante { get; set; }
        public DateTime fecha { get; set; }
        public string cliente { get; set; }
        public string condVenta { get; set; }
        public string moneda { get; set; }
        public string vendedor { get; set; }
        public decimal total { get; set; }
        public string id { get; set; }
    }
}
