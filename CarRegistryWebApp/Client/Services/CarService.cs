using Model.DTOs;
using Model.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Services
{
    /// <summary>
    /// Service class for interacting with car-related data through HTTP requests.
    /// </summary>
    public class CarService : ICarService
    {
        private HttpClient _httpClient;

        public CarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <inheritdoc/>
        public async Task AddAsync(NewCar newCar) => await _httpClient.PostAsJsonAsync("api/car", newCar);
        /// <inheritdoc/>
        public async Task DeleteAsync(int id) => await _httpClient.DeleteAsync($"api/car/{id}");
        /// <inheritdoc/>
        public async Task<IEnumerable<Car>> GetAllAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Car>>("api/car");
        /// <inheritdoc/>
        public async Task<IEnumerable<Car>> GetAllAvailableAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Car>>("api/car/available");
        /// <inheritdoc/>
        public async Task<Car> GetByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Car>($"api/car/{id}");
        /// <inheritdoc/>
        public async Task<CarDetails> GetDetailsByIdAsync(int id) => await _httpClient.GetFromJsonAsync<CarDetails>($"api/car/details{id}");
        /// <inheritdoc/>
        public async Task UpdateAsync(int id, Car car) => await _httpClient.PutAsJsonAsync($"api/car/{id}", car);
    }
}
