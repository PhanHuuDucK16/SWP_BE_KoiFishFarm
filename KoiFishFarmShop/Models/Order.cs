using System;
using System.Collections.Generic;

namespace KoiFishFarmShop.Models;

public partial class Order
{
    public Guid Id { get; set; }

    public Guid? CustomerId { get; set; }

    public int? Amount { get; set; }

    public string? Receiver { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? PaymentMethod { get; set; }

    public bool? IsPayment { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateAt { get; set; }

    public Guid? DeliveryCompanyId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual DeliveryCompany? DeliveryCompany { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
