//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_Paisa_v1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LargoSinFuelles
    {
        public int idLargoSinFuelles { get; set; }
        public int IdProtocoloDetMat { get; set; }
        public string idUnidadMedida { get; set; }
        public Nullable<decimal> menor15 { get; set; }
        public Nullable<decimal> C15a2999 { get; set; }
        public Nullable<decimal> mayor30 { get; set; }
        public Nullable<decimal> promedio { get; set; }
        public Nullable<int> ultimoUsr { get; set; }
        public Nullable<System.DateTime> ultimaFec { get; set; }
    
        public virtual ProtocoloDetalleMaterial ProtocoloDetalleMaterial { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
    }
}
