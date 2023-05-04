using Online_shop_database.Models;
using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Filter> Filters { get; } = new List<Filter>();
}
