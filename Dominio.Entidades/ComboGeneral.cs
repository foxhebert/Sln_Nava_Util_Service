using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract]
    public class ComboGeneral
    {
        [DataMember] public string cboCod { get; set; }
        [DataMember] public string cboDes { get; set; }
    }
}
