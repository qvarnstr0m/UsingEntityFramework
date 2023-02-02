using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class VwStaffRoleMonthlySalary
{
    public string Avdelning { get; set; }

    public decimal? GenomsnittligLön { get; set; }
}
