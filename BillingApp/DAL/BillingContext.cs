using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using BillingApp.Models;

namespace BillingApp.DAL
{
    public class BillingContext:DbContext
    {
        public BillingContext() : base("BillingContext")
        {
        }
        
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Bill>()
                .HasRequired(m => m.SenderCompany)
                .WithMany()
                .HasForeignKey(m => m.SenderCompanyId);

            modelBuilder.Entity<Bill>()
                .HasRequired(m => m.RecieverCompany)
                .WithMany()
                .HasForeignKey(m => m.RecieverCompanyId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
               .HasRequired(m => m.StartingLocation)
               .WithMany()
               .HasForeignKey(m => m.StartingLocationId);

            modelBuilder.Entity<Item>()
                .HasRequired(m => m.EndingLocation)
                .WithMany()
                .HasForeignKey(m => m.EndingLocationId).WillCascadeOnDelete(false);
        }
    
    }
}