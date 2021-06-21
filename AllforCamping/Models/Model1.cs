namespace AllforCamping.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<compras> compras { get; set; }
        public virtual DbSet<empleados> empleados { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<compras>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<empleados>()
                .Property(e => e.nombre)
                .IsFixedLength();

            modelBuilder.Entity<empleados>()
                .Property(e => e.app)
                .IsFixedLength();

            modelBuilder.Entity<empleados>()
                .Property(e => e.apm)
                .IsFixedLength();

            modelBuilder.Entity<empleados>()
                .Property(e => e.area)
                .IsFixedLength();

            modelBuilder.Entity<empleados>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<empleados>()
                .Property(e => e.pass)
                .IsFixedLength();

            modelBuilder.Entity<usuarios>()
                .Property(e => e.nombre)
                .IsFixedLength();

            modelBuilder.Entity<usuarios>()
                .Property(e => e.ap_pat)
                .IsFixedLength();

            modelBuilder.Entity<usuarios>()
                .Property(e => e.ap_mat)
                .IsFixedLength();

            modelBuilder.Entity<usuarios>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<usuarios>()
                .Property(e => e.username)
                .IsFixedLength();

            modelBuilder.Entity<usuarios>()
                .Property(e => e.pass)
                .IsFixedLength();

            modelBuilder.Entity<usuarios>()
                .Property(e => e.calle)
                .IsFixedLength();

            modelBuilder.Entity<usuarios>()
                .Property(e => e.colonia)
                .IsFixedLength();
        }
    }
}
