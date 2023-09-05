using System;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositery
{
	public class DepartmentRepositery : IDepartmentRepositery
	{
        private readonly CompanySystemContext _context;

        public async Task Insert(Department Department)
        {
            await _context.Set<Department>().AddAsync(Department);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        //public async Task GetCurrentUser()
        //{
        //}
    }
}

