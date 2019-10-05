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
        public DbSet<BillingInfo> BillingInfo { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<WebPage> WebPage { get; set; }

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
                entity.HasIndex(p => new { p.LocationIP, p.VisitedOn });
            });

            modelBuilder.Entity<BillingInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Title).HasMaxLength(15).IsRequired();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Address1).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Address2).HasMaxLength(50);
                entity.Property(e => e.City).HasMaxLength(80).IsRequired();
                entity.Property(e => e.State).HasMaxLength(80).IsRequired();
                entity.Property(e => e.Country).HasMaxLength(25).IsRequired();
                entity.Property(e => e.Phone).HasMaxLength(30);
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PostalCode).HasMaxLength(30).IsRequired();
                entity.Property(e => e.CreatedOn).IsRequired();
                entity.Property(e => e.Active).IsRequired();
                entity.HasIndex(p => new { p.FirstName });
                entity.HasIndex(p => new { p.LastName });

            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AmountPaid).HasColumnType("decimal(18, 6)").IsRequired();
                entity.Property(e => e.TransactionId).HasMaxLength(100).IsRequired();
                entity.Property(e => e.AuthCode).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PaymentType).IsRequired();
                entity.Property(e => e.PaymentDate).IsRequired();
                entity.Property(e => e.CurrencyId).IsRequired();
                entity.Property(e => e.CardF4L4).HasMaxLength(12).IsRequired();
                entity.Property(e => e.CardHolderName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.CardToken).HasMaxLength(200);
                entity.Property(e => e.Active).IsRequired();
                entity.HasIndex(p => new { p.PaymentDate });
                entity.HasIndex(p => new { p.CurrencyId });

                entity.HasOne(d => d.BillingInfo)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.BillingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_BillingInfo");
            });

            modelBuilder.Entity<WebPage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.HtmlContent).IsRequired();
                entity.HasIndex(e => e.WebPageTypeId).IsUnique();
            });
        }
    }
}
