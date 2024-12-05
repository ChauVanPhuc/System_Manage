using System;
using System.Collections.Generic;

namespace System_Manage.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? Gender { get; set; }

    public string? Cccd { get; set; }

    public int? RoleId { get; set; }
}
