﻿using Model.DTOs;
using Model.Models;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Services
{
    /// <summary>
    /// Service class for interacting with owner-related data through HTTP requests.
    /// </summary>
    public class OwnerService : IOwnerService
    {
        private HttpClient _httpClient;

        public OwnerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <inheritdoc/>
        public async Task AddAsync(Owner owner) => await _httpClient.PostAsJsonAsync("api/owner", owner);
        /// <inheritdoc/>
        public async Task DeleteAsync(int id) => await _httpClient.DeleteAsync($"api/owner/{id}");
        /// <inheritdoc/>
        public async Task<PaginationResult<Owner>> GetAllAsync(string searchText, int page = 1, int quantityPerPage = 1)
        {
            return await _httpClient.GetFromJsonAsync<PaginationResult<Owner>>($"api/owner?page={page}&quantityPerPage={quantityPerPage}&searchText={searchText}");
        }
        /// <inheritdoc/>
        public async Task<Owner> GetByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Owner>($"api/owner/{id}");
        /// <inheritdoc/>
        public async Task<OwnerDetails> GetDetailsByIdAsync(int id) => await _httpClient.GetFromJsonAsync<OwnerDetails>($"api/owner/details{id}");
        /// <inheritdoc/>
        public async Task UpdateAsync(int id, Owner owner) => await _httpClient.PutAsJsonAsync($"api/owner/{id}", owner);
    }
}
