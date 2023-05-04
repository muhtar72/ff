using BackendApi.Models;
using System;
using System.Collections.Generic;

namespace Online_shop_database.Models
{

    public partial class Filter
    {
        public int FilterId { get; set; }

        public string FilterName { get; set; } = null!;

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
