using System.ComponentModel.DataAnnotations;

namespace DragTeamAPI.Entities
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
        [Required]
        public string Engine { get; set; } = string.Empty;
        [Required]
        public int Horsepower { get; set; }
        public decimal QualifyingTime { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
