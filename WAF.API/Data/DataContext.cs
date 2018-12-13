using Microsoft.EntityFrameworkCore;
using WAF.API.Models;

namespace WAF.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        // User Tables
        public DbSet<User> User { get; set; }
    }
}