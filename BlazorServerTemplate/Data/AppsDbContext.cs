using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorServerTemplate.Models;

namespace BlazorServerTemplate.Data
{
    public partial class AppsDbContext : DbContext
    {
        public AppsDbContext()
        {
        }

        public AppsDbContext(DbContextOptions<AppsDbContext> options) : base(options)
        {
        }

        public virtual DbSet<AppEventLogOld>? AppEventLogs { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server = APPSTSTDB; Initial Catalog = Bucket; Persist Security Info = True; Integrated Security = SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppEventLogOld>(entity => 
            {
                entity.HasNoKey();

                entity.ToTable("AppEventLog");

                entity.Property(e => e.AppName).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

