using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;
using Model.Models;
using Server.Utilities;

namespace Shared.Controllers
{
    /// <summary>
    /// Controller for managing owner-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly CarRegistryDBContext _dbContext;

        public OwnerController(CarRegistryDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Retrieves all owners.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PaginationResult<Owner>>> GatAll([FromQuery] Pagination pagination, [FromQuery] string? searchText)
        {
            IQueryable<Owner> owners = _dbContext.Owners.AsQueryable();
            if (!string.IsNullOrEmpty(searchText))
            {
                string[] words = searchText.Split(' ');
                foreach (string word in words)
                {
                    owners = owners.Where(x => x.FirstName.Contains(word) || x.LastName.Contains(word));
                }
            }
            int pageCount = Static.GetListPageCount<Owner>(owners, pagination.QuantityPerPage);
            return Ok(new PaginationResult<Owner> { Data = await owners.Paginate(pagination).ToListAsync(), PageCount = pageCount });
        }
        /// <summary>
        /// Retrieves an owner by their ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetById(int id)
        {
            Owner? owner = await _dbContext.Owners.FindAsync(id);
            if (owner == null) return NotFound();
            return Ok(owner);
        }
        /// <summary>
        /// Retrieves details of an owner by their ID.
        /// </summary>
        [HttpGet("details{id}")]
        public async Task<ActionResult<OwnerDetails>> GetDetailsById(int id)
        {
            Owner? owner = await _dbContext.Owners.FindAsync(id);
            if (owner == null) return NotFound();
            OwnerDetails ownerDetails = new();
            ownerDetails.Owner = owner;
            ownerDetails.Cars = await _dbContext.Cars.FromSqlRaw($"GetCarsByOwnerId {id}").ToListAsync();
            return Ok(ownerDetails);
        }
        /// <summary>
        /// Updates an owner by their ID.
        /// </summary>
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
        /// <summary>
        /// Deletes an owner by their ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Owner owner = await _dbContext.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            List<CarOwnership>? carOwnerships = await _dbContext.CarOwnerships.ToListAsync();
            carOwnerships = carOwnerships?.Where(x => x.OwnerId == id).ToList();
            _dbContext.CarOwnerships.RemoveRange(carOwnerships);
            _dbContext.Owners.Remove(owner);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        /// <summary>
        /// Creates a new owner.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(Owner owner)
        {
            _dbContext.Owners.Add(owner);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
