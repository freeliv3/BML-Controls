using BML_Controls_Backend.Domain.Models;
using BML_Controls_Backend.Domain.Services.Comunications;

namespace BML_Controls_Backend.API.Domain.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> ListAsync();
        Task<AdminResponse> GetByIdAsync(int id);
        Task<AdminResponse> SaveAsync(Admin admin);
        Task<AdminResponse> UpdateAsync(int id, Admin admin);
        Task<AdminResponse> DeleteAsync(int id);
    }
}
