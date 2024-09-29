namespace IMS_API.Dtos.Product
{
    public class ProductDto
    {
        public long? ProductId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public long? Quantity { get; set; }

        public long? Price { get; set; }
        public string? Image { get; set; }
    }
}
