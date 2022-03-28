using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract]
    public class Pedido
    {
        [DataMember()] public string nroPedido { get; set; }
        [DataMember()] public DateTime fechaEmicion { get; set; }
        [DataMember()] public DateTime fechaEntrega { get; set; }
        [DataMember()] public string cliente { get; set; }
        [DataMember()] public string moneda { get; set; }
        [DataMember()] public string vendedor { get; set; }
        [DataMember()] public decimal tipoCambio { get; set; }
        [DataMember()] public decimal montoTotal { get; set; }
        [DataMember()] public string estado { get; set; }
        [DataMember()] public int situacion { get; set; }
        [DataMember()] public string cotizacion { get; set; }
        [DataMember()] public string facBolGuia { get; set; }
    }
}
