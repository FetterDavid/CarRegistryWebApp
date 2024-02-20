using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;
using Model.Models;
using Server.Utilities;
using System.Linq;

namespace Server.Controllers
{
    /// <summary>
    /// Controller for managing car-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private CarRegistryDBContext _dbContext;

        public CarController(CarRegistryDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Retrieves all cars.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PaginationResult<Car>>> GatAll([FromQuery] Pagination pagination)
        {
            IQueryable<Car> cars = _dbContext.Cars.AsQueryable();
            int pageCount = Static.GetListPageCount<Car>(cars, pagination.QuantityPerPage);
            return Ok(new PaginationResult<Car> { Data = await cars.Paginate(pagination).ToListAsync(), PageCount = pageCount });
        }
        /// <summary>
        /// Retrieves all available cars.
        /// </summary>
        [HttpGet("available")]
        public async Task<ActionResult<PaginationResult<Car>>> GetAllAvailable([FromQuery] Pagination pagination)
        {
            List<Car> cars = await _dbContext.Cars.FromSqlRaw("GetAvailableCars").ToListAsync();
            int pageCount = Static.GetListPageCount<Car>(cars, pagination.QuantityPerPage);
            return Ok(new PaginationResult<Car>
            { Data = cars.Skip((pagination.Page - 1) * pagination.QuantityPerPage).Take(pagination.QuantityPerPage).ToList(), PageCount = pageCount });
        }
        /// <summary>
        /// Retrieves a car by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetById(int id)
        {
            Car? car = await _dbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null) return NotFound();
            return Ok(car);
        }
        /// <summary>
        /// Retrieves details of a car by its ID.
        /// </summary>
        [HttpGet("details{id}")]
        public async Task<ActionResult<CarDetails>> GetDetailsById(int id)
        {
            Car? car = await _dbContext.Cars.FindAsync(id);
            if (car == null) return NotFound();
            CarDetails carDetails = new();
            carDetails.Car = car;
            carDetails.Owner = (await _dbContext.Owners.FromSqlRaw($"GetOwnerByCarId {id}").ToListAsync()).FirstOrDefault();
            return Ok(carDetails);
        }
        /// <summary>
        /// Updates a car.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Car carToUpdate)
        {
            Car carInDb = await _dbContext.Cars.FindAsync(id);
            if (carInDb == null)
            {
                return NotFound();
            }
            _dbContext.Entry(carInDb).CurrentValues.SetValues(carToUpdate);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        /// <summary>
        /// Deletes a car by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteeByCarId(int id)
        {
            Car car = await _dbContext.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            List<CarOwnership>? carOwnerships = await _dbContext.CarOwnerships.ToListAsync();
            carOwnerships = carOwnerships?.Where(x => x.CarId == id).ToList();
            _dbContext.CarOwnerships.RemoveRange(carOwnerships);
            await _dbContext.SaveChangesAsync();
            _dbContext.Cars.Remove(car);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        /// <summary>
        /// Creates a new car.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(NewCar newCar)
        {
            _dbContext.Cars.Add(newCar.Car);
            await _dbContext.SaveChangesAsync();
            if (newCar.OwnerId > 0)
            {
                _dbContext.CarOwnerships.Add(new CarOwnership { CarId = newCar.Car.Id, OwnerId = newCar.OwnerId });
                await _dbContext.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
