using System.ComponentModel.DataAnnotations;

namespace DagaKit.Models
{
    public class ProjectModel
    {
        [Required]
        public ulong Id { get; init; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
