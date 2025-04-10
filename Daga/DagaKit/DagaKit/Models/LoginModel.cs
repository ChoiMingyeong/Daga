using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace DagaKit.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Label("Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Label("Password")]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}
