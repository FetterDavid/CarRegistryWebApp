using Model.DTOs;
using Model.Models;

namespace Client.Services
{
    public interface ICarService
    {
        public Task AddAsync(NewCar newCar);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Car>> GetAllAsync();
        public Task<IEnumerable<Car>> GetAllAvailableAsync();
        public Task<Car> GetByIdAsync(int id);
        public Task<CarDetails> GetDetailsByIdAsync(int id);
        public Task UpdateAsync(int id, Car car);
    }
}
