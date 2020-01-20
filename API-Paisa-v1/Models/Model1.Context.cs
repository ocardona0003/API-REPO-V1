﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class paisaEntities : DbContext
    {
        public paisaEntities()
            : base("name=paisaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SEC_PermisoConTipoUsuario> SEC_PermisoConTipoUsuario { get; set; }
        public virtual DbSet<SEC_Permisos> SEC_Permisos { get; set; }
        public virtual DbSet<SEC_TipoUsuario> SEC_TipoUsuario { get; set; }
        public virtual DbSet<SEC_Usuario> SEC_Usuario { get; set; }
        public virtual DbSet<EspecificacionImpresion> EspecificacionImpresion { get; set; }
        public virtual DbSet<RodilloImpresion> RodilloImpresion { get; set; }
        public virtual DbSet<TipoImpresion> TipoImpresion { get; set; }
        public virtual DbSet<ImagenDetalleImpresion> ImagenDetalleImpresion { get; set; }
        public virtual DbSet<ProtocoloDetalleImpresion> ProtocoloDetalleImpresion { get; set; }
    
        public virtual ObjectResult<sp_V_SEC_Usuario_Result> sp_V_SEC_Usuario()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_V_SEC_Usuario_Result>("sp_V_SEC_Usuario");
        }
    
        public virtual ObjectResult<sp_P_SEC_Usuario_Result> sp_P_SEC_Usuario(string codUsuario, string password)
        {
            var codUsuarioParameter = codUsuario != null ?
                new ObjectParameter("codUsuario", codUsuario) :
                new ObjectParameter("codUsuario", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_P_SEC_Usuario_Result>("sp_P_SEC_Usuario", codUsuarioParameter, passwordParameter);
        }
    
        public virtual ObjectResult<sp_P_SEC_Usuario1_Result> sp_P_SEC_Usuario1(string codUsuario, string password)
        {
            var codUsuarioParameter = codUsuario != null ?
                new ObjectParameter("codUsuario", codUsuario) :
                new ObjectParameter("codUsuario", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_P_SEC_Usuario1_Result>("sp_P_SEC_Usuario1", codUsuarioParameter, passwordParameter);
        }
    
        public virtual ObjectResult<sp_V_SEC_Usuario1_Result> sp_V_SEC_Usuario1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_V_SEC_Usuario1_Result>("sp_V_SEC_Usuario1");
        }
    
        public virtual ObjectResult<sp_P_SEC_Usuario2_Result> sp_P_SEC_Usuario2(string codUsuario, string password)
        {
            var codUsuarioParameter = codUsuario != null ?
                new ObjectParameter("codUsuario", codUsuario) :
                new ObjectParameter("codUsuario", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_P_SEC_Usuario2_Result>("sp_P_SEC_Usuario2", codUsuarioParameter, passwordParameter);
        }
    
        public virtual int sp_I_SEC_Usuario(Nullable<int> idTipoUsuario, string codUsuario, byte[] pass, string nombreCompleto, string email, Nullable<bool> activo, Nullable<System.DateTime> ultimaFechaMod, Nullable<System.DateTime> ultimoIngreso)
        {
            var idTipoUsuarioParameter = idTipoUsuario.HasValue ?
                new ObjectParameter("idTipoUsuario", idTipoUsuario) :
                new ObjectParameter("idTipoUsuario", typeof(int));
    
            var codUsuarioParameter = codUsuario != null ?
                new ObjectParameter("codUsuario", codUsuario) :
                new ObjectParameter("codUsuario", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(byte[]));
    
            var nombreCompletoParameter = nombreCompleto != null ?
                new ObjectParameter("nombreCompleto", nombreCompleto) :
                new ObjectParameter("nombreCompleto", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            var ultimaFechaModParameter = ultimaFechaMod.HasValue ?
                new ObjectParameter("ultimaFechaMod", ultimaFechaMod) :
                new ObjectParameter("ultimaFechaMod", typeof(System.DateTime));
    
            var ultimoIngresoParameter = ultimoIngreso.HasValue ?
                new ObjectParameter("ultimoIngreso", ultimoIngreso) :
                new ObjectParameter("ultimoIngreso", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_I_SEC_Usuario", idTipoUsuarioParameter, codUsuarioParameter, passParameter, nombreCompletoParameter, emailParameter, activoParameter, ultimaFechaModParameter, ultimoIngresoParameter);
        }
    
        public virtual int sp_U_SEC_Usuario(Nullable<int> idUsuario, Nullable<int> idTipoUsuario, string codUsuario, byte[] pass, string nombreCompleto, string email, Nullable<bool> activo, Nullable<System.DateTime> ultimaFechaMod, Nullable<System.DateTime> ultimoIngreso)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var idTipoUsuarioParameter = idTipoUsuario.HasValue ?
                new ObjectParameter("idTipoUsuario", idTipoUsuario) :
                new ObjectParameter("idTipoUsuario", typeof(int));
    
            var codUsuarioParameter = codUsuario != null ?
                new ObjectParameter("codUsuario", codUsuario) :
                new ObjectParameter("codUsuario", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(byte[]));
    
            var nombreCompletoParameter = nombreCompleto != null ?
                new ObjectParameter("nombreCompleto", nombreCompleto) :
                new ObjectParameter("nombreCompleto", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            var ultimaFechaModParameter = ultimaFechaMod.HasValue ?
                new ObjectParameter("ultimaFechaMod", ultimaFechaMod) :
                new ObjectParameter("ultimaFechaMod", typeof(System.DateTime));
    
            var ultimoIngresoParameter = ultimoIngreso.HasValue ?
                new ObjectParameter("ultimoIngreso", ultimoIngreso) :
                new ObjectParameter("ultimoIngreso", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_U_SEC_Usuario", idUsuarioParameter, idTipoUsuarioParameter, codUsuarioParameter, passParameter, nombreCompletoParameter, emailParameter, activoParameter, ultimaFechaModParameter, ultimoIngresoParameter);
        }
    
        public virtual ObjectResult<sp_V_SEC_Usuario2_Result> sp_V_SEC_Usuario2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_V_SEC_Usuario2_Result>("sp_V_SEC_Usuario2");
        }
    
        public virtual int sp_I_SEC_Usuario1(Nullable<int> idTipoUsuario, string codUsuario, string pass, string nombreCompleto, string email, Nullable<bool> activo, Nullable<System.DateTime> ultimaFechaMod, Nullable<System.DateTime> ultimoIngreso)
        {
            var idTipoUsuarioParameter = idTipoUsuario.HasValue ?
                new ObjectParameter("idTipoUsuario", idTipoUsuario) :
                new ObjectParameter("idTipoUsuario", typeof(int));
    
            var codUsuarioParameter = codUsuario != null ?
                new ObjectParameter("codUsuario", codUsuario) :
                new ObjectParameter("codUsuario", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var nombreCompletoParameter = nombreCompleto != null ?
                new ObjectParameter("nombreCompleto", nombreCompleto) :
                new ObjectParameter("nombreCompleto", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            var ultimaFechaModParameter = ultimaFechaMod.HasValue ?
                new ObjectParameter("ultimaFechaMod", ultimaFechaMod) :
                new ObjectParameter("ultimaFechaMod", typeof(System.DateTime));
    
            var ultimoIngresoParameter = ultimoIngreso.HasValue ?
                new ObjectParameter("ultimoIngreso", ultimoIngreso) :
                new ObjectParameter("ultimoIngreso", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_I_SEC_Usuario1", idTipoUsuarioParameter, codUsuarioParameter, passParameter, nombreCompletoParameter, emailParameter, activoParameter, ultimaFechaModParameter, ultimoIngresoParameter);
        }
    
        public virtual int sp_U_SEC_Usuario1(Nullable<int> idUsuario, Nullable<int> idTipoUsuario, string codUsuario, string pass, string nombreCompleto, string email, Nullable<bool> activo, Nullable<System.DateTime> ultimaFechaMod, Nullable<System.DateTime> ultimoIngreso)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var idTipoUsuarioParameter = idTipoUsuario.HasValue ?
                new ObjectParameter("idTipoUsuario", idTipoUsuario) :
                new ObjectParameter("idTipoUsuario", typeof(int));
    
            var codUsuarioParameter = codUsuario != null ?
                new ObjectParameter("codUsuario", codUsuario) :
                new ObjectParameter("codUsuario", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var nombreCompletoParameter = nombreCompleto != null ?
                new ObjectParameter("nombreCompleto", nombreCompleto) :
                new ObjectParameter("nombreCompleto", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            var ultimaFechaModParameter = ultimaFechaMod.HasValue ?
                new ObjectParameter("ultimaFechaMod", ultimaFechaMod) :
                new ObjectParameter("ultimaFechaMod", typeof(System.DateTime));
    
            var ultimoIngresoParameter = ultimoIngreso.HasValue ?
                new ObjectParameter("ultimoIngreso", ultimoIngreso) :
                new ObjectParameter("ultimoIngreso", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_U_SEC_Usuario1", idUsuarioParameter, idTipoUsuarioParameter, codUsuarioParameter, passParameter, nombreCompletoParameter, emailParameter, activoParameter, ultimaFechaModParameter, ultimoIngresoParameter);
        }
    
        public virtual int sp_I_SEC_Usuario2(Nullable<int> idTipoUsuario, string codUsuario, string pass, string nombreCompleto, string email, Nullable<bool> activo, Nullable<System.DateTime> ultimaFechaMod, Nullable<System.DateTime> ultimoIngreso)
        {
            var idTipoUsuarioParameter = idTipoUsuario.HasValue ?
                new ObjectParameter("idTipoUsuario", idTipoUsuario) :
                new ObjectParameter("idTipoUsuario", typeof(int));
    
            var codUsuarioParameter = codUsuario != null ?
                new ObjectParameter("codUsuario", codUsuario) :
                new ObjectParameter("codUsuario", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var nombreCompletoParameter = nombreCompleto != null ?
                new ObjectParameter("nombreCompleto", nombreCompleto) :
                new ObjectParameter("nombreCompleto", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            var ultimaFechaModParameter = ultimaFechaMod.HasValue ?
                new ObjectParameter("ultimaFechaMod", ultimaFechaMod) :
                new ObjectParameter("ultimaFechaMod", typeof(System.DateTime));
    
            var ultimoIngresoParameter = ultimoIngreso.HasValue ?
                new ObjectParameter("ultimoIngreso", ultimoIngreso) :
                new ObjectParameter("ultimoIngreso", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_I_SEC_Usuario2", idTipoUsuarioParameter, codUsuarioParameter, passParameter, nombreCompletoParameter, emailParameter, activoParameter, ultimaFechaModParameter, ultimoIngresoParameter);
        }
    
        public virtual int sp_I_SEC_Usuario3(Nullable<int> idTipoUsuario, string codUsuario, string pass, string nombreCompleto, string email, Nullable<bool> activo, Nullable<System.DateTime> ultimaFechaMod, Nullable<System.DateTime> ultimoIngreso)
        {
            var idTipoUsuarioParameter = idTipoUsuario.HasValue ?
                new ObjectParameter("idTipoUsuario", idTipoUsuario) :
                new ObjectParameter("idTipoUsuario", typeof(int));
    
            var codUsuarioParameter = codUsuario != null ?
                new ObjectParameter("codUsuario", codUsuario) :
                new ObjectParameter("codUsuario", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var nombreCompletoParameter = nombreCompleto != null ?
                new ObjectParameter("nombreCompleto", nombreCompleto) :
                new ObjectParameter("nombreCompleto", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            var ultimaFechaModParameter = ultimaFechaMod.HasValue ?
                new ObjectParameter("ultimaFechaMod", ultimaFechaMod) :
                new ObjectParameter("ultimaFechaMod", typeof(System.DateTime));
    
            var ultimoIngresoParameter = ultimoIngreso.HasValue ?
                new ObjectParameter("ultimoIngreso", ultimoIngreso) :
                new ObjectParameter("ultimoIngreso", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_I_SEC_Usuario3", idTipoUsuarioParameter, codUsuarioParameter, passParameter, nombreCompletoParameter, emailParameter, activoParameter, ultimaFechaModParameter, ultimoIngresoParameter);
        }
    
        public virtual int sp_U_SEC_Usuario2(Nullable<int> idUsuario, Nullable<int> idTipoUsuario, string codUsuario, string pass, string nombreCompleto, string email, Nullable<bool> activo, Nullable<System.DateTime> ultimaFechaMod, Nullable<System.DateTime> ultimoIngreso)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var idTipoUsuarioParameter = idTipoUsuario.HasValue ?
                new ObjectParameter("idTipoUsuario", idTipoUsuario) :
                new ObjectParameter("idTipoUsuario", typeof(int));
    
            var codUsuarioParameter = codUsuario != null ?
                new ObjectParameter("codUsuario", codUsuario) :
                new ObjectParameter("codUsuario", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var nombreCompletoParameter = nombreCompleto != null ?
                new ObjectParameter("nombreCompleto", nombreCompleto) :
                new ObjectParameter("nombreCompleto", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            var ultimaFechaModParameter = ultimaFechaMod.HasValue ?
                new ObjectParameter("ultimaFechaMod", ultimaFechaMod) :
                new ObjectParameter("ultimaFechaMod", typeof(System.DateTime));
    
            var ultimoIngresoParameter = ultimoIngreso.HasValue ?
                new ObjectParameter("ultimoIngreso", ultimoIngreso) :
                new ObjectParameter("ultimoIngreso", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_U_SEC_Usuario2", idUsuarioParameter, idTipoUsuarioParameter, codUsuarioParameter, passParameter, nombreCompletoParameter, emailParameter, activoParameter, ultimaFechaModParameter, ultimoIngresoParameter);
        }
    }
}
