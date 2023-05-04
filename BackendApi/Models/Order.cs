using System;
using System.Collections.Generic;

namespace Online_shop_database.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public string? DeliveryMethod { get; set; }

    public string? OrderStatus { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
