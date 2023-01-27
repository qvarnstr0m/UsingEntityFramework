// UsingEntityFramework, Martin Qvarnström SUT22
// Interacting with a database through Entity Framework
// ListLogic.cs, where list data from DB type logic is handled

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Models;
using UsingEntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UsingEntityFramework
{
    internal class ListLogic
    {
        internal static void ListAllStudentsMenu()
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

            

            // Some repetition of code below, could maybe avoided by using sql views or stored procedures
            switch (menuInput)
            {
                case 1:
                    using (FbgGymnDbContext context = new FbgGymnDbContext())
                    {
                        var studentsFirstAsc = from student in context.Students
                                               join adress in context.Adresses
                                               on student.FkAdressId equals adress.AdressId
                                               join studentClass in context.Classes
                                               on student.FkClassId equals studentClass.ClassId
                                               orderby student.StudentFirstname ascending
                                               select new
                                               {
                                                   fullName = $"{student.StudentFirstname} {student.StudentLastname}",
                                                   adress = $"{adress.AdressStreet}\n{adress.AdressPostalcode} {adress.AdressCity}",
                                                   personalNumber = student.StudentPersonalnumber,
                                                   phone = student.StudentCellphone,
                                                   email = student.StudentEmail,
                                                   studentClass = studentClass.ClassName
                                               };

                        ListAllStudents(studentsFirstAsc);
                    };
                    break;

                case 2:
                    using (FbgGymnDbContext context = new FbgGymnDbContext())
                    {
                        var studentsFirstDesc = from student in context.Students
                                                join adress in context.Adresses
                                                on student.FkAdressId equals adress.AdressId
                                                join studentClass in context.Classes
                                                on student.FkClassId equals studentClass.ClassId
                                                orderby student.StudentFirstname descending
                                                select new
                                                {
                                                    fullName = $"{student.StudentFirstname} {student.StudentLastname}",
                                                    adress = $"{adress.AdressStreet}\n{adress.AdressPostalcode} {adress.AdressCity}",
                                                    personalNumber = student.StudentPersonalnumber,
                                                    phone = student.StudentCellphone,
                                                    email = student.StudentEmail,
                                                    studentClass = studentClass.ClassName
                                                };

                        ListAllStudents(studentsFirstDesc);
                    };
                    break;

                case 3:
                    using (FbgGymnDbContext context = new FbgGymnDbContext())
                    {
                        var studentsLastAsc = from student in context.Students
                                              join adress in context.Adresses
                                              on student.FkAdressId equals adress.AdressId
                                              join studentClass in context.Classes
                                              on student.FkClassId equals studentClass.ClassId
                                              orderby student.StudentLastname ascending
                                              select new
                                              {
                                                  fullName = $"{student.StudentFirstname} {student.StudentLastname}",
                                                  adress = $"{adress.AdressStreet}\n{adress.AdressPostalcode} {adress.AdressCity}",
                                                  personalNumber = student.StudentPersonalnumber,
                                                  phone = student.StudentCellphone,
                                                  email = student.StudentEmail,
                                                  studentClass = studentClass.ClassName
                                              };

                        ListAllStudents(studentsLastAsc);
                    };
                    break;

                case 4:
                    using (FbgGymnDbContext context = new FbgGymnDbContext())
                    {
                        var studentsLastDesc = from student in context.Students
                                               join adress in context.Adresses
                                               on student.FkAdressId equals adress.AdressId
                                               join studentClass in context.Classes
                                               on student.FkClassId equals studentClass.ClassId
                                               orderby student.StudentLastname descending
                                               select new
                                               {
                                                   fullName = $"{student.StudentFirstname} {student.StudentLastname}",
                                                   adress = $"{adress.AdressStreet}\n{adress.AdressPostalcode} {adress.AdressCity}",
                                                   personalNumber = student.StudentPersonalnumber,
                                                   phone = student.StudentCellphone,
                                                   email = student.StudentEmail,
                                                   studentClass = studentClass.ClassName
                                               };

                        ListAllStudents(studentsLastDesc);
                    };
                    break;

                case 5:
                    Console.Write("Press a key to return to main menu.");
                    Console.ReadKey();
                    Program.RunMainMenu();
                    break;
                default:
                    break;
            }

            Console.Write("All students listed. Press a key to return to main menu.");
            Console.ReadKey();
            Program.RunMainMenu();
        }

        internal static void ListAllStudents(IQueryable<dynamic> studentList)
        {
            foreach (dynamic item in studentList)
            {
                Console.WriteLine($"Name: {item.fullName}\nAdress:\n{item.adress}\nClass: {item.studentClass}\nPersonal number: {item.personalNumber}\nCellphone: {item.phone}\nEmail: {item.email}\n");
            }
        }

        internal static void ListStudentsInClass()
        {
            // List all available classes and store list of available class id's
            List<int> availableClassIds = ListAllClasses();

            bool parseSuccess;
            int userInput;
            Console.WriteLine();
            do
            {
                Console.Write("Enter a valid class id: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out userInput);
            } while (!parseSuccess || !availableClassIds.Contains(userInput));

            using (FbgGymnDbContext context = new FbgGymnDbContext())
            {
                var studentList = from students in context.Students
                                  join classes in context.Classes
                                  on students.FkClassId equals classes.ClassId
                                  where classes.ClassId == userInput
                                  select students;

                Console.WriteLine();

                foreach (var student in studentList)
                {
                    Console.WriteLine($"Name: {student.StudentFirstname} {student.StudentLastname}");
                }

                Console.Write(studentList.Count() > 0 ? "\nAll students listed. Press a key to return to main menu." : "\nNo students in this class. Press a key to return to main menu.");
            };

            Console.ReadKey();
            Program.RunMainMenu();
        }

        internal static List<int> ListAllClasses()
        {
            Console.Clear();
            Console.WriteLine("Available classes:\n");
            //List to hold available class id's
            List<int> classIdList = new List<int>();

            using (FbgGymnDbContext context = new FbgGymnDbContext())
            {
                var availableClasses = from classes in context.Classes
                                       orderby classes.ClassId ascending
                                       select classes;

                foreach (var currentClass in availableClasses)
                {
                    classIdList.Add(currentClass.ClassId);
                    Console.WriteLine($"Class id: {currentClass.ClassId} Class name: {currentClass.ClassName}");
                }
            };

            return classIdList;
        }

        internal static Dictionary<int, string> ListClasses()
        {
            //Dictionary to hold available classes
            Dictionary<int, string> classDict = new Dictionary<int, string>();

            using (FbgGymnDbContext context = new FbgGymnDbContext())
            {
                var availableClasses = from classes in context.Classes
                                       orderby classes.ClassId ascending
                                       select classes;

                foreach (var currentClass in availableClasses)
                {
                    classDict.Add(currentClass.ClassId, currentClass.ClassName);
                    Console.WriteLine($"Id: {currentClass.ClassId} Class: {currentClass.ClassName}\n");
                }
            };

            return classDict;
        }

        internal static Dictionary<int, string> ListAdresses()
        {
            // Dictionary to hold available adresses
            Dictionary<int, string> adressDict = new Dictionary<int, string>();

            using (FbgGymnDbContext context = new FbgGymnDbContext())
            {
                var availableAdresses = from adresses in context.Adresses
                                        orderby adresses.AdressId ascending
                                        select adresses;

                foreach (var adress in availableAdresses)
                {
                    adressDict.Add(adress.AdressId, $"{adress.AdressStreet}\n{adress.AdressPostalcode} {adress.AdressCity}");
                    Console.WriteLine($"Adress id: {adress.AdressId}\n{adress.AdressStreet}\n{adress.AdressPostalcode} {adress.AdressCity}\n");
                }
            };

            return adressDict;
        }
    }
}
