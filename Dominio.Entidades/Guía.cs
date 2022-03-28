using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
   [DataContract]
   public class Guía
    {
        [DataMember] public string nroGuia { get; set; }
        [DataMember] public DateTime fecha { get; set; }
        [DataMember] public string rzCliente { get; set; }
        [DataMember] public string motivo { get; set; }
        [DataMember] public string condVenta { get; set; }
        [DataMember] public string moneda { get; set; }
        [DataMember] public string transp { get; set; }
        [DataMember] public string vendedor { get; set; }
        [DataMember] public decimal tipCambio { get; set; }
        [DataMember] public decimal montoTotal { get; set; }
        [DataMember] public int situacion { get; set; }
        [DataMember] public string facBol { get; set; }
        [DataMember] public string docRef { get; set; }
        [DataMember] public string ruccli { get; set; }
        [DataMember] public string dirent { get; set; }
    }
}
