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
    
    public partial class sp_P_SEC_Usuario_Result
    {
        public int idUsuario { get; set; }
        public int idTipoUsuario { get; set; }
        public string codUsuario { get; set; }
        public string nombreCompleto { get; set; }
        public string email { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<System.DateTime> ultimaFechaMod { get; set; }
    }
}
