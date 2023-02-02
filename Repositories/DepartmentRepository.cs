using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Data;
using UsingEntityFramework.Models;

namespace UsingEntityFramework.Repositories
{
    internal class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(FbgGymnDbContext context)
            : base(context)
        {

        }

        public FbgGymnDbContext FbgGymnDbContext
        {
            get { return Context as FbgGymnDbContext; }
        }

        public IEnumerable<dynamic> GetNoDepartmentStaff()
        {
            var result = FbgGymnDbContext.Departments
                        .Join(FbgGymnDbContext.StaffDepartments, x => x.DepartmentId, y => y.FkDepartmentId, (staff, staffDepartment) => new { staff, staffDepartment })
                        .Join(FbgGymnDbContext.Departments, x => x.staffDepartment.FkDepartmentId, department => department.DepartmentId, (x, department) => new { x.staff, department })
                        .GroupBy(x => x.department.DepartmentName)
                        .Select(g => new { Department = g.Key, TotalEmployees = g.Count() });
            
            return result;
        }
    }
}
