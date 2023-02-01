using UsingEntityFramework.Models;

namespace UsingEntityFramework.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<dynamic> GetAllStudentsSorted(bool sortByFirstName, bool sortAscending);
        IEnumerable<dynamic> ListStudentsInClass(int classId);
    }
}
