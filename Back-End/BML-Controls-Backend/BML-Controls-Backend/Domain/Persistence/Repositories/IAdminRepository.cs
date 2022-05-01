using BML_Controls_Backend.Domain.Models;

namespace BML_Controls_Backend.Domain.Persistence.Repositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> ListAsync();
        Task AddAsynx(Admin admin);
        Task<Admin> FindById(int id);
        void Update(Admin admin);
        void Delete(Admin admin);
    }
}
