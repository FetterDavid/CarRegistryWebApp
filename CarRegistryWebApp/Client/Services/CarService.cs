using Model.Models;
using System.Net.Http.Json;

namespace Client.Services
{
    public class CarService : ICarService
    {
        private HttpClient _httpClient;

        public CarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Car>> GetAllCarAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Car>>("api/car");
        public async Task<Car> GetCarByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Car>($"api/car/{id}");
    }
}
