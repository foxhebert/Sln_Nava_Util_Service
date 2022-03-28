using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
  public  class DetalleGuia
    {
        [DataMember] public string codProd { get; set; }
        [DataMember] public string marcaProd { get; set; }
        [DataMember] public string descProd { get; set; }
        [DataMember] public decimal cantProd { get; set; }
        [DataMember] public string UM { get; set; }
        [DataMember] public decimal preUni { get; set; }
        [DataMember] public decimal montoTotal { get; set; }
        [DataMember] public decimal dscto { get; set; }
        [DataMember] public string codAlmac { get; set; }
    }
}
