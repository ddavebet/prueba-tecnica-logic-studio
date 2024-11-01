using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(
                entity =>
                    entity.HasData(
                        new Usuario
                        {
                            Id = 1,
                            Nombre = "admin",
                            Contrasena =
                                "vg0EhCNIiwog7rJVXRPQoCa+HfCgF/OxwhJwkRJPVN6Aivih4aCZNKzUnIDt//nvZfGa5w5xR+T+vJxaRW51Jg==",
                            Salt =
                                "5JQDVb2gBxzbgcTSNz4WFxEuB6yzEy7usQCHktLLOiJyx4E63FAmT80Ynu99rBvkivkTfN5CWi+a30qHaSImqg==",
                        }
                    )
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
