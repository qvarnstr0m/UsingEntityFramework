using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Data;

namespace UsingEntityFramework.Controllers
{
    internal class DepartmentController
    {
        internal static void ListNoDepartmentStaff()
        {
            Console.Clear();
            Console.WriteLine("Departments with total teachers:\n");
            using (UnitOfWork unitOfWork = new UnitOfWork(new FbgGymnDbContext()))
            {
                var departments = unitOfWork.Departments.GetNoDepartmentStaff();

                foreach (var department in departments)
                {
                    Console.WriteLine($"Department: {department.Department}\nTotal employees: {department.TotalEmployees}\n");
                }

                Console.WriteLine("All departments listed, press a key to return to main menu.");
            }
            Console.ReadKey();
            MainController.RunMainMenu();
        }
    }
}
