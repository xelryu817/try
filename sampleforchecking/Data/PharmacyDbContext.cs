using sampleforchecking.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using sampleforchecking.Models.CashierView_model;

namespace sampleforchecking.Data
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options) { }
        //Admin Module
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<VATEntry> VATEntries { get; set; }
        public DbSet<Discount> Discount { get; set; }

        //Cashier Module
        public DbSet<SalesItem> SalesItems { get; set; }
        public DbSet<SalesTransaction> SalesTransaction { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Account)
                .WithOne(a => a.Employee)
                .HasForeignKey<Account>(a => a.EmployeeId);
        }
    }
}
