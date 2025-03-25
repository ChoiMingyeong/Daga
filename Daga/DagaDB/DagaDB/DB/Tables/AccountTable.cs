using DagaCommon;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DagaDB.DB.Tables
{
    [Table("account")]
    public class AccountTable
    {
        public static uint CreateID = 1;

        [Key]
        [Column("id")]
        public uint ID { get; set; }

        [Column("email", TypeName = "varchar(255)")]
        public string Email { get; set; } = string.Empty;

        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; } = string.Empty;

        [Column("name")]
        public string Name { get; set; } = string.Empty;
    }
}
