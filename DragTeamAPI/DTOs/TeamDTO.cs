using static DragTeamAPI.DTOs.CarDTO;
using static DragTeamAPI.DTOs.DriverDTO;
using static DragTeamAPI.DTOs.MechanicDTO;

namespace DragTeamAPI.DTOs
{
    public class TeamDTO
    {
        public class TeamCreateDTO
        {
            public string Name { get; set; } = string.Empty;
            public string City { get; set; } = string.Empty;
        }

        public class TeamUpdateDTO
        {
            public string? Name { get; set; }
            public string? City { get; set; }
        }

        public class TeamResponseDTO
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string City { get; set; } = string.Empty;
            
            public List<MechanicResponseDTO> Mechanics { get; set; } = new();
            public List<DriverResponseDTO> Drivers { get; set; } = new();
            public List<CarResponseDTO> Cars { get; set; } = new();
        }
    }
}
