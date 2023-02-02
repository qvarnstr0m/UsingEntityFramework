using UsingEntityFramework.Models;

namespace UsingEntityFramework.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<dynamic> GetNoDepartmentStaff();
    }
}
