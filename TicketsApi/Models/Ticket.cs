using System;
using System.Collections.Generic;

namespace TicketsApi.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string SerialNumber { get; set; }

    public int? Requestor { get; set; }

    public int? Asignee { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedBy { get; set; }

    public int? Category { get; set; }

    public int? State { get; set; }

    public int? Impact { get; set; }

    public int? Priority { get; set; }

    public string ShortDesc { get; set; }

    public string LongDesc { get; set; }

    public string Notes { get; set; }
}
