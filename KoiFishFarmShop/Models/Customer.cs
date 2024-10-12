using System;
using System.Collections.Generic;

namespace KoiFishFarmShop.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public int? Point { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
