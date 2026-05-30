using BusinessManagementAPI.Models;

namespace BusinessManagementAPI.Repository
{
    public interface IBusinessRepository
    {
        Task<List<Business>> GetAllAsync();

        Task<Business?> GetByIdAsync(string businessId);

        Task AddAsync(Business business);

        Task UpdateAsync(string businessId, Business business);
        Task DeleteAsync(string businessId);
    }
}
