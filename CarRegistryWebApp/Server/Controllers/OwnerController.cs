﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;
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
        public async Task<ActionResult<List<Owner>>> GetAll()
        {
            return Ok(await _dbContext.Owners.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetById(int id)
        {
            Owner? owner = await _dbContext.Owners.FindAsync(id);
            if (owner == null) return NotFound();
            return Ok(owner);
        }

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
            List<CarOwnership> carOwnerships = await _dbContext.CarOwnerships.ToListAsync();
            carOwnerships = carOwnerships?.Where(x => x.OwnerId == id).ToList();
            _dbContext.CarOwnerships.RemoveRange(carOwnerships);
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
