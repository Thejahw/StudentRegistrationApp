using System;
using System.Collections.Generic;

namespace SoftOne.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<RoleXStudent> RoleXStudents { get; set; } = new List<RoleXStudent>();
}
