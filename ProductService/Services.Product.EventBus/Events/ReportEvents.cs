using MassTransit;
using Services.Shared.EventBus;

namespace Services.Contact.EventBus.Events
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
