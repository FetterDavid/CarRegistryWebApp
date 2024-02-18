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
        public async Task<ActionResult<List<Owner>>> GetOwner()
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
        public async Task<ActionResult<Owner>> GetOwnerById(int id)
        {
            Owner? owner = await _dbContext.Owners.FirstOrDefaultAsync(o => o.Id == id);
            if (owner == null) return NotFound();
            return Ok(owner);
        }
    }
}
