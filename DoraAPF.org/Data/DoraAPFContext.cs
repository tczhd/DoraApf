using DoraAPF.org.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Data
{
    public partial class DoraAPFContext : DbContext
    {
        public DoraAPFContext()
        {
        }

        public DoraAPFContext(DbContextOptions<DoraAPFContext> options)
            : base(options)
        {
        }

        public DbSet<VisitorLog> VisitorLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VisitorLog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.LocationIP).HasMaxLength(100);
                entity.Property(e => e.BrowserName).HasMaxLength(150);
            });

        }
    }
}
