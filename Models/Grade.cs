using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string GradeGrade { get; set; }

    public DateTime GradeDate { get; set; }

    public int FkStudentId { get; set; }

    public int FkStaffId { get; set; }

    public int FkCourseId { get; set; }

    public virtual Course FkCourse { get; set; }

    public virtual Staff FkStaff { get; set; }

    public virtual Student FkStudent { get; set; }
}
