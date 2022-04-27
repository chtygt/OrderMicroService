using MassTransit;
using Services.Report.Services;
using Services.Shared.EventBus;

namespace Services.Report.EventBus.Consumers
{
    public class ReportRequestEventConsumer : IConsumer<ReportRequestEvent>
    {
        private readonly ReportService _reportService;

        public ReportRequestEventConsumer(ReportService reportService)
        {
            _reportService = reportService;
        }

        public Task Consume(ConsumeContext<ReportRequestEvent> context)
        {
            _reportService.CreateLocationReport(context.Message.ReportId);
            return Task.CompletedTask;
        }
    }
}
