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

        public Task<Owner> GetOwnerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
