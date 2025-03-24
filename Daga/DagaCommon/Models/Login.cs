using System.ComponentModel.DataAnnotations;

namespace DagaCommon.Models
{
    public class Login
    {
        [Required(ErrorMessage ="")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
