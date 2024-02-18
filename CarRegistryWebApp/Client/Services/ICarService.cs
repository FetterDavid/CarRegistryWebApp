using Model.Models;

namespace Client.Services
{
    public interface ICarService
    {
        public Task<IEnumerable<Car>> GetAllCarAsync();
        public Task<Car> GetCarByIdAsync(int id);
    }
}
