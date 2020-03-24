using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TripNetCore.DAL.DbModels
{
    public partial class DevCodeContext : DbContext
    {
        public DevCodeContext()
        {
        }

        public DevCodeContext(DbContextOptions<DevCodeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<TransType> TransType { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=alkodell2018\\sqlexpress;Initial Catalog=DevCode;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>(entity =>
            {
                entity.Property(e => e.AirportId).ValueGeneratedNever();

                entity.Property(e => e.IataIdent)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IcaoCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Ident)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Lat)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Lon)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransType>(entity =>
            {
                entity.Property(e => e.TransTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.TripDate).HasColumnType("datetime");

                entity.HasOne(d => d.Airport)
                    .WithMany(p => p.Trip)
                    .HasForeignKey(d => d.AirportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trip_Airport");

                entity.HasOne(d => d.TransType)
                    .WithMany(p => p.Trip)
                    .HasForeignKey(d => d.TransTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trip_TransType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
