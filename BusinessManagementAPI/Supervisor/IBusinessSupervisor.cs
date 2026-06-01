using BusinessManagementAPI.Models;

namespace BusinessManagementAPI.Supervisor
{
    public interface IBusinessSupervisor
    {
        Task<List<Business>> GetAllAsync();

        Task<Business> GetByIdAsync(string businessId);

        Task AddAsync(Business business);

        Task UpdateAsync(string businessId, Business business);

        Task DeleteAsync(string businessId);
    }
}
