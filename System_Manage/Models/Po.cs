using System;
using System.Collections.Generic;

namespace System_Manage.Models;

public partial class Po
{
    public string Id { get; set; } = null!;

    public int? CusId { get; set; }

    public int? StaffId { get; set; }

    public int? ProId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? CreateDay { get; set; }

    public DateTime? DayEtd { get; set; }
}
