using BML_Controls_Backend.Domain.Models;

namespace BML_Controls_Backend.Domain.Persistence.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> ListAsync();
        Task AddAsync(Company company);
        Task<Company> FindById(int id);
        Task<IEnumerable<Company>> FindByUserIdAndCompanyId(int userId, int companyId);
        Task<IEnumerable<Company>> FindByUserId(int userId);
        void Update(Company company);
        void Delete(Company company);

    }
}
