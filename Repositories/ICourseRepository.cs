using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Models;

namespace UsingEntityFramework.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> ListActiveCourses();
    }
}
