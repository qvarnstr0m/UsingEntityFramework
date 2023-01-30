using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Data;
using UsingEntityFramework.Models;

namespace UsingEntityFramework.Repositories
{
    internal class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(FbgGymnDbContext context)
            : base(context)
        {
            
        }

        public FbgGymnDbContext FbgGymnDbContext
        {
            get { return Context as FbgGymnDbContext; }
        }

        public IEnumerable<dynamic> GetAllStudentsSorted(bool sortByFirstName, bool sortAscending)
        {
            var studentList = FbgGymnDbContext.Students.Join(FbgGymnDbContext.Adresses, x => x.FkAdressId, y => y.AdressId, (students, adresses) => new
            {
                FirstName = students.StudentFirstname,
                LastName = students.StudentLastname,
                Name = $"{students.StudentFirstname} {students.StudentLastname}",
                Adress = $"{adresses.AdressStreet}\n{adresses.AdressPostalcode} {adresses.AdressCity}",
                Phone = students.StudentCellphone,
                Email = students.StudentEmail
            })
                .OrderBy(x => sortByFirstName ? x.FirstName : x.LastName)
                .ToList();

            if (!sortAscending)
            {
                studentList.Reverse();
            }

            return studentList;
        }

        public IEnumerable<dynamic> ListStudentsInClass(int classId)
        {
            var studentList = FbgGymnDbContext.Students.Where(x => x.FkClassId == classId).Join(FbgGymnDbContext.Classes, x => x.FkClassId, y => y.ClassId, (students, classes) => new
            {
                Name = $"{students.StudentFirstname} {students.StudentLastname}",
                Class = $"{classes.ClassName}"
            })
                .ToList();

            return studentList;
        }
    }
}
