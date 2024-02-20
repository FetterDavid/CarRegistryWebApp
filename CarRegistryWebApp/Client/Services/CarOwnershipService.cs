using Model.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Services
{
    /// <summary>
    /// Service class for interacting with car ownership-related data through HTTP requests.
    /// </summary>
    public class CarOwnershipService : ICarOwnershipService
    {
        private HttpClient _httpClient;

        public CarOwnershipService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <inheritdoc/>
        public async Task AddAsync(CarOwnership carOwnership) => await _httpClient.PostAsJsonAsync("api/carownership", carOwnership);
        /// <inheritdoc/>
        public async Task DeleteByCarIdAsync(int id) => await _httpClient.DeleteAsync($"api/carownership/{id}");
    }
}
