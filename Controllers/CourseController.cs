using UsingEntityFramework.Data;

namespace UsingEntityFramework.Controllers
{
    internal class CourseController
    {
        // This method does not yet implement the repository pattern
        internal static void ListGradeStats()
        {
            Console.Clear();
            Console.WriteLine("Statistics from all courses:\n");
            using (FbgGymnDbContext context = new FbgGymnDbContext())
            {
                var courseStatistics = from statistics in context.VwCourseGradesStatistics
                                       orderby statistics.CourseName ascending
                                       select statistics;

                foreach (var statistic in courseStatistics)
                {
                    Console.WriteLine($"Course name: {statistic.CourseName}\nAverage grade: {statistic.Medelbetyg}\nTop grade: {statistic.BästaBetyg}\nWorst grade: {statistic.SämstaBetyg}\n");
                }

                Console.WriteLine(courseStatistics.Count() > 0 ? "All courses listed, press a key to return to main menu." : "No courses to list, press a key to return to main menu.");
            }

            Console.ReadKey();
            MainController.RunMainMenu();
        }

        internal static void ListActiveCourses()
        {
            Console.Clear();
            Console.WriteLine("Currently active courses:\n");

            using (UnitOfWork unitOfWork = new UnitOfWork(new FbgGymnDbContext()))
            {
                var activeCourses = unitOfWork.Courses.ListActiveCourses();

                foreach (var course in activeCourses)
                {
                    Console.WriteLine($"Course name: {course.CourseName}\nCourse startdate: {course.CourseStartdate}\n");
                }

                Console.WriteLine(activeCourses.Count() > 0 ? "All courses listed, press a key to return to main menu." : "No courses to list, press a key to return to main menu.");
            }

            Console.ReadKey();
            MainController.RunMainMenu();
        }
    }
}
