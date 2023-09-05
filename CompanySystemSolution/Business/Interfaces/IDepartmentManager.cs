using System;
using Business.Models;
using Business.View;
using Infrastructure;

namespace Business.Interfaces
{
	public interface IDepartmentManager
	{
        Task<DepartmentView> Insert(DepartmentModel DepartmentModel);

    }
}

