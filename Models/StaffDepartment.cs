using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class StaffDepartment
{
    public int StaffDepartmentsId { get; set; }

    public int? FkStaffId { get; set; }

    public int? FkDepartmentId { get; set; }

    public virtual Department FkDepartment { get; set; }

    public virtual Staff FkStaff { get; set; }
}
