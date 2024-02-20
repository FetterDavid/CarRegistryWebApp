using Model.DTOs;
using Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Services
{
    /// <summary>
    /// Interface for the car service, providing methods for interacting with car-related data.
    /// </summary>
    public interface ICarService
    {
        /// <summary>
        /// Adds a new car asynchronously.
        /// </summary>
        /// <param name="newCar">The new car to add.</param>
        Task AddAsync(NewCar newCar);
        /// <summary>
        /// Deletes a car asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the car to delete.</param>
        Task DeleteAsync(int id);
        /// <summary>
        /// Retrieves all cars asynchronously.
        /// </summary>
        /// <returns>A collection of cars.</returns>
        Task<PaginationResult<Car>> GetAllAsync(int page = 1, int quantityPerPage = 10);
        /// <summary>
        /// Retrieves all available cars asynchronously.
        /// </summary>
        /// <returns>A collection of available cars.</returns>
        Task<PaginationResult<Car>> GetAllAvailableAsync(int page = 1, int quantityPerPage = 10);
        /// <summary>
        /// Retrieves a car asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the car to retrieve.</param>
        /// <returns>The car with the specified ID.</returns>
        Task<Car> GetByIdAsync(int id);
        /// <summary>
        /// Retrieves details of a car asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the car to retrieve details for.</param>
        /// <returns>Details of the car with the specified ID.</returns>
        Task<CarDetails> GetDetailsByIdAsync(int id);
        /// <summary>
        /// Updates a car asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the car to update.</param>
        /// <param name="car">The updated car data.</param>
        Task UpdateAsync(int id, Car car);
    }
}
