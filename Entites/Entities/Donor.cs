using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Donor
{
    public Guid id { get; set; }

    public string name { get; set; } = null!;

    public int age { get; set; }

    public long phnumber { get; set; }

    public string city { get; set; } = null!;

    public string bloodGroup { get; set; } = null!;

    public string email { get; set; } = null!;

    public string profession { get; set; } = null!;

    public int weight { get; set; }

    public int height { get; set; }
}
