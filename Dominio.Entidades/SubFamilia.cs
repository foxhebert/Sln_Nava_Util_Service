using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
   public class SubFamilia
    {
        [DataMember] public string codsub { get; set; }
        [DataMember] public string nomsub { get; set; }
    }
}
