using System;
using System.Collections.Generic;

namespace Online_shop_database.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public string ItemCategory { get; set; } = null!;

    public string? ItemDescription { get; set; }

    public double ItemPrice { get; set; }

    public int ItemQuantity { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
