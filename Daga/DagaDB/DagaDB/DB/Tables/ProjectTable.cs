using DagaCommon;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DagaDB.DB.Tables
{
    [Table("project")]
    public class ProjectTable
    {
        public static ulong CreateID = 1;

        [Key]
        [Column("id")]
        public ulong ID { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;
    }
}
