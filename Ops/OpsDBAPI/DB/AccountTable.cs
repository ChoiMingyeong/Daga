using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpsDBApi.DB
{
    [Table("account")]
    [PrimaryKey(nameof(Id))]

    public class AccountTable
    {
        [Column("id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ushort Id { get; set; }

        [Column("email", TypeName = "varchar(64)")]
        public string Email { get; set; } = string.Empty;

        [Column("password", TypeName = "varchar(15)")]
        public string Password { get; set; } = string.Empty;

        [Column("name", TypeName = "varchar(15)")]
        public string Name { get; set; } = string.Empty;
    }
}
