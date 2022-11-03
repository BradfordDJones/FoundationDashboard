using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorServerTemplate.Models.Bucket;

namespace BlazorServerTemplate.Data
{
    public partial class BucketDbContext : DbContext
    {
        public BucketDbContext()
        {
        }

        public BucketDbContext(DbContextOptions<BucketDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppEventLog>(entity => 
            {
                entity.HasNoKey();
                entity.ToTable("AppEventLog");
                entity.Property(e => e.AppName).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
        public virtual DbSet<AppEventLog>? AppEventLogs { get; set; } = null!;
    }
}

