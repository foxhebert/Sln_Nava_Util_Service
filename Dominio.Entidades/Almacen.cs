﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
  public  class Almacen
    {
        [DataMember] public string codalm { get; set; }
        [DataMember] public string nomalm { get; set; }
    }
}
