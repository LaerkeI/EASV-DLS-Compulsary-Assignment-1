namespace MonitoringService.Models
{
    public class TraceData
    {
        public string TraceId { get; set; }
        public string SpanId { get; set; }
        public string ServiceName { get; set; }
        public string OperationName { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
