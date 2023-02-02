using System;
using System.Collections.Generic;

namespace UsingEntityFramework.Models;

public partial class VwStaffDatum
{
    public string Namn { get; set; }

    public string Roll { get; set; }

    public int? ÅrPåSkolan { get; set; }
}
