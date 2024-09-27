using MonitoringService.Models;

namespace MonitoringService.Services
{
    public interface IMonitoringService
    {
        Task ProcessMetrics(MetricsData metrics);
        Task ProcessLogs(LogData log);
        Task ProcessTraces(TraceData trace);
    }

}
