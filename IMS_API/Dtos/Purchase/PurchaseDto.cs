namespace IMS_API.Dtos.Purchase
{
    public class PurchaseDto
    {
        public long PurchaseId { get; set; }

        public long? ProductId { get; set; }

        public long? QuantityPurchase { get; set; }

        public long? PurchaseAmount { get; set; }
    }
}
