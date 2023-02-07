using UsingEntityFramework.Data;

namespace UsingEntityFramework.Controllers
{
    internal class GradeController
    {
        // Method to list all grades set last month
        internal static void ListLastMonthGrades()
        {
            Console.Clear();
            Console.WriteLine("Last months grades:\n");
            using (FbgGymnDbContext context = new FbgGymnDbContext())
            {
                var gradesList = from grades in context.VwLastMonthGrades
                                 orderby grades.Kurs ascending
                                 select grades;

                foreach (var grade in gradesList)
                {
                    Console.WriteLine($"Student: {grade.Namn}\nGrade: {grade.Betyg}\nCourse: {grade.Kurs}\nTeacher: {grade.Betygsättare}\n");
                }

                Console.WriteLine(gradesList.Count() > 0 ? "All grades listed, press a key to return to main menu." : "No grades to list, press a key to return to main menu.");
            }
            Console.ReadKey();
            MainController.RunMainMenu();
        }
    }
}
