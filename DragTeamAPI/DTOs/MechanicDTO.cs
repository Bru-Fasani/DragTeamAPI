namespace DragTeamAPI.DTOs
{
    public class MechanicDTO
    {
        public class MechanicCreateDTO
        {
            public string Name { get; set; } = string.Empty;
            public string Specialty { get; set; } = string.Empty;
        }

           public class MechanicResponseDTO
            {
                public Guid Id { get; set; }
                public string Name { get; set; } = string.Empty;
                public string Specialty { get; set; } = string.Empty;
                public Guid TeamId { get; set; }
           }  


    }
}
