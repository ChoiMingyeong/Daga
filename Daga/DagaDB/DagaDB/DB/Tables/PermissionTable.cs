using DagaCommon;
using DagaCommon.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DagaDB.DB.Tables
{
    [Table("permission")]
    public class PermissionTable
    {
        [Key]
        [Column("project_id")]
        public ulong ProjectID { get; set; }

        [Key]
        [Column("role_id")]
        public byte RoleID { get; set; }

        [Column("permission_type", TypeName = "tinyint")]
        public PermissionType PermissionType { get; set; }

        [Column("privileges", TypeName = "tinyint")]
        public Privileges Privileges { get; set; }
    }
}
