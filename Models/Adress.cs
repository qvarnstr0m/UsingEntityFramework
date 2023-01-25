using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class Adress
{
    public int AdressId { get; set; }

    public string? AdressStreet { get; set; }

    public int? AdressPostalcode { get; set; }

    public string? AdressCity { get; set; }

    public virtual ICollection<Staff> Staff { get; } = new List<Staff>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
