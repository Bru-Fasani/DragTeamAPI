using DragTeamAPI.Data;
using DragTeamAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DragTeamAPI.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DragTeamDbContext _context;

        public TeamRepository(DragTeamDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams
                .Include(t => t.Mechanics)
                .Include(t => t.Drivers)
                .Include(t => t.Cars)
                .ToListAsync();
        }

        public async Task<Team?> GetByIdAsync(Guid id)
        {
            return await _context.Teams
                .Include(t => t.Mechanics)
                .Include(t => t.Drivers)
                .Include(t => t.Cars)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Team> CreateAsync(Team team)
        {
            team.Id = Guid.NewGuid();
           

            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team> UpdateAsync(Team team)
        {
          
            _context.Entry(team).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return false;

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task AddMechanicAsync(Guid teamId, Mechanic mechanic)
        {
            mechanic.Id = Guid.NewGuid();
            mechanic.TeamId = teamId;
            await _context.Mechanics.AddAsync(mechanic);
            await _context.SaveChangesAsync();
        }

        public async Task AddDriverAsync(Guid teamId, Driver driver)
        {
            driver.Id = Guid.NewGuid();
            driver.TeamId = teamId;
            await _context.Drivers.AddAsync(driver);
            await _context.SaveChangesAsync();
        }

        public async Task AddCarAsync(Guid teamId, Car car)
        {
            car.Id = Guid.NewGuid();
            car.TeamId = teamId;
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMechanicAsync(Guid mechanicId)
        {
            var mechanic = await _context.Mechanics.FindAsync(mechanicId);
            if (mechanic != null)
            {
                _context.Mechanics.Remove(mechanic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveDriverAsync(Guid driverId)
        {
            var driver = await _context.Drivers.FindAsync(driverId);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveCarAsync(Guid carId)
        {
            var car = await _context.Cars.FindAsync(carId);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }
    }
}
