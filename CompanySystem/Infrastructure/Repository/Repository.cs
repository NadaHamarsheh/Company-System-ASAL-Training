using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
	public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CompanySystemContext _context;

        public Repository(CompanySystemContext context)
        {
            _context = context;
        }

        public async Task<IList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(object id, T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<User>> GetUsersByRole(int id)
        {
            return await _context.Users.Where(x => x.UserRoleId == id).ToListAsync();
        }
    }
}