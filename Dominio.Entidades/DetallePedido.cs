using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract]
    public class DetallePedido
    {
        [DataMember] public string codProdu { get; set; }
        [DataMember] public string marca { get; set; }
        [DataMember] public string descricpcion { get; set; }
        [DataMember] public string undMedida { get; set; }
        [DataMember] public decimal solicitado { get; set; }
        [DataMember] public decimal aprobado { get; set; }
        [DataMember] public decimal entregado { get; set; }
        [DataMember] public decimal pendiente { get; set; }
        [DataMember] public string porcentaje { get; set; }
        [DataMember] public decimal preUni { get; set; }
        [DataMember] public decimal total { get; set; }
        [DataMember] public decimal dscto { get; set; }
        [DataMember] public string almacen { get; set; }
    }
}
