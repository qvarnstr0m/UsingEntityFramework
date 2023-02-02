using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; }

    public virtual ICollection<StaffDepartment> StaffDepartments { get; } = new List<StaffDepartment>();
}
