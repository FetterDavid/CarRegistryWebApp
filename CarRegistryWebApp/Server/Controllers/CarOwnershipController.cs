using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;
using Model.Models;

namespace Server.Controllers
{
    /// <summary>
    /// Controller for managing car ownership operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarOwnershipController : ControllerBase
    {
        private CarRegistryDBContext _dbContext;

        public CarOwnershipController(CarRegistryDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Creates a new car ownership record.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(CarOwnership carOwnership)
        {
            CarOwnership currentCarOwnership = await _dbContext.CarOwnerships.FirstOrDefaultAsync(x => x.CarId == carOwnership.CarId);
            if (currentCarOwnership != null) _dbContext.CarOwnerships.Remove(currentCarOwnership);
            _dbContext.CarOwnerships.Add(carOwnership);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// Deletes a car ownership record by car ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByCarId(int id)
        {
            CarOwnership carOwnership = await _dbContext.CarOwnerships.FirstOrDefaultAsync(x => x.CarId == id);
            if (carOwnership == null)
            {
                return NotFound();
            }
            _dbContext.CarOwnerships.Remove(carOwnership);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
