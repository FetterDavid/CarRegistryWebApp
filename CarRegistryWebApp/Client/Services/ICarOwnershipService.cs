using Model.Models;
using System.Threading.Tasks;

namespace Client.Services
{
    /// <summary>
    /// Interface for the car ownership service, providing methods for interacting with car ownership-related data.
    /// </summary>
    public interface ICarOwnershipService
    {
        /// <summary>
        /// Adds a new car ownership record asynchronously.
        /// </summary>
        /// <param name="carOwnership">The car ownership record to add.</param>
        Task AddAsync(CarOwnership carOwnership);
        /// <summary>
        /// Deletes car ownership records by car ID asynchronously.
        /// </summary>
        /// <param name="carId">The ID of the car whose ownership records to delete.</param>
        Task DeleteByCarIdAsync(int carId);
    }
}
