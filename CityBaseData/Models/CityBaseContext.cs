using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CityBaseData.Models
{
    public partial class CityBaseContext : DbContext
    {
        public CityBaseContext()
        {
        }

        public CityBaseContext(DbContextOptions<CityBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<CityRatings> CityRatings { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<States> States { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=citybase-db-server.database.windows.net;Database=CityBase;User Id=citybase-admin;Password=base123!;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityName).IsRequired();

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("ImageURL")
                    .HasMaxLength(300);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_States");
            });

            modelBuilder.Entity<CityRatings>(entity =>
            {
                entity.HasKey(e => e.RatingId);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.CityRatings)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CityRatings_Cities");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryName).IsRequired();
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.Property(e => e.StateName).IsRequired();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_States_Countries");
            });
        }
    }
}
