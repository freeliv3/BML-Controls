using BML_Controls_Backend.Domain.Models;
using BML_Controls_Backend.Domain.Persistence.Contexts;
using BML_Controls_Backend.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BML_Controls_Backend.Persistence.Repositories
{
    public class AdminRepository : BaseRepository, IAdminRepository
    {
        public AdminRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsynx(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
        }

        public void Delete(Admin admin)
        {
            _context.Admins.Remove(admin);
        }

        public async Task<Admin> FindById(int id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task<IEnumerable<Admin>> ListAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public void Update(Admin admin)
        {
            _context.Admins.Update(admin);
        }
    }
}
