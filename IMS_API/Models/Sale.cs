using System;
using System.Collections.Generic;

namespace IMS_API.Models;

public partial class Sale
{
    public long SaleId { get; set; }

    public long? ProductId { get; set; }

    public long? QuantitySold { get; set; }

    public long? TotalPrice { get; set; }

    public virtual Product? Product { get; set; }
}
