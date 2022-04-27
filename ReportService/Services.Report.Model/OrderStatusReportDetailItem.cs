
namespace Services.Report.Model;

    public class OrderStatusReportDetailItem
{
    public Guid Id { get; set; }

    public Guid OrderDetailItemId { get; set; }
    public OrderProduct Product { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }

    public virtual OrderStatusReportDetail OrderStatusReportDetail { get; set; }

}
