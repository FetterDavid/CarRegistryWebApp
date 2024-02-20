using Model.DTOs;
using Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Services
{
    /// <summary>
    /// Interface for the owner service, providing methods for interacting with owner-related data.
    /// </summary>
    public interface IOwnerService
    {
        /// <summary>
        /// Adds a new owner asynchronously.
        /// </summary>
        /// <param name="owner">The new owner to add.</param>
        Task AddAsync(Owner owner);
        /// <summary>
        /// Deletes an owner asynchronously by their ID.
        /// </summary>
        /// <param name="id">The ID of the owner to delete.</param>
        Task DeleteAsync(int id);
        /// <summary>
        /// Retrieves all owners asynchronously.
        /// </summary>
        /// <returns>A collection of owners.</returns>
        Task<PaginationResult<Owner>> GetAllAsync(string searchText, int page = 1, int quantityPerPage = 1);
        /// <summary>
        /// Retrieves an owner asynchronously by their ID.
        /// </summary>
        /// <param name="id">The ID of the owner to retrieve.</param>
        /// <returns>The owner with the specified ID.</returns>
        Task<Owner> GetByIdAsync(int id);
        /// <summary>
        /// Retrieves details of an owner asynchronously by their ID.
        /// </summary>
        /// <param name="id">The ID of the owner to retrieve details for.</param>
        /// <returns>Details of the owner with the specified ID.</returns>
        Task<OwnerDetails> GetDetailsByIdAsync(int id);
        /// <summary>
        /// Updates an owner asynchronously by their ID.
        /// </summary>
        /// <param name="id">The ID of the owner to update.</param>
        /// <param name="owner">The updated owner data.</param>
        Task UpdateAsync(int id, Owner owner);
    }
}
