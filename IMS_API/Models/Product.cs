using System;
using System.Collections.Generic;

namespace IMS_API.Models;

public partial class Product
{
    public long ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public long? Quantity { get; set; }

    public long? Price { get; set; }

    public string? Image { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
