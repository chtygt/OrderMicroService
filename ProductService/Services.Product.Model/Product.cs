namespace Services.Product.Model
{
    public class Product : EntityBase
    {
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        
    }
}
