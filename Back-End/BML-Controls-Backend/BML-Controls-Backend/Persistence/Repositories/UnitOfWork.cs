using BML_Controls_Backend.Domain.Persistence.Contexts;
using BML_Controls_Backend.Domain.Persistence.Repositories;

namespace BML_Controls_Backend.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
