﻿using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string StaffFirstname { get; set; } = null!;

    public string StaffLastname { get; set; } = null!;

    public string StaffPersonalnumber { get; set; } = null!;

    public string? StaffEmail { get; set; }

    public string? StaffCellphone { get; set; }

    public int FkStaffroleId { get; set; }

    public int FkAdressId { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public virtual Adress FkAdress { get; set; } = null!;

    public virtual Staffrole FkStaffrole { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();
}