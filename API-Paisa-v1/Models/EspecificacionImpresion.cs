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
    
    public partial class EspecificacionImpresion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EspecificacionImpresion()
        {
            this.ProtocoloDetalleImpresion = new HashSet<ProtocoloDetalleImpresion>();
        }
    
        public int idEspecificacionImpresion { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> ultimoUsr { get; set; }
        public Nullable<System.DateTime> ultimaFec { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProtocoloDetalleImpresion> ProtocoloDetalleImpresion { get; set; }
    }
}
