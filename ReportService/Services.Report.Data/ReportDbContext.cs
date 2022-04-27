using Microsoft.EntityFrameworkCore;
using Services.Report.Model;

namespace Services.Report.Data
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options)
            : base(options)
        {

        }
         
        public DbSet<OrderStatusReport> ContactReports{ get; set; }
        public DbSet<OrderStatusReportDetail> ContactReportDetails{ get; set; }
    }
}
