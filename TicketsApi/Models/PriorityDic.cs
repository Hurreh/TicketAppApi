using System;
using System.Collections.Generic;

namespace TicketsApi.Models;

public partial class PriorityDic
{
    public int Id { get; set; }

    public string PriorityName { get; set; }

    public int? Severity { get; set; }
}
