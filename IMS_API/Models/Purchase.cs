using System;
using System.Collections.Generic;

namespace IMS_API.Models;

public partial class Purchase
{
    public long PurchaseId { get; set; }

    public long? ProductId { get; set; }

    public long? QuantityPurchase { get; set; }

    public long? PurchaseAmount { get; set; }

    public virtual Product? Product { get; set; }
}
