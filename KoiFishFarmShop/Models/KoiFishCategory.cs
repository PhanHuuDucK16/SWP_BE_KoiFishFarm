using System;
using System.Collections.Generic;

namespace KoiFishFarmShop.Models;

public partial class KoiFishCategory
{
    public Guid Id { get; set; }

    public Guid? CategoryId { get; set; }

    public Guid? KoiFishId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual KoiFish? KoiFish { get; set; }
}
