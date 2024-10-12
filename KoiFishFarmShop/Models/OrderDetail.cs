using System;
using System.Collections.Generic;

namespace KoiFishFarmShop.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? KoiFishId { get; set; }

    public int? KoiFishGroupId { get; set; }

    public int? Quantity { get; set; }

    public int? Price { get; set; }

    public string? Plates { get; set; }

    public string? DriverNumber { get; set; }

    public int? DeliveryCost { get; set; }

    public virtual KoiFish? KoiFish { get; set; }

    public virtual KoiFishGroup? KoiFishGroup { get; set; }

    public virtual Order? Order { get; set; }
}
