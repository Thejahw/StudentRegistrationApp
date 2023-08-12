using System;
using System.Collections.Generic;

namespace SoftOne.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ContactNo { get; set; } = null!;

    public string? Email { get; set; }

    public int Ssn { get; set; }

    public DateTime Dob { get; set; }

    public string Title { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public string? ContactPersonName { get; set; }

    public string? ContactPersonNumber { get; set; }

    public string PrimaryAdressLine { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<RoleXStudent> RoleXStudents { get; set; } = new List<RoleXStudent>();
}
