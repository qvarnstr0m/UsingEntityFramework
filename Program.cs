// UsingEntityFramework, Martin Qvarnström SUT22
// Interacting with a database through Entity Framework
// Program.cs, where app runs and menu logic is handeled

using UsingEntityFramework.Models;

namespace UsingEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunMainMenu();
        }

        internal static void RunMainMenu()
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
                    ListLogic.ListAllStudentsMenu();
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
    }
}