using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorServerTemplate.Models.TSMDD;

namespace BlazorServerTemplate.Data
{
    public partial class TSMDDDbContext : DbContext
    {
        public TSMDDDbContext()
        {
        }

        public TSMDDDbContext(DbContextOptions<TSMDDDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
