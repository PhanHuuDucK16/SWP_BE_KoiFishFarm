using System;
using System.Collections.Generic;

namespace KoiFishFarmShop.Models;

public partial class DeliveryCompany
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
