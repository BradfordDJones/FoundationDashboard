using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorServerTemplate.Models;

namespace BlazorServerTemplate.Data
{
    public partial class FoundationTSContext : DbContext
    {
        public FoundationTSContext()
        {
        }

        public FoundationTSContext(DbContextOptions<FoundationTSContext> options) : base(options)
        {
        }

        public virtual DbSet<MarketCap> MarketCaps { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=MasterDataTSTDB;Initial Catalog=FoundationTS;Integrated Security=SSPI;Persist Security Info=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarketCap>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MarketCap");

                entity.HasIndex(e => e.Ticker, "UQ_MarketCap_Ticker")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MarketCap1)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("MarketCap");

                entity.Property(e => e.Ticker).HasMaxLength(100);
            });



            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MatterDateLimit).HasColumnType("datetime");

                entity.Property(e => e.TimeEntryBeginDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
