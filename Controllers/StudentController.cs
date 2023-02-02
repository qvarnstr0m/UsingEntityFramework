using UsingEntityFramework.Data;
using UsingEntityFramework.Models;

namespace UsingEntityFramework.Controllers
{
    internal class StudentController
    {
        internal static void ListAllStudents()
        {
            Console.Clear();
            Console.WriteLine("List all students\n");
            string sortType;
            string sortOn;
            
            do
            {
                Console.Write("Sort on first name? (y/n) ");
                sortType = Console.ReadLine().ToLower().Trim();
            } while (sortType != "y" && sortType != "n");

            bool sortOnFirstname = sortType == "y" ? true : false;

            do
            {
                Console.Write("List ascending? (y/n) ");
                sortOn = Console.ReadLine().ToLower().Trim();
            } while (sortOn != "y" && sortOn != "n");

            bool sortOnAscending = sortOn == "y" ? true : false;

            Console.WriteLine();

            using (UnitOfWork unitOfWork = new UnitOfWork(new FbgGymnDbContext()))
            {
                var students = unitOfWork.Students.GetAllStudentsSorted(sortOnFirstname, sortOnAscending);

                foreach (var student in students)
                {
                    Console.WriteLine($"Name: {student.Name}\nAdress:\n{student.Adress}\nPhone: {student.Phone}\nEmail: {student.Email}\n");
                }
            }

            Console.Write("All students listed. Press a key to return to main menu.");
            Console.ReadKey();
            MainController.RunMainMenu();
        }

        internal static void ListStudentsInClass()
        {
            Console.Clear();
            Console.WriteLine("List all students in a class\n");

            // List all available classes and store list of available class id's
            Dictionary<int, string> availableClassIds = ClassController.ListGetClasses();

            bool parseSuccess;
            int userInput;
            Console.WriteLine();
            do
            {
                Console.Write("Enter a valid class id: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out userInput);
            } while (!parseSuccess || !availableClassIds.ContainsKey(userInput));
            Console.WriteLine();

            using (UnitOfWork unitOfWork = new UnitOfWork(new FbgGymnDbContext()))
            {
                var students = unitOfWork.Students.ListStudentsInClass(userInput);

                foreach (var student in students)
                {
                    Console.WriteLine($"Name: {student.Name}\nClass: {student.Class}\n");
                }
            }

            Console.Write("All students listed. Press a key to return to main menu.");
            Console.ReadKey();
            MainController.RunMainMenu();
        }

        internal static void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("Add a new member to the staff:\n");

            //Get user input for data to save as Staff object
            Console.Write("Enter first name: ");
            string fName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lName = Console.ReadLine();
            Console.Write("Enter personal number: ");
            string pNumber = Console.ReadLine();
            Console.Write("Enter email adress: ");
            string email = Console.ReadLine();
            Console.Write("Enter cellphone number: ");
            string phone = Console.ReadLine();
            Console.WriteLine("\nAvailable classes:");

            // List and save all available classes in dictonary
            Dictionary<int, string> availableClasses = ClassController.ListGetClasses();

            // Loop with TryParse to prevent user crashing app
            bool parseClassSuccess;
            int userClassInput;
            do
            {
                Console.Write("Enter a valid class id: ");
                parseClassSuccess = int.TryParse(Console.ReadLine(), out userClassInput);
            } while (!parseClassSuccess || !availableClasses.ContainsKey(userClassInput));

            Console.WriteLine("\nAvailable adresses:");

            // List and save all available adresses in dictonary
            Dictionary<int, string> availableAdresses = AdressController.ListGetAdresses();

            bool parseAdressSuccess;
            int userAdressInput;
            do
            {
                Console.Write("Enter a valid adress id: ");
                parseAdressSuccess = int.TryParse(Console.ReadLine(), out userAdressInput);
            } while (!parseAdressSuccess || !availableAdresses.ContainsKey(userAdressInput));

            Console.WriteLine($"\nName: {fName} {lName}\nPersonal number: {pNumber}\nEmail: {email}\nPhone: " +
                $"{phone}\nClass: {availableClasses[userClassInput]}\nAdress:\n{availableAdresses[userAdressInput]}");

            string userInput;
            do
            {
                Console.Write($"\nSave this new student to database? (y/n)");
                userInput = Console.ReadLine().ToLower();
            } while (userInput != "y" && userInput != "n");

            if (userInput == "y")
            {
                Student newStudent = new Student(fName, lName, pNumber, email, phone, userClassInput, userAdressInput);

                using (UnitOfWork unitOfWork = new UnitOfWork(new FbgGymnDbContext()))
                {
                    unitOfWork.Students.Add(newStudent);
                    unitOfWork.Save();
                }

                Console.WriteLine("Student added, press a key to return to main menu.");
                Console.ReadKey();
                MainController.RunMainMenu();
            }
            else
            {
                Console.WriteLine("Data will not be saved, press a key to return to main menu.");
                Console.ReadKey();
                MainController.RunMainMenu();
            }
        }
    }
}
