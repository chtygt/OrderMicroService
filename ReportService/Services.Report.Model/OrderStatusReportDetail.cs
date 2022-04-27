namespace Services.Report.Model;

public class OrderStatusReportDetail
{
    public Guid Id { get; set; }
    public Guid OrderStatusReportId { get; set; }
    public int OrderNumber { get; set; }
    public OrderCustomer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsCompleted { get; set; }

    public virtual OrderStatusReport OrderStatusReport { get; set; }
    public virtual List<OrderStatusReportDetailItem> OrderStatusReportDetailItems { get; set; }
}