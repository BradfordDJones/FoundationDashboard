using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorServerTemplate.Models.FoundationTS;

namespace BlazorServerTemplate.Data
{
    public partial class FoundationTSDbContext : DbContext
    {
        public FoundationTSDbContext()
        {
        }

        public FoundationTSDbContext(DbContextOptions<FoundationTSDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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

        public virtual DbSet<MarketCap> MarketCaps { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;
    }
}
