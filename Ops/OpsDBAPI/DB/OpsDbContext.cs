using Microsoft.EntityFrameworkCore;

namespace OpsDBApi.DB
{
    public class OpsDbContext(string connectionString) : DbContext
    {
        public DbSet<AccountTable> Accounts { get; set; }

        private readonly string _connectionString = connectionString;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ops");
        }
    }
}
