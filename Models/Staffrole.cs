using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class Staffrole
{
    public int StaffroleId { get; set; }

    public string? StaffroleName { get; set; }

    public virtual ICollection<Staff> Staff { get; } = new List<Staff>();
}
