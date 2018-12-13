using Microsoft.EntityFrameworkCore;
using WAF.API.Models;

namespace WAF.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        // User Tables
        public DbSet<User> User { get; set; }

        // Business Tables
        public DbSet<Business> Business { get; set; }
        public DbSet<BusinessType> BusinessType { get; set; }
        public DbSet<PaymentOption> PaymentOption { get; set; }
        public DbSet<OpeningTime> OpeningTime { get; set; }
    }
}