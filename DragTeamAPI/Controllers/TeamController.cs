using DragTeamAPI.DTOs;
using DragTeamAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DragTeamAPI.DTOs.CarDTO;
using static DragTeamAPI.DTOs.DriverDTO;
using static DragTeamAPI.DTOs.MechanicDTO;
using static DragTeamAPI.DTOs.TeamDTO;

namespace DragTeamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly ILogger<TeamController> _logger;

        public TeamController(ITeamService teamService, ILogger<TeamController> logger)
        {
            _teamService = teamService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamResponseDTO>>> GetAll()
        {
            try
            {
                var teams = await _teamService.GetAllTeamsAsync();
                return Ok(teams);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all teams");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamResponseDTO>> GetById(Guid id)
        {
            try
            {
                var team = await _teamService.GetTeamByIdAsync(id);
                if (team == null)
                    return NotFound($"Team with ID {id} not found");

                return Ok(team);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting team by ID");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TeamResponseDTO>> Create([FromBody] TeamCreateDTO teamDto)
        {
            try
            {
                var created = await _teamService.CreateTeamAsync(teamDto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating team");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeamResponseDTO>> Update(Guid id, [FromBody] TeamUpdateDTO teamDto)
        {
            try
            {
                var updated = await _teamService.UpdateTeamAsync(id, teamDto);
                if (updated == null)
                    return NotFound($"Team with ID {id} not found");

                return Ok(updated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating team");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var deleted = await _teamService.DeleteTeamAsync(id);
                if (!deleted)
                    return NotFound($"Team with ID {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting team");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{teamId}/mechanics")]
        public async Task<ActionResult> AddMechanic(Guid teamId, [FromBody] MechanicCreateDTO mechanicDto)
        {
            try
            {
                var result = await _teamService.AddMechanicAsync(teamId, mechanicDto);
                if (!result)
                    return NotFound($"Team with ID {teamId} not found");

                return Ok("Mechanic added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding mechanic");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("mechanics/{mechanicId}")]
        public async Task<ActionResult> RemoveMechanic(Guid mechanicId)
        {
            try
            {
                await _teamService.RemoveMechanicAsync(mechanicId);
                return Ok("Mechanic removed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing mechanic");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{teamId}/drivers")]
        public async Task<ActionResult> AddDriver(Guid teamId, [FromBody] DriverCreateDTO driverDto)
        {
            try
            {
                var result = await _teamService.AddDriverAsync(teamId, driverDto);
                if (!result)
                    return NotFound($"Team with ID {teamId} not found");

                return Ok("Driver added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding driver");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("drivers/{driverId}")]
        public async Task<ActionResult> RemoveDriver(Guid driverId)
        {
            try
            {
                await _teamService.RemoveDriverAsync(driverId);
                return Ok("Driver removed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing driver");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{teamId}/cars")]
        public async Task<ActionResult> AddCar(Guid teamId, [FromBody] CarCreateDTO carDto)
        {
            try
            {
                var result = await _teamService.AddCarAsync(teamId, carDto);
                if (!result)
                    return NotFound($"Team with ID {teamId} not found");

                return Ok("Car added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding car");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("cars/{carId}")]
        public async Task<ActionResult> RemoveCar(Guid carId)
        {
            try
            {
                await _teamService.RemoveCarAsync(carId);
                return Ok("Car removed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing car");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

