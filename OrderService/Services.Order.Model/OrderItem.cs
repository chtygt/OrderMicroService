namespace Services.Order.Model;

public class OrderItem : EntityBase
{
    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }

    public virtual Order Order { get; set; }
}