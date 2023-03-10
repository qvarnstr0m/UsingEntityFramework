namespace UsingEntityFramework.Controllers
{
    internal class MainController
    {
        // Method that gets called on application start and handles UI menu
        internal static void RunMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to school!\n\nMenu:");
            Console.WriteLine("1. List all students");
            Console.WriteLine("2. List all students in a certain class");
            Console.WriteLine("3. Add new student");
            Console.WriteLine("4. List statistics from all courses");
            Console.WriteLine("5. List all grades one month back");
            Console.WriteLine("6. List all active courses");
            Console.WriteLine("7. List deparments and number of teachers");
            Console.WriteLine("8. Exit");
            Console.WriteLine();

            // Loop with TryParse to prevent user crashing app
            int menuInput;
            bool parseSuccess;
            do
            {
                Console.Write("Enter a valid number: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out menuInput);
            } while (!parseSuccess);

            switch (menuInput)
            {
                case 1:
                    StudentController.ListAllStudents();
                    break;
                case 2:
                    StudentController.ListStudentsInClass();
                    break;
                case 3:
                    StudentController.AddStudent();
                    break;
                case 4:
                    CourseController.ListGradeStats();
                    break;
                case 5:
                    GradeController.ListLastMonthGrades();
                    break;
                case 6:
                    CourseController.ListActiveCourses();
                    break;
                case 7:
                    DepartmentController.ListNoDepartmentStaff();
                    break;
                case 8:
                    Console.Write("Thank you for using this app, press a key to terminate.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    RunMainMenu();
                    break;
            }
        }
    }
}
