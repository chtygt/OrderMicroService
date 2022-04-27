
namespace Services.Report.Services.RequestModel
{
    public class ReportRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool OrderStatus { get; set; }
    }
}
