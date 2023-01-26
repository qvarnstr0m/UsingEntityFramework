// UsingEntityFramework, Martin Qvarnström SUT22
// Interacting with a database through Entity Framework
// Program.cs, where app runs and menu logic is handled

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
            Console.WriteLine("3. Add new student");
            Console.WriteLine("4. Exit");
            Console.WriteLine();

            // Loop with TryParse to prevent user crashing app
            int menuInput;
            bool parseSuccess;
            do
            {
                Console.Write("Enter a valid number: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out menuInput);
            } while (!parseSuccess || menuInput < 1 || menuInput > 4);

            switch (menuInput)
            {
                case 1:
                    ListLogic.ListAllStudentsMenu();
                    break;
                case 2:
                    ListLogic.ListStudentsInClass();
                    break;
                case 3:
                    AddLogic.AddStudent();
                    break;
                case 4:
                    Console.Write("Thank you for using this app, press a key to terminate.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}