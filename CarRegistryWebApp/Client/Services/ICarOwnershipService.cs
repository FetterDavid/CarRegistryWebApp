using Model.Models;

namespace Client.Services
{
    public interface ICarOwnershipService
    {
        public Task AddAsync(CarOwnership carOwnership);
        public Task DeleteByCarIdAsync(int carId);
    }
}
