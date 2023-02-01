using UsingEntityFramework.Data;
using UsingEntityFramework.Models;

namespace UsingEntityFramework.Repositories
{
    internal class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(FbgGymnDbContext context) : base(context)
        {

        }

        public FbgGymnDbContext FbgGymnDbContext
        {
            get { return Context as FbgGymnDbContext; }
        }

        public IEnumerable<Course> ListActiveCourses()
        {
            var activeCourses = FbgGymnDbContext.Courses
                .Where(x => x.CourseEnddate != null)
                .OrderBy(x => x.CourseStartdate)
                .ToList();
            return activeCourses;
        }
    }
 }
