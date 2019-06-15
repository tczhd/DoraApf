using System;
using System.Collections.Generic;
using System.Text;
using DoraAPF.org.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoraAPF.org.Data
{
    public class ApplicationDbContext :  IdentityDbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<VisitorLog> VisitorLog { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.HasAnnotation("ProductVersion", "3.0.0-preview.19074.3");
        //    modelBuilder.Entity<VisitorLog>(entity =>
        //    {
        //        entity.HasKey(e => e.Id);
        //        entity.Property(e => e.Id).ValueGeneratedOnAdd();

        //    });
        //}
    }
}
