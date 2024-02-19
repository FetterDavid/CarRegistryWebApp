using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly CarRegistryDBContext _dbContext;

        public OwnerController(CarRegistryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Owner>>> Get()
        {
            return Ok(await _dbContext.Owners.ToListAsync());
        }

        //[HttpGet("{cars/ownerId}")]
        //public async Task<ActionResult<List<Car>>> GetCarsByOwnerId(int ownerId)
        //{
        //    ActionResult<List<Car>> result = await _dbContext.Cars.FromSqlRaw($"GetCarsByOwnerId {ownerId}").ToListAsync();
        //    return Ok(result);
        //}


        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetById(int id)
        {
            Owner? owner = await _dbContext.Owners.FindAsync(id);
            if (owner == null) return NotFound();
            return Ok(owner);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Owner ownerToUpdate)
        {
            Owner ownerInDb = await _dbContext.Owners.FindAsync(id);
            if (ownerInDb == null)
            {
                return NotFound();
            }
            _dbContext.Entry(ownerInDb).CurrentValues.SetValues(ownerToUpdate);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Owner owner = await _dbContext.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            _dbContext.Owners.Remove(owner);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Owner owner)
        {
            _dbContext.Owners.Add(owner);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
