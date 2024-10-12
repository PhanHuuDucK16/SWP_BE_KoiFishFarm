using System;
using System.Collections.Generic;

namespace KoiFishFarmShop.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<KoiFishCategory> KoiFishCategories { get; set; } = new List<KoiFishCategory>();
}
