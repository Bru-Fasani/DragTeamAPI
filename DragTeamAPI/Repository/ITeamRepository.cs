using DragTeamAPI.Entities;

namespace DragTeamAPI.Repository
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team?> GetByIdAsync(Guid id);
        Task<Team> CreateAsync(Team team);
        Task<Team> UpdateAsync(Team team);
        Task<bool> DeleteAsync(Guid id);
    
        Task AddMechanicAsync(Guid teamId, Mechanic mechanic);
        Task AddDriverAsync(Guid teamId, Driver driver);
        Task AddCarAsync(Guid teamId, Car car);
        Task RemoveMechanicAsync(Guid mechanicId);
        Task RemoveDriverAsync(Guid driverId);
        Task RemoveCarAsync(Guid carId);
    }
}
