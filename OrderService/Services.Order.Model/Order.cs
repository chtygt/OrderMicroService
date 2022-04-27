namespace Services.Order.Model
{
    public class Order : EntityBase
    {
        public int OrderNumber { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCompleted { get; set; }

        public virtual IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
