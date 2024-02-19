using Model.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Client.Services
{
    public class CarOwnershipService : ICarOwnershipService
    {
        HttpClient _httpClient;

        public CarOwnershipService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddAsync(CarOwnership carOwnership) => await _httpClient.PostAsJsonAsync("api/carownership", carOwnership);

        public async Task DeleteByCarIdAsync(int id) => await _httpClient.DeleteAsync($"api/carownership/{id}");
    }
}
