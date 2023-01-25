using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public DateTime? ClassStartdate { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
