using System;
using System.Collections.Generic;

namespace System_Manage.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Size { get; set; }

    public string? Weight { get; set; }

    public string? Color { get; set; }
}
