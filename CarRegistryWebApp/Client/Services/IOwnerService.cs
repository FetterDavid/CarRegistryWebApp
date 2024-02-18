using Model.Models;

namespace Client.Services
{
    public interface IOwnerService
    {
        public Task<IEnumerable<Owner>> GetAllOwnerAsync();
        public Task<Owner> GetOwnerByIdAsync(int id);
    }
}
