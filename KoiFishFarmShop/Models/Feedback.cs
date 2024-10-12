using System;
using System.Collections.Generic;

namespace KoiFishFarmShop.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? CustomerId { get; set; }

    public string? Message { get; set; }

    public int? Star { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Order? Order { get; set; }
}
