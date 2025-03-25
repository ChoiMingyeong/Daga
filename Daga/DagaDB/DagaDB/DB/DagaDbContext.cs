using DagaDB.DB.Tables;
using Microsoft.EntityFrameworkCore;

namespace DagaDB.DB
{
    //public class DagaDbContext : DbContext
    //{
    //    public DbSet<AccountTable> Accounts { get; set; }

    //    public DbSet<ProjectTable> Projects { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        base.OnConfiguring(optionsBuilder);
    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);
    //    }
    //}

    public class DagaDbContext
    {
        private static Lazy<DagaDbContext>? _instance = null;
        public static DagaDbContext Instance
        {
            get
            {
                _instance ??= new();
                return _instance.Value;
            }
        }

        public List<AccountTable> Accounts = [];
        public List<ProjectTable> Projects = [];
        public List<ProjectAccountTable> ProjectAccounts = [];
        public List<PermissionTable> Permissions = [];
        public List<RoleTable> Roles = [];
    }
}
