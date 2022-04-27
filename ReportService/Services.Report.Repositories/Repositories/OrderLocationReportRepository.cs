using Services.Report.Data;
using Services.Report.Model;
using Services.Report.Repositories.Interfaces;
using Services.Shared.Data.Repository;

namespace Services.Report.Repositories.Repositories
{
    public class OrderLocationReportRepository : Repository<OrderStatusReport>, IOrderLocationReportRepository
    {
        public OrderLocationReportRepository(ReportDbContext context) : base(context)
        {

        }

        public bool CreateLocationReport(int userId, DateTime requestDateTime)
        {
            return true;
        }
    }
}
