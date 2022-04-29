using BML_Controls_Backend.Domain.Models;
using BML_Controls_Backend.Domain.Services.Comunications;

namespace BML_Controls_Backend.Domain.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> ListAsync();
        Task<CompanyResponse> GetByIdAsync(int id);
        Task<IEnumerable<Company>> FindByUserId(int userId);
        Task<IEnumerable<Company>> GetByUserIdAndCompanyId(int userId, int companyId);
        Task<CompanyResponse> SaveAsync(Company company);
        Task<CompanyResponse> SaveAsync(int userId, Company company);
        Task<CompanyResponse> DeleteAsync(int id);
        Task<CompanyResponse> UpdateAsync(int id, Company company);
    }
}
