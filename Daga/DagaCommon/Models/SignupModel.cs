using System.ComponentModel.DataAnnotations;

namespace DagaCommon.Models
{
    public class SignupModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
