using System.ComponentModel.DataAnnotations;

namespace DragTeamAPI.Entities
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;

        public List<Car> Cars { get; set; } = [];
        public List<Driver> Drivers { get; set; } = [];
        public List<Mechanic> Mechanics { get; set; } = [];
    }
}
