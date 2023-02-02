using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class VwLastMonthGrade
{
    public string Namn { get; set; }

    public string Betyg { get; set; }

    public string Kurs { get; set; }

    public string Betygsättare { get; set; }
}
