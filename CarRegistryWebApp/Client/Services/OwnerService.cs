using Model.Models;
using System.IO;
using System.Net.Http.Json;

namespace Client.Services
{
    public class OwnerService : IOwnerService
    {
        private HttpClient _httpClient;

        public OwnerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddAsync(Owner owner) => await _httpClient.PostAsJsonAsync("api/owner", owner);
        
        public async Task DeleteAsync(int id) => await _httpClient.DeleteAsync($"api/owner/{id}");

        public async Task<IEnumerable<Owner>> GetAllAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Owner>>("api/owner");

        public async Task<Owner> GetByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Owner>($"api/owner/{id}");

        public async Task UpdateAsync(int id, Owner owner) => await _httpClient.PutAsJsonAsync($"api/owner/{id}", owner);
      
    }
}
