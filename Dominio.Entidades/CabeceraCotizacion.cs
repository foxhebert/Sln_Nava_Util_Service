using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
   [DataContract]
    public class CabeceraCotizacion
    {

        //[DataMember] public DateTime fecha        { get; set; }
        //[DataMember] public string   cdocu        { get; set; }
        [DataMember] public string   ndocu        { get; set; }
        [DataMember] public string   codcli       { get; set; }
        [DataMember] public string   nomcli       { get; set; }
        [DataMember] public string   ruccli       { get; set; }
        [DataMember] public string   atte         { get; set; }
        [DataMember] public string   nrefe        { get; set; }
        [DataMember] public string   requ         { get; set; }
        [DataMember] public string   mone         { get; set; }
        [DataMember] public decimal  tcam         { get; set; }
        [DataMember] public decimal  tota         { get; set; }
        [DataMember] public decimal  toti         { get; set; }
        [DataMember] public decimal  totn         { get; set; }
        [DataMember] public string   flag         { get; set; }
        [DataMember] public string   codven       { get; set; }
        [DataMember] public string   codcdv       { get; set; }
        [DataMember] public string   cond         { get; set; }
        [DataMember] public DateTime fven         { get; set; }
        [DataMember] public double   dura         { get; set; }
        [DataMember] public string   cOperacion   { get; set; }
        [DataMember] public string   obser        { get; set; }
        [DataMember] public string   estado       { get; set; }
        [DataMember] public string   obsere       { get; set; }
        [DataMember] public int      word         { get; set; }
        [DataMember] public string   obser2       { get; set; }
        [DataMember] public string   dirent       { get; set; }
        [DataMember] public string   codscc       { get; set; }
                                     

        /*
         * 
         * 
         * 
         * @fecha datetime, 
         * 
@cdocu Char(2),
@ndocu Char(12),
@codcli  Char(6),
@nomcli  Char(60),
@ruccli  Char(11),
@atte  Char(40),
@nrefe  Char(12),
@requ  Char(12),
@mone  Char(1),

@tcam  float,
@tota  Float,
@toti  Float,
@totn  Float,

@flag  Char(1),
@codven  Char(5),
@codcdv  Char(2),
@cond  Char(80),

@fven  datetime,
@dura  float,
@cOperacion char(15),
@obser Char(100) = '',
@estado Char(1) = '0',
@obsere Char(50) = '',
@word Int = 0,
@obser2 Char(100) = '',
@dirent     Char(60) = '',
@codscc Char(10) = ''
        [DataMember] public string nroGuia      
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

        */
    }
}
