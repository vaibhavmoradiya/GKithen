namespace ServiceApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDbModel3 : DbContext
    {
        public MyDbModel3()
            : base("name=MyDbModel31")
        {
        }

        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.ServiceType1)
                .IsFixedLength();
        }
    }
}
