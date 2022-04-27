namespace Services.Report.Model
{
    public class OrderStatusReport
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime RequestDate { get; set; }         
        public ReportStatus ReportStatus { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool OrderStatus { get; set; }
        public virtual List<OrderStatusReportDetail> OrderStatusReportDetails { get; set; }
    }
}
