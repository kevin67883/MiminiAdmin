using Microsoft.EntityFrameworkCore;
using MiminiAdmin.Controllers;

namespace MiminiAdmin.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<tblProducto> tblProducto { get; set; }

        public DbSet<TblRegistroVentas> TblRegistroVentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<tblProducto>()
                .HasKey(p => p.idProducto);

            modelBuilder.Entity<TblRegistroVentas>()
                .HasKey(v => v.IdRegistro);    // <-- CLAVE PRIMARIA
        }
    }
}
