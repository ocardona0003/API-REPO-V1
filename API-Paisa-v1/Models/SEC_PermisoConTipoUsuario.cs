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
    
    public partial class SEC_PermisoConTipoUsuario
    {
        public int idPermisoConTipoUsuario { get; set; }
        public int idTipoUsuario { get; set; }
        public int idPermiso { get; set; }
        public Nullable<System.DateTime> ultimaFecha { get; set; }
    
        public virtual SEC_Permisos SEC_Permisos { get; set; }
        public virtual SEC_TipoUsuario SEC_TipoUsuario { get; set; }
    }
}
