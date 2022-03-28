using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract]
    public class Vendedor
    {
        [DataMember] public string codven { get; set; }
        [DataMember] public string nomven { get; set; }
    }
}
