using System;
using System.Collections.Generic;

namespace SoftOne.Models;

public partial class RoleXStudent
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int StudentId { get; set; }

    public string Address1 { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string? City { get; set; }

    public string? Country { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
