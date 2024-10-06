using System;
using System.Collections.Generic;

namespace KoiFishFarmShop.Models;

public partial class KoiFish
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Origin { get; set; }

    public int? Size { get; set; }

    public string? ThumbnailUrl { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? Price { get; set; }

    public int? PromotionPrice { get; set; }

    public string? Status { get; set; }

    public Guid? CreatorId { get; set; }

    public virtual ICollection<KoiFishCategory> KoiFishCategories { get; set; } = new List<KoiFishCategory>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
