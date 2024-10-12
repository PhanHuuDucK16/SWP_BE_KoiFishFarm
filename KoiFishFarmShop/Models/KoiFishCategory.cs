using System;
using System.Collections.Generic;

namespace KoiFishFarmShop.Models;

public partial class KoiFishCategory
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public int? KoiFishId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual KoiFish? KoiFish { get; set; }
}
