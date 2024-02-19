using Model.DTOs;
using Model.Models;
using System.Net.Http;
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

        public async Task AddAsync(NewCar newCar) => await _httpClient.PostAsJsonAsync("api/car", newCar);

        public async Task DeleteAsync(int id) => await _httpClient.DeleteAsync($"api/car/{id}");

        public async Task<IEnumerable<Car>> GetAllAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Car>>("api/car");

        public async Task<IEnumerable<Car>> GetAllAvailableAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Car>>("api/car/available");

        public async Task<Car> GetByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Car>($"api/car/{id}");

        public async Task<CarDetails> GetDetailsByIdAsync(int id) => await _httpClient.GetFromJsonAsync<CarDetails>($"api/car/details{id}");

        public async Task UpdateAsync(int id, Car car) => await _httpClient.PutAsJsonAsync($"api/car/{id}", car);
    }
}
