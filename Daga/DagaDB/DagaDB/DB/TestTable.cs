using DagaCommon;
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

        [Calculate]
        [Column("value")]
        public int Value { get; set; }

        [Column("value2")]
        public int Value2 { get; set; } = 0;

        [Calculate]
        [Column("value3")]
        public string Value3 { get; set; } = string.Empty;
    }
}
