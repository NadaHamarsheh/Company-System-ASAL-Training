using System;
using Business.Interfaces;
using Business.Models;
using Business.Mapping;
using Business.View;
using Infrastructure.Repositery;
using Infrastructure;

namespace Business.Managers
{
	public class DepartmentManager : IDepartmentManager
	{
        private readonly DepartmentRepositery _DepartmentRepositery;
        private readonly DepartmentMapping _DepartmentMapping;

        public async Task<DepartmentView> Insert(DepartmentModel DepartmentModel)
        {
            var Department = await _DepartmentMapping.ModelToEntity(DepartmentModel);

            //Department.CreatedOn = DateTime.Now;
            //Department.CreatedBy = "";                 // name of the logging user
            //Department.ModifiedOn = DateTime.Now;
            //Department.ModifiedBy = "";                // name of the logging user



            await _DepartmentRepositery.Insert(Department);
            //await _departmentRepositery.Save();

            var DepartmentView = await _DepartmentMapping.EntityToView(Department);

            return await Task.FromResult(DepartmentView);
        }
    }
}

