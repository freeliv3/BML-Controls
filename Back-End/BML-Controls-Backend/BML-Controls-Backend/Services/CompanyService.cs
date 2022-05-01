using BML_Controls_Backend.Domain.Models;
using BML_Controls_Backend.Domain.Persistence.Repositories;
using BML_Controls_Backend.Domain.Services;
using BML_Controls_Backend.Domain.Services.Comunications;

namespace BML_Controls_Backend.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public CompanyService(ICompanyRepository repository, IUnitOfWork unitOfWork)
        {
            _companyRepository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CompanyResponse> DeleteAsync(int id)
        {
            var existingCompany = await _companyRepository.FindById(id);
            if (existingCompany == null)
                return new CompanyResponse("Company not found");
            try
            {
                _companyRepository.Delete(existingCompany);
                await _unitOfWork.CompleteAsync();
                return new CompanyResponse(existingCompany);
            }
            catch (Exception e)
            {
                return new CompanyResponse("Has ocurred an error deleting the company" + e.Message);
            }
        }

        public async Task<IEnumerable<Company>> FindByUserId(int userId)
        {
            var list = await _companyRepository.FindByUserId(userId);
            return list;
        }

        public async Task<CompanyResponse> GetByIdAsync(int id)
        {
            var existingCompany = await _companyRepository.FindById(id);
            if (existingCompany == null)
                return new CompanyResponse("Company nor found");
            return new CompanyResponse(existingCompany);
        }

        public async Task<IEnumerable<Company>> GetByUserIdAndCompanyId(int userId, int companyId)
        {
            var list = await _companyRepository.FindByUserIdAndCompanyId(userId, companyId);
            return list;
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            var list = await _companyRepository.ListAsync();
            return list;
        }

        public async Task<CompanyResponse> SaveAsync(Company company)
        {
            try
            {
                await _companyRepository.AddAsync(company);
                await _unitOfWork.CompleteAsync();
                return new CompanyResponse(company);
            }
            catch (Exception e)
            {
                return new CompanyResponse("Has ocurred an error saving the career " + e.Message);
            }
        }

        public async Task<CompanyResponse> SaveAsync(int userId, Company company)
        {
            try
            {
                company.UserId = userId;
                await _companyRepository.AddAsync(company);
                await _unitOfWork.CompleteAsync();
                return new CompanyResponse(company);
            }
            catch(Exception e)
            {
                return new CompanyResponse("has ocurred an error saving the career " + e.Message);
            }
        }

        public async Task<CompanyResponse> UpdateAsync(int id, Company company)
        {
            var existingCompany = await _companyRepository.FindById(id);
            if (existingCompany == null)
                return new CompanyResponse("Company not found");

            existingCompany.Name = company.Name;
            existingCompany.UserId = company.UserId;
            try
            {
                _companyRepository.Update(existingCompany);
                await _unitOfWork.CompleteAsync();
                return new CompanyResponse(existingCompany);
            }
            catch (Exception e)
            {
                return new CompanyResponse("Has ocurred an error updating the company " + e.Message);
            }
        }
    }
}
