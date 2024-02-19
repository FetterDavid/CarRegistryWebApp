using Model.Models;

namespace Client.Services
{
    public interface ICarService
    {
        public Task AddAsync(Car car);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Car>> GetAllAsync();
        public Task<Car> GetByIdAsync(int id);
        public Task UpdateAsync(int id, Car car);
    }
}
