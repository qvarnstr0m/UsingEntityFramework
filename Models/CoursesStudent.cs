using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class CoursesStudent
{
    public int CoursesStudentsId { get; set; }

    public int FkCourseId { get; set; }

    public int FkStudentId { get; set; }

    public virtual Course FkCourse { get; set; } = null!;

    public virtual Student FkStudent { get; set; } = null!;
}
