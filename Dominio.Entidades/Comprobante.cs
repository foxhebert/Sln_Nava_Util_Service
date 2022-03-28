using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Comprobante
    {
        public string codigo { get; set; }
        public string marca { get; set; }
        public string descripcion { get; set; }
        public decimal cantidad { get; set; }
        public string um { get; set; }
        public decimal precio { get; set; }
        public decimal total { get; set; }
        public decimal stockFisico { get; set; }
        public decimal stockRelativo { get; set; }   
    }
}
