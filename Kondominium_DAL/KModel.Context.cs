﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kondominium_DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KEntities : DbContext
    {
        public KEntities()
            : base("name=KEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aranceles> aranceles { get; set; }
        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<cuentasporcobrar> cuentasporcobrar { get; set; }
        public virtual DbSet<cuentasporcobrardetalle> cuentasporcobrardetalle { get; set; }
        public virtual DbSet<empresa> empresa { get; set; }
        public virtual DbSet<poligonos> poligonos { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<propiedades> propiedades { get; set; }
        public virtual DbSet<alerta> alerta { get; set; }
        public virtual DbSet<alertatipo> alertatipo { get; set; }
        public virtual DbSet<config> config { get; set; }
        public virtual DbSet<field> field { get; set; }
        public virtual DbSet<fieldsecurity> fieldsecurity { get; set; }
        public virtual DbSet<log_action> log_action { get; set; }
        public virtual DbSet<mainmenu> mainmenu { get; set; }
        public virtual DbSet<@object> @object { get; set; }
        public virtual DbSet<objecttype> objecttype { get; set; }
        public virtual DbSet<permission> permission { get; set; }
        public virtual DbSet<profile> profile { get; set; }
        public virtual DbSet<profilepermission> profilepermission { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<submenu> submenu { get; set; }
        public virtual DbSet<submenupermission> submenupermission { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<userprofile> userprofile { get; set; }
        public virtual DbSet<avenida> avenida { get; set; }
        public virtual DbSet<calles> calles { get; set; }
        public virtual DbSet<sendas> sendas { get; set; }
    }
}
