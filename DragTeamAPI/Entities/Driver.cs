using System.ComponentModel.DataAnnotations;

namespace DragTeamAPI.Entities
{
    public class Driver
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Nickname { get; set; }
        [Required]
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
