using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TeendokLista.API.Models
{
    public partial class TeendokContext : DbContext
    {
        public TeendokContext()
        {
        }

        public TeendokContext(DbContextOptions<TeendokContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Feladat> feladatok { get; set; }
        public virtual DbSet<Felhasznalo> felhasznalok { get; set; }
        public virtual DbSet<Szerepkor> szerepkorok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user id=root;database=teendoklista", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.21-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Feladat>(entity =>
            {
                entity.HasOne(d => d.Felhasznalo)
                    .WithMany(p => p.feladatok)
                    .HasForeignKey(d => d.FelhasznaloId)
                    .HasConstraintName("FK_Feladatok_Felhasznalok_FelhasznaloId");
            });

            modelBuilder.Entity<Felhasznalo>(entity =>
            {
                entity.HasOne(d => d.Szerepkor)
                    .WithMany(p => p.felhasznalok)
                    .HasForeignKey(d => d.Szerepkor_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("felhasznalok_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
