using System;
using System.Collections.Generic;

namespace TicketsApi.Models;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public string UserRole { get; set; }
}
