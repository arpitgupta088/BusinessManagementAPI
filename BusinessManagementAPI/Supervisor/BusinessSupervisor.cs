using BusinessManagementAPI.Models;
using BusinessManagementAPI.Repository;

namespace BusinessManagementAPI.Supervisor
{
    public class BusinessSupervisor : IBusinessSupervisor
    {
        private readonly IBusinessRepository _businessRepository;

        public BusinessSupervisor(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public async Task<List<Business>> GetAllAsync()
        {
            return await _businessRepository.GetAllAsync();
        }

        public async Task<Business?> GetByIdAsync(string businessId)
        {
            return await _businessRepository.GetByIdAsync(businessId);
        }

        public async Task AddAsync(Business business)
        {
            await _businessRepository.AddAsync(business);
        }

        public async Task UpdateAsync(string businessId, Business business)
        {
            await _businessRepository.UpdateAsync(businessId, business);
        }

        public async Task DeleteAsync(string businessId)
        {
            await _businessRepository.DeleteAsync(businessId);
        }
    }
}