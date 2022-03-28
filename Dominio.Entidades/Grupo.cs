using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class Grupo
    {
        [DataMember] public string codgru { get; set; }
        [DataMember] public string nomgru { get; set; }
    }
}
