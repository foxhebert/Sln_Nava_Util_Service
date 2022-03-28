using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class Usuario
    {
        [DataMember] public string codusu { get; set; }
        [DataMember] public string clausu { get; set; }
        [DataMember] public string nomacc { get; set; }
        [DataMember] public string nomusu { get; set; }
        [DataMember] public string codpto { get; set; }
        [DataMember] public string codgru { get; set; }
        [DataMember] public string codven { get; set; }
        [DataMember] public string codalm { get; set; }
        [DataMember] public int vtadir { get; set; }
        [DataMember] public string cdocu { get; set; }
        [DataMember] public int online { get; set; }
        [DataMember] public int vtasoloalm { get; set; }
        [DataMember] public string Email { get; set; }
        [DataMember] public string empresa { get; set; }
    }
}
