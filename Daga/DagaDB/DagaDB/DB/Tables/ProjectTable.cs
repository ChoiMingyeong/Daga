using DagaCommon;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DagaDB.DB.Tables
{
    [Table("project")]
    public class ProjectTable
    {
        [Key]
        [Column("id")]
        public ulong ID { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;
    }
}
