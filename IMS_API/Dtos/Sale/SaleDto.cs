namespace IMS_API.Dtos.Sale
{
    public class SaleDto
    {
        public long SaleId { get; set; }

        public long? ProductId { get; set; }

        public long? QuantitySold { get; set; }

        public long? TotalPrice { get; set; }
    }
}
