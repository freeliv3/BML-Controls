using BML_Controls_Backend.API.Domain.Services;
using BML_Controls_Backend.Domain.Models;
using BML_Controls_Backend.Domain.Persistence.Repositories;
using BML_Controls_Backend.Domain.Services.Comunications;

namespace BML_Controls_Backend.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IAdminRepository repository, IUnitOfWork unitOfWork)
        {
            _adminRepository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<AdminResponse> DeleteAsync(int id)
        {
            var existingAdmin = await _adminRepository.FindById(id);
            if (existingAdmin == null)
                return new AdminResponse("Admin not found");
            try
            {
                _adminRepository.Delete(existingAdmin);
                await _unitOfWork.CompleteAsync();
                return new AdminResponse(existingAdmin);
            }
            catch (Exception e)
            {
                return new AdminResponse("Has ocurred an error deleting the admin "+e.Message);
            }

        }

        public async Task<AdminResponse> GetByIdAsync(int id)
        {
            var existingAdmin = await _adminRepository.FindById(id);
            if (existingAdmin == null)
                return new AdminResponse("Admin not found");
            return new AdminResponse(existingAdmin);
        }

        public async Task<IEnumerable<Admin>> ListAsync()
        {
            return await _adminRepository.ListAsync();
        }

        public async Task<AdminResponse> SaveAsync(Admin admin)
        {
            try
            {
                await _adminRepository.AddAsynx(admin);
                await _unitOfWork.CompleteAsync();
                return new AdminResponse(admin);
            }
            catch(Exception e)
            {
                return new AdminResponse("Has ocurred an erorr saving the admin " + e.Message);
            }
        }

        public async Task<AdminResponse> UpdateAsync(int id, Admin admin)
        {
            var existingAdmin = await _adminRepository.FindById(id);
            if (existingAdmin == null)
                return new AdminResponse("Admin not found");

            existingAdmin.Name = admin.Name;
            try
            {
                _adminRepository.Update(existingAdmin);
                await _unitOfWork.CompleteAsync();
                return new AdminResponse(existingAdmin);
            }
            catch (Exception e)
            {
                return new AdminResponse("Has ocurred an error updating the admin " + e.Message);
            }
        }
    }
}
