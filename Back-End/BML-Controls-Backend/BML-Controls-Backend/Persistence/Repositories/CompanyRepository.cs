using BML_Controls_Backend.Domain.Models;
using BML_Controls_Backend.Domain.Persistence.Contexts;
using BML_Controls_Backend.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BML_Controls_Backend.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public void Delete(Company company)
        {
            _context.Companies.Remove(company);
        }

        public async Task<Company> FindById(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<IEnumerable<Company>> FindByUserId(int userId)
        {
            return await _context.Companies
                .Where(c => c.UserId == userId)
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Company>> FindByUserIdAndCompanyId(int userId, int companyId)
        {
            return await _context.Companies
                .Where(c => c.UserId == userId && c.Id == companyId)
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }
    }
}
