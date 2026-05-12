namespace DragTeamAPI.Entities
{
    public class Mechanic
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
