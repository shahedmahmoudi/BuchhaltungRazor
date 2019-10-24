using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bewerbungsdaten.Models
{
    public partial class ArbeitssucheContext : DbContext
    {
        public ArbeitssucheContext()
        {
        }

        public ArbeitssucheContext(DbContextOptions<ArbeitssucheContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bewerbung> Bewerbung { get; set; }
        public virtual DbSet<Standort> Standort { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SHAHED-PC\\SHDSQL;Database=Arbeitssuche;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Bewerbung>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adresse).HasMaxLength(200);

                entity.Property(e => e.Anforderungsdatum).HasColumnType("datetime");

                entity.Property(e => e.Art).HasMaxLength(50);

                entity.Property(e => e.Berufsbezeichnung).HasMaxLength(200);

                entity.Property(e => e.Ergebnis).HasMaxLength(2000);

                entity.Property(e => e.NameDerFirma).HasMaxLength(200);

                entity.Property(e => e.StandortId).HasColumnName("StandortID");

                entity.Property(e => e.Telefon).HasMaxLength(200);

                entity.Property(e => e.Webseite).HasMaxLength(50);

                entity.Property(e => e.Wiederholungsdatum).HasColumnType("datetime");

                entity.HasOne(d => d.Standort)
                    .WithMany(p => p.Bewerbung)
                    .HasForeignKey(d => d.StandortId)
                    .HasConstraintName("FK_Bewerbung_Standort");
            });

            modelBuilder.Entity<Standort>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Art).HasMaxLength(50);

                entity.Property(e => e.ElternId).HasColumnName("ElternID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
