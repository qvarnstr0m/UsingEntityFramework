using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string StaffFirstname { get; set; }

    public string StaffLastname { get; set; }

    public string StaffPersonalnumber { get; set; }

    public string StaffEmail { get; set; }

    public string StaffCellphone { get; set; }

    public int FkStaffroleId { get; set; }

    public int FkAdressId { get; set; }

    public DateTime StaffStartdate { get; set; }

    public DateTime? StaffEnddate { get; set; }

    public decimal? StaffMonthlySalary { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public virtual Adress FkAdress { get; set; }

    public virtual Staffrole FkStaffrole { get; set; }

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual ICollection<StaffDepartment> StaffDepartments { get; } = new List<StaffDepartment>();
}
