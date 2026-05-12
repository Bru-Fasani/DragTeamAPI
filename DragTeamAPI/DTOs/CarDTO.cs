using System.ComponentModel.DataAnnotations;

namespace DragTeamAPI.DTOs
{
    public class CarDTO
    {
        public class CarCreateDTO
        {
            public string? Name { get; set; } = string.Empty;
            [Required]
            public string Model { get; set; } = string.Empty;
            [Required]
            public string Engine { get; set; } = string.Empty;
            public int Horsepower { get; set; }
      
            public decimal QualifyingTime { get; set; }
        }

        public class CarResponseDTO
        {
            public Guid Id { get; set; }
            public string? Name { get; set; } = string.Empty;
            [Required]
            public string Model { get; set; } = string.Empty;
            [Required]
            public string Engine { get; set; } = string.Empty;
            public int Horsepower { get; set; }
            public decimal QualifyingTime { get; set; }
            public Guid TeamId { get; set; }

        }
    }
}
