using DagaCommon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DagaDB.DB
{
    [Table("test")]
    public class TestTable
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Key]
        [Column("value")]
        public int Value { get; set; }

        [Key]
        [Column("value2")]
        public int Value2 { get; set; } = 0;

        [Calculate]
        [Column("value3")]
        public string Value3 { get; set; } = string.Empty;
    }

    [Table("test2")]
    public class TestTable2
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Calculate]
        [Column("value")]
        public int Value { get; set; }

        [Column("value2")]
        public int Value2 { get; set; } = 0;

        [Calculate]
        [Column("value3")]
        public string Value3 { get; set; } = string.Empty;
    }
    [Table("test3")]
    public class TestTable3
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Calculate]
        [Column("value")]
        public int Value { get; set; }

        [Column("value2")]
        public int Value2 { get; set; } = 0;

        [Calculate]
        [Column("value3")]
        public string Value3 { get; set; } = string.Empty;
    }



    public class DagaDbContext : DbContext
    {
        public DbSet<TestTable> TestTable { get; set; }
        public DbSet<TestTable2> TestTable2 { get; set; }
        public DbSet<TestTable2> TestTable3 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 모델 구성 설정
            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Value).IsRequired();
                entity.Property(e => e.Value2).IsRequired();
                entity.Property(e => e.Value3).IsRequired();
            });
        }
    }
}
