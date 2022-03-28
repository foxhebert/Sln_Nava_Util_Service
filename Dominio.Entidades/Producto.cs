using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
   public class Producto
    {
        [DataMember] public string codProdu { get; set; }
        [DataMember] public string marcaProdu { get; set; }
        [DataMember] public string descProdu { get; set; }
        [DataMember] public string UM { get; set; }
        [DataMember] public decimal stockFisico { get; set; }
        [DataMember] public decimal stockDispon { get; set; }
        [DataMember] public decimal pedido { get; set; }
        [DataMember] public decimal prePEN { get; set; }
        [DataMember] public decimal preUSD { get; set; }
        [DataMember] public decimal stockOtr { get; set; }
        [DataMember] public string almacen { get; set; }
        [DataMember] public int    estado { get; set; }
        [DataMember] public string idProdu { get; set; }

        //otros        
        [DataMember] public string nomfam { get; set; }
        [DataMember] public string nomsub { get; set; }
        [DataMember] public string nomgrup { get; set; }
        [DataMember] public decimal uca1 { get; set; }

        [DataMember] public decimal precio    { get; set; }
        [DataMember] public decimal cost      { get; set; }
        [DataMember] public string  msto      { get; set; }
        [DataMember] public string  moneitem  { get; set; }
        [DataMember] public string  aigv      { get; set; }
    }
}
