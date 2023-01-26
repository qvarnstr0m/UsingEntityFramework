// UsingEntityFramework, Martin Qvarnström SUT22
// Interacting with a database through Entity Framework
// AddLogic.cs, where add data to DB type logic is handeled

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
        internal static void AddStaff()
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
            Console.WriteLine("\nAvailable staff roles:");

            // List and save all available staff roles in dictonary
            Dictionary<int, string> availableRoles = ListLogic.ListAllStaffRoles();

            // Loop with TryParse to prevent user crashing app
            bool parseRoleSuccess;
            int userRoleInput;
            do
            {
                Console.Write("Enter a valid staff role id: ");
                parseRoleSuccess = int.TryParse(Console.ReadLine(), out userRoleInput);
            } while (!parseRoleSuccess || !availableRoles.ContainsKey(userRoleInput));

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
                $"{phone}\nStaff role: {availableRoles[userRoleInput]}\nAdress:\n{availableAdresses[userAdressInput]}");

            string userInput;
            do
            {
                Console.Write($"\nSave this new staff member to database? (y/n)");
                userInput = Console.ReadLine().ToLower();
            } while (userInput != "y" && userInput != "n");

            if (userInput == "y")
            {
                Staff newStaff = new Staff(fName, lName, pNumber, email, phone, userRoleInput, userAdressInput);
                FbgGymnDbContext context = new FbgGymnDbContext();
                context.Staff.Add(newStaff);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to save data, press a key to return to main menu.\nException message:\n{e.Message}");
                    Console.ReadKey();
                    Program.RunMainMenu();
                }
                
                Console.WriteLine("Staff member added, press a key to return to main menu.");
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
