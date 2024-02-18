using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System.Collections;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private CarRegistryDBContext _dbContext;

        public CarController(CarRegistryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GatAllCarAsync()
        {
            return Ok(await _dbContext.Cars.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            Car? car = await _dbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null) return NotFound();
            return Ok(car);
        }
    }
}
