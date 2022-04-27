using MassTransit;
using Services.Shared.EventBus;

namespace Services.Report.Services.Events
{
    public class ReportEvents
    {
        private readonly IPublishEndpoint _publishEndPoint;
        public ReportEvents(IPublishEndpoint publishEndPoint)
        {
            _publishEndPoint = publishEndPoint;
        }

        public void SendReportRequest(ReportRequestEvent @event)
        {
            _publishEndPoint.Publish(@event);
        }
    }
}
