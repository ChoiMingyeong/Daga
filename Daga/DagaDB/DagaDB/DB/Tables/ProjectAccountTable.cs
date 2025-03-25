using DagaCommon;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.Marshalling;

namespace DagaDB.DB.Tables
{
    [Table("project_account")]
    public class ProjectAccountTable
    {
        [Key]
        [Column("project_id")]
        public ulong ProjectID { get; set; }

        [Key]
        [Column("account_id")]
        public uint AccountID { get; set; }

        [Column("role_id")]
        public byte RoleID { get; set; }
    }
}
