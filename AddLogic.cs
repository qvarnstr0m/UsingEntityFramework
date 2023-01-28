// UsingEntityFramework, Martin Qvarnström SUT22
// Interacting with a database through Entity Framework
// AddLogic.cs, where add data to DB type logic is handled

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Models;

namespace UsingEntityFramework
{
    internal class AddLogic
    {
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
            Dictionary<int, string> availableClasses = ListLogic.ListClasses();

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
            Dictionary<int, string> availableAdresses = ListLogic.ListAdresses();

            bool parseAdressSuccess;
            int userAdressInput;
            do
            {
                Console.Write("Enter a valid adress id: ");
                parseAdressSuccess = int.TryParse(Console.ReadLine(), out userAdressInput);
            } while (!parseAdressSuccess || !availableAdresses.ContainsKey(userAdressInput));

            Console.WriteLine($"\nName: {fName} {lName}\nPersonal number: {pNumber}\nEmail: {email}\nPhone: " +
                $"{phone}\nStaff role: {availableClasses[userClassInput]}\nAdress:\n{availableAdresses[userAdressInput]}");

            string userInput;
            do
            {
                Console.Write($"\nSave this new student to database? (y/n)");
                userInput = Console.ReadLine().ToLower();
            } while (userInput != "y" && userInput != "n");

            if (userInput == "y")
            {
                Student newStudent = new Student(fName, lName, pNumber, email, phone, userClassInput, userAdressInput);
                using (FbgGymnDbContext context = new FbgGymnDbContext())
                {
                    context.Students.Add(newStudent);
                    context.SaveChanges();
                }

                Console.WriteLine("Student added, press a key to return to main menu.");
                Console.ReadKey();
                Program.RunMainMenu();
            }
            else
            {
                Console.WriteLine("Data will not be saved, press a key to return to main menu.");
                Console.ReadKey();
                Program.RunMainMenu();
            }
        }
    }
}
