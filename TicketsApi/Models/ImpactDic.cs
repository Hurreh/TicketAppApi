using System;
using System.Collections.Generic;

namespace TicketsApi.Models;

public partial class ImpactDic
{
    public int Id { get; set; }

    public string ImpactName { get; set; }

    public int? Severity { get; set; }
}
