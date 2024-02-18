using Model.Models;
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

        public async Task<IEnumerable<Owner>> GetAllOwnerAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Owner>>("api/owner");

        public async Task<Owner> GetOwnerByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Owner>($"api/owner/{id}");
    }
}
