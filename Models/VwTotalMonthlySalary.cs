using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class VwTotalMonthlySalary
{
    public string Avdelning { get; set; }

    public decimal? TotalaLöneutbetalningar { get; set; }
}
