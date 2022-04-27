namespace Services.Shared.EventBus
{
    public class ReportRequestEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public Guid ReportId { get; set; }
    }
}