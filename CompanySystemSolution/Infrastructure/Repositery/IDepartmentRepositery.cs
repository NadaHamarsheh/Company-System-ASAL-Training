using System;

namespace Infrastructure.Repositery
{
	public interface IDepartmentRepositery
	{
        Task Insert(Department Department);
        Task Save();
    }
}

