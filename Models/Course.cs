using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public DateTime CourseStartdate { get; set; }

    public DateTime CourseEnddate { get; set; }

    public int FkStaffId { get; set; }

    public virtual ICollection<CoursesStudent> CoursesStudents { get; } = new List<CoursesStudent>();

    public virtual Staff FkStaff { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();
}
