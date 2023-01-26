// UsingEntityFramework, Martin Qvarnström SUT22
// Interacting with a database through Entity Framework
// ListLogic.cs, where list data from DB type logic is handeled

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

            FbgGymnDbContext context = new FbgGymnDbContext();

            // Some repetion of code below, should try to fix this
            switch (menuInput)
            {
                case 1:
                    var studentsFirstAsc = from student in context.Students
                                           orderby student.StudentFirstname ascending
                                           select student;

                    ListAllStudents(studentsFirstAsc);
                    break;

                case 2:
                    var studentsFirstDesc = from student in context.Students
                                            orderby student.StudentFirstname descending
                                            select student;

                    ListAllStudents(studentsFirstDesc);
                    break;

                case 3:
                    var studentsLastAsc = from student in context.Students
                                          orderby student.StudentLastname ascending
                                          select student;

                    ListAllStudents(studentsLastAsc);
                    break;

                case 4:
                    var studentsLastDesc = from student in context.Students
                                           orderby student.StudentLastname descending
                                           select student;

                    ListAllStudents(studentsLastDesc);
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

        internal static void ListAllStudents(IOrderedQueryable<Student> studentList)
        {
            foreach (var student in studentList)
            {
                Console.WriteLine($"Name: {student.StudentFirstname} {student.StudentLastname}\nPersonal number: " +
                    $"{student.StudentPersonalnumber}\nPhone: {student.StudentCellphone}\n");
            }
        }

        internal static void ListStudentsIsClass()
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

            FbgGymnDbContext context = new FbgGymnDbContext();

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
            Console.ReadKey();
            Program.RunMainMenu();
        }

        internal static List<int> ListAllClasses()
        {
            Console.Clear();
            Console.WriteLine("Available classes:\n");
            //List to hold available class id's
            List<int> classIdList = new List<int>();

            FbgGymnDbContext context = new FbgGymnDbContext();

            var availableClasses = from classes in context.Classes
                                   orderby classes.ClassId ascending
                                   select classes;

            foreach (var currentClass in availableClasses)
            {
                classIdList.Add(currentClass.ClassId);
                Console.WriteLine($"Class id: {currentClass.ClassId} Class name: {currentClass.ClassName}");
            }

            return classIdList;
        }
    }
}
