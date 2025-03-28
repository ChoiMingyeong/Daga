using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace DagaTools.Models
{
    public class SignupModel
    {
        [Required]
        [EmailAddress]
        [Label("Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Label("Password")]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Label("ComparePassword")]
        [Compare(nameof(Password))]
        public string ComparePassword { get; set; } = string.Empty;

        [Required]
        [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
        public string Name { get; set; } = string.Empty;
    }
}
