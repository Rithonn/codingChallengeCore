using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BreweryAPI.Models
{
    public partial class BreweryDBContext : DbContext
    {
        public BreweryDBContext()
        {
        }

        public BreweryDBContext(DbContextOptions<BreweryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brewery> Breweries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//              #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=upgraded-pc\\sqlexpress;Database=BreweryDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brewery>(entity =>
            {
                entity.HasKey(e => e.BreweryId);

                entity.ToTable("breweries");

                entity.Property(e => e.BreweryId).HasColumnName("breweryId");

                entity.Property(e => e.Address2)
                    .HasColumnType("text")
                    .HasColumnName("address_2");

                entity.Property(e => e.Address3)
                    .HasColumnType("text")
                    .HasColumnName("address_3");

                entity.Property(e => e.BreweryType)
                    .HasColumnType("text")
                    .HasColumnName("brewery_type");

                entity.Property(e => e.City)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasColumnType("text")
                    .HasColumnName("country");

                entity.Property(e => e.CountyProvince)
                    .HasColumnType("text")
                    .HasColumnName("county_province");

                entity.Property(e => e.Id)
                    .HasColumnType("text")
                    .HasColumnName("id");

                entity.Property(e => e.Latitude)
                    .HasColumnType("text")
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasColumnType("text")
                    .HasColumnName("longitude");

                entity.Property(e => e.Name)
                    .HasColumnType("text")
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasColumnType("text")
                    .HasColumnName("phone");

                entity.Property(e => e.PostalCode)
                    .HasColumnType("text")
                    .HasColumnName("postal_code");

                entity.Property(e => e.State)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.Street)
                    .HasColumnType("text")
                    .HasColumnName("street");

                entity.Property(e => e.Tags)
                    .HasColumnType("text")
                    .HasColumnName("tags");

                entity.Property(e => e.Testing).HasColumnName("testing");

                entity.Property(e => e.WebsiteUrl)
                    .HasColumnType("text")
                    .HasColumnName("website_url");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
