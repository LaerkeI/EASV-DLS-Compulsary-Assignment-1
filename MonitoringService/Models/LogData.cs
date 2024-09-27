namespace MonitoringService.Models
{
    public class LogData
    {
        public string ServiceName { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
