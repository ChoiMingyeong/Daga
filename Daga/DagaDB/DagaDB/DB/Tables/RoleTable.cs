using DagaCommon;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DagaDB.DB.Tables
{
    [Table("role")]
    public class RoleTable
    {
        [Key]
        [Column("project_id")]
        public ulong ProjectID { get; set; }

        [Key]
        [Column("id")]
        public byte ID { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;
    }
}
