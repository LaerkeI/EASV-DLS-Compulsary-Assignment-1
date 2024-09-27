namespace MonitoringService.Models
{
    public class MetricsData
    {
        public string ServiceName { get; set; }
        public string MetricName { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
