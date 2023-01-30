using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Models;

namespace UsingEntityFramework.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<dynamic> GetAllStudentsSorted(bool sortByFirstName, bool sortAscending);
        IEnumerable<dynamic> ListStudentsInClass(int classId);
    }
}
