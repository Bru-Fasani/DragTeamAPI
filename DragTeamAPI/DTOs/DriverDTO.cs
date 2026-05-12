using DragTeamAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace DragTeamAPI.DTOs
{
    public class DriverDTO
    {
        public class DriverCreateDTO
        {
            [Required]
            public string Name { get; set; } = string.Empty;
            public string? Nickname { get; set; }

        }

        public class DriverResponseDTO
        {
            public Guid Id { get; set; }
            [Required]
            public string Name { get; set; } = string.Empty;
            public string? Nickname { get; set; }
            public Guid TeamId { get; set; }
        }

    }
}
