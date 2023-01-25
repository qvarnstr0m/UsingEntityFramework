// UsingEntityFramework, Martin Qvarnström SUT22
// Interacting with a database through Entity Framework
// Program.cs, where Main method starts app

using UsingEntityFramework.Models;

namespace UsingEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunMainMenu();
        }

        static void RunMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to school!\n\nMenu:");
            Console.WriteLine("1. List all students");
            Console.WriteLine("2. List all students in a certain class");
            Console.WriteLine("3. Add new staff");
            Console.WriteLine("4. List staff");
            Console.WriteLine("5. List grades set in the last month");
            Console.WriteLine("6. List grade statistics from all courses");
            Console.WriteLine("7. Add new student");
            Console.WriteLine("8. Exit");
            Console.WriteLine();

            // Loop with TryParse to prevent user crashing app
            int menuInput;
            bool parseSuccess;
            do
            {
                Console.Write("Enter a valid number: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out menuInput);
            } while (!parseSuccess || menuInput < 1 || menuInput > 8);

            switch (menuInput)
            {
                case 1:
                    ListAllStudentsMenu();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                default:

                    break;
            }
        }

        static void ListAllStudentsMenu()
        {
            Console.Clear();
            Console.WriteLine("List all students\n");
            Console.WriteLine("1. List on first name ascending");
            Console.WriteLine("2. List on first name descending");
            Console.WriteLine("3. List on last name ascending");
            Console.WriteLine("4. List on last name descending");
            Console.WriteLine("5. Exit to main menu");
            Console.WriteLine();

            // Loop with TryParse to prevent user crashing app
            int menuInput;
            bool parseSuccess;
            do
            {
                Console.Write("Enter a valid number: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out menuInput);
            } while (!parseSuccess || menuInput < 1 || menuInput > 5);

            FbgGymnDbContext client = new FbgGymnDbContext();

            // Some repetion of code below, should try to fix this
            switch (menuInput)
            {
                case 1:
                    var studentsFirstAsc = from student in client.Students
                                   orderby student.StudentFirstname ascending
                                   select student;

                    foreach (var student in studentsFirstAsc)
                    {
                        Console.WriteLine($"Name: {student.StudentFirstname} {student.StudentLastname}\nPersonal number: " +
                            $"{student.StudentPersonalnumber}\nPhone: {student.StudentCellphone}\n");
                    }
                    break;

                case 2:
                    var studentsFirstDesc = from student in client.Students
                                   orderby student.StudentFirstname descending
                                   select student;

                    foreach (var student in studentsFirstDesc)
                    {
                        Console.WriteLine($"Name: {student.StudentFirstname} {student.StudentLastname}\nPersonal number: " +
                            $"{student.StudentPersonalnumber}\nPhone: {student.StudentCellphone}\n");
                    }
                    break;

                case 3:
                    var studentsLastAsc = from student in client.Students
                                            orderby student.StudentLastname ascending
                                            select student;

                    foreach (var student in studentsLastAsc)
                    {
                        Console.WriteLine($"Name: {student.StudentFirstname} {student.StudentLastname}\nPersonal number: " +
                            $"{student.StudentPersonalnumber}\nPhone: {student.StudentCellphone}\n");
                    }
                    break;

                case 4:
                    var studentsLastDesc = from student in client.Students
                                          orderby student.StudentLastname descending
                                          select student;

                    foreach (var student in studentsLastDesc)
                    {
                        Console.WriteLine($"Name: {student.StudentFirstname} {student.StudentLastname}\nPersonal number: " +
                            $"{student.StudentPersonalnumber}\nPhone: {student.StudentCellphone}\n");
                    }
                    break;

                case 5:
                    Console.Write("Press a key to return to main menu.");
                    Console.ReadKey();
                    RunMainMenu();
                    break;
                default:
                    break;
            }

            Console.Write("All items listed. Press a key to return to main menu.");
            Console.ReadKey();
            RunMainMenu();
        }
    }
}