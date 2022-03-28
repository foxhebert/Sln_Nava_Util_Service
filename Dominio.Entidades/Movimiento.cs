using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class Movimiento
    {
        [DataMember] public DateTime fecha { get; set; }
        [DataMember] public string doc { get; set; }
        [DataMember] public string nom { get; set; }
        [DataMember] public decimal salida { get; set; }
        [DataMember] public decimal stock { get; set; }
        [DataMember] public decimal preUnd { get; set; }
        [DataMember] public string glosa { get; set; }
        [DataMember] public string referencia { get; set; }
        [DataMember] public string ordCompra { get; set; }
        [DataMember] public string docRegis { get; set; }
        [DataMember] public string tipoMov { get; set; }
    }
}
