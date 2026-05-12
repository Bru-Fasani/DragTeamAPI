using DragTeamAPI.DTOs;
using DragTeamAPI.Entities;
using DragTeamAPI.Repository;
using static DragTeamAPI.DTOs.CarDTO;
using static DragTeamAPI.DTOs.DriverDTO;
using static DragTeamAPI.DTOs.MechanicDTO;
using static DragTeamAPI.DTOs.TeamDTO;

namespace DragTeamAPI.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;

        public TeamService(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TeamResponseDTO>> GetAllTeamsAsync()
        {
            var teams = await _repository.GetAllAsync();
            return teams.Select(MapToResponseDTO).ToList();
        }

        public async Task<TeamResponseDTO?> GetTeamByIdAsync(Guid id)
        {
            var team = await _repository.GetByIdAsync(id);
            return team != null ? MapToResponseDTO(team) : null;
        }

        public async Task<TeamResponseDTO> CreateTeamAsync(TeamCreateDTO teamDto)
        {
            var team = new Team
            {
                Name = teamDto.Name,
                City = teamDto.City
            };

            var created = await _repository.CreateAsync(team);
            return MapToResponseDTO(created);
        }

        public async Task<TeamResponseDTO?> UpdateTeamAsync(Guid id, TeamUpdateDTO teamDto)
        {
            var team = await _repository.GetByIdAsync(id);
            if (team == null) return null;

            if (!string.IsNullOrEmpty(teamDto.Name))
                team.Name = teamDto.Name;
            if (!string.IsNullOrEmpty(teamDto.City))
                team.City = teamDto.City;

            var updated = await _repository.UpdateAsync(team);
            return MapToResponseDTO(updated);
        }

        public async Task<bool> DeleteTeamAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<bool> AddMechanicAsync(Guid teamId, MechanicCreateDTO mechanicDto)
        {

            var mechanic = new Mechanic
            {
                Name = mechanicDto.Name,
                Specialty = mechanicDto.Specialty
            };

            await _repository.AddMechanicAsync(teamId, mechanic);
            return true;
        }

        public async Task<bool> RemoveMechanicAsync(Guid mechanicId)
        {
            await _repository.RemoveMechanicAsync(mechanicId);
            return true;
        }

        public async Task<bool> AddDriverAsync(Guid teamId, DriverCreateDTO driverDto)
        {

            var driver = new Driver
            {
                Name = driverDto.Name,
                Nickname = driverDto.Nickname
            };

            await _repository.AddDriverAsync(teamId, driver);
            return true;
        }

        public async Task<bool> RemoveDriverAsync(Guid driverId)
        {
            await _repository.RemoveDriverAsync(driverId);
            return true;
        }

        public async Task<bool> AddCarAsync(Guid teamId, CarCreateDTO carDto)
        {

            var car = new Car
            {
                Model = carDto.Model,
                Name = carDto.Name,
                Engine = carDto.Engine,
                Horsepower = carDto.Horsepower,
                QualifyingTime = carDto.QualifyingTime
            };

            await _repository.AddCarAsync(teamId, car);
            return true;
        }

        public async Task<bool> RemoveCarAsync(Guid carId)
        {
            await _repository.RemoveCarAsync(carId);
            return true;
        }

        private TeamResponseDTO MapToResponseDTO(Team team)
        {
            return new TeamResponseDTO
            {
                Id = Guid.Empty, 
                Name = team.Name,
                Mechanics = team.Mechanics.Select(m => new MechanicResponseDTO
                {
                    Id = Guid.Empty, 
                    Name = m.Name,
                    Specialty = m.Specialty,
                }).ToList(),
                Drivers = team.Drivers.Select(d => new DriverResponseDTO
                {
                    Id = Guid.Empty, 
                    Name = d.Name,
                }).ToList(),
                Cars = team.Cars.Select(c => new CarResponseDTO
                {
                    Id = Guid.Empty, 
                    Name = c.Name,
                    Model = c.Model,
                    Engine = c.Engine,
                    Horsepower = c.Horsepower,
                    QualifyingTime = c.QualifyingTime,
                }).ToList()
            };
        }


    }
}
