using DragTeamAPI.DTOs;
using static DragTeamAPI.DTOs.CarDTO;
using static DragTeamAPI.DTOs.DriverDTO;
using static DragTeamAPI.DTOs.MechanicDTO;
using static DragTeamAPI.DTOs.TeamDTO;

namespace DragTeamAPI.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamResponseDTO>> GetAllTeamsAsync();
        Task<TeamResponseDTO?> GetTeamByIdAsync(Guid id);
        Task<TeamResponseDTO> CreateTeamAsync(TeamCreateDTO teamDto);
        Task<TeamResponseDTO?> UpdateTeamAsync(Guid id, TeamUpdateDTO teamDto);
        Task<bool> DeleteTeamAsync(Guid id);
        Task<bool> AddMechanicAsync(Guid teamId, MechanicCreateDTO mechanicDto);
        Task<bool> RemoveMechanicAsync(Guid mechanicId);
        Task<bool> AddDriverAsync(Guid teamId, DriverCreateDTO driverDto);
        Task<bool> RemoveDriverAsync(Guid driverId);
        Task<bool> AddCarAsync(Guid teamId, CarCreateDTO carDto);
        Task<bool> RemoveCarAsync(Guid carId);
    }
}
