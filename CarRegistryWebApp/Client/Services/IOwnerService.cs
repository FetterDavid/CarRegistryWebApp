using Model.Models;

namespace Client.Services
{
    public interface IOwnerService
    {
        public Task AddAsync(Owner owner);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<Owner>> GetAllAsync();
        public Task<Owner> GetByIdAsync(int id);
        public Task UpdateAsync(int id, Owner owner);

    }
}
