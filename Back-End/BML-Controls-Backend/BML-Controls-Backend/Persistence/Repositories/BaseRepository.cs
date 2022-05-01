using BML_Controls_Backend.Domain.Persistence.Contexts;

namespace BML_Controls_Backend.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
