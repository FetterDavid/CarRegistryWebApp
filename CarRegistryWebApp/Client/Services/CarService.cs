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

        public async Task AddAsync(Car car) => await _httpClient.PostAsJsonAsync("api/car", car);

        public async Task DeleteAsync(int id) => await _httpClient.DeleteAsync($"api/car/{id}");

        public async Task<IEnumerable<Car>> GetAllAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Car>>("api/car");
        public async Task<Car> GetByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Car>($"api/car/{id}");

        public async Task UpdateAsync(int id, Car car) => await _httpClient.PutAsJsonAsync($"api/car/{id}", car);
    }
}
