using DapperTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DapperTest.Data
{
    public class DapperDbContext : DbContext
    {
        public DapperDbContext(DbContextOptions<DapperDbContext> opts) : base(opts) { }
        
        public DbSet<Movie> Movies { get; set; }
    }
}