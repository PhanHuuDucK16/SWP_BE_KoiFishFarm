using System;
using System.Collections.Generic;

namespace KoiFishFarmShop.Models;

public partial class Manager
{
    public Guid Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}
