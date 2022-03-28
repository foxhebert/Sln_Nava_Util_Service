using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class Familia
    {
        [DataMember] public string codfam { get; set; }
        [DataMember] public string nomfam { get; set; }
    }
}
