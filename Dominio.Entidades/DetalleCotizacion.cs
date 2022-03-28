using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
   [DataContract]
    public class DetalleCotizacion
    {     

        [DataMember] public string   idProdu       { get; set; }
        [DataMember] public string   codProdu      { get; set; }
        [DataMember] public string   cantProdu     { get; set; }
        [DataMember] public string   descProdu     { get; set; }
        [DataMember] public string   UM            { get; set; }
        [DataMember] public string   marcaProdu    { get; set; }
        [DataMember] public string   nomfam        { get; set; }
        [DataMember] public string   nomsub        { get; set; }
        [DataMember] public string   nomgrup       { get; set; }
        [DataMember] public string   stockFisico   { get; set; }
        [DataMember] public string   stockDispon   { get; set; }
        [DataMember] public string   dsctPercent   { get; set; }

        [DataMember] public string   precio        { get; set; }
        [DataMember] public string   cost          { get; set; }
        [DataMember] public string   msto          { get; set; }

        [DataMember] public string   moneitem      { get; set; }
        [DataMember] public string   aigv          { get; set; }
        [DataMember] public string   tota          { get; set; }
        [DataMember] public string   totn          { get; set; }


        //vacio


        //[DataMember] public string    idProdu         { get; set; }
        //[DataMember] public string    codProducto     { get; set; }
        //[DataMember] public string    cantProducto    { get; set; }
        //[DataMember] public string    descProdu       { get; set; }
        //[DataMember] public string    unidMedida      { get; set; }
        //[DataMember] public string    marcaProdu      { get; set; }
        //[DataMember] public string    nomfamLinea     { get; set; }
        //[DataMember] public string    nomsubLinea     { get; set; }
        //[DataMember] public string    nomgrupTipo     { get; set; }
        //[DataMember] public string    stkFisico       { get; set; }
        //[DataMember] public string    stkDispon       { get; set; }


        /*
        [DataMember] public DateTime   fecha          { get; set; }
        [DataMember] public string     cdocu          { get; set; }
        [DataMember] public string     ndocu          { get; set; }
        [DataMember] public string     codcli         { get; set; }
        [DataMember] public Double     tcam           { get; set; }
        [DataMember] public string     mone           { get; set; }
        [DataMember] public string     moneitm        { get; set; }
        [DataMember] public string     aigv           { get; set; }
        [DataMember] public Double     item           { get; set; }
        [DataMember] public string     codi           { get; set; }
        [DataMember] public string     codf           { get; set; }
        [DataMember] public string     marc           { get; set; }
        [DataMember] public string     umed           { get; set; }
        [DataMember] public string     descr          { get; set; }
        [DataMember] public Double     cant           { get; set; }
        [DataMember] public Double     preu           { get; set; }
        [DataMember] public Double     tota           { get; set; }
        [DataMember] public Double     dsct           { get; set; }
        [DataMember] public Double     totn           { get; set; }
        [DataMember] public string     AnulaDetalle   { get; set; }
        [DataMember] public string     codalm         { get; set; }
        [DataMember] public Double     cost           { get; set; }
        [DataMember] public string     msto           { get; set; }
        */


        /*

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
