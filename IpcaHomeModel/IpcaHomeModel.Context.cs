//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IpcaHomeModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IpcaHomeEntities : DbContext
    {
        public IpcaHomeEntities()
            : base("name=IpcaHomeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AgenteImobiliaria> AgenteImobiliaria { get; set; }
        public virtual DbSet<Alojamento> Alojamento { get; set; }
        public virtual DbSet<Estudante> Estudante { get; set; }
        public virtual DbSet<Localização> Localização { get; set; }
        public virtual DbSet<PartilhaRedesSociais> PartilhaRedesSociais { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Proprietario> Proprietario { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }
    }
}
