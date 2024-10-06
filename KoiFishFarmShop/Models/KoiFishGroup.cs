using System;
using System.Collections.Generic;

namespace KoiFishFarmShop.Models;

public partial class KoiFishGroup
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Size { get; set; }

    public int? Price { get; set; }

    public int? PromotionPrice { get; set; }

    public string? Status { get; set; }

    public Guid? CreatorId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
