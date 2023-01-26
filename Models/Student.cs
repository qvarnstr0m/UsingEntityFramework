using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UsingEntityFramework.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentFirstname { get; set; }

    public string? StudentLastname { get; set; }

    public string? StudentPersonalnumber { get; set; }

    public string? StudentEmail { get; set; }

    public string? StudentCellphone { get; set; }

    public int FkClassId { get; set; }

    public int FkAdressId { get; set; }

    public virtual ICollection<CoursesStudent> CoursesStudents { get; } = new List<CoursesStudent>();

    public virtual Adress FkAdress { get; set; } = null!;

    public virtual Class FkClass { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public Student()
    {

    }

    public Student(string firstName, string lastName, string pNumber, string email, string phone, int classId, int adressId)
    {
        StudentFirstname = firstName;
        StudentLastname = lastName;
        StudentPersonalnumber = pNumber;
        StudentEmail = email;
        StudentCellphone = phone;
        FkClassId = classId;
        FkAdressId = adressId;
    }
}
