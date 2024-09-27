using MonitoringService.Models;

namespace MonitoringService.Repository
{
    public interface IDatabaseRepository
    {
        Task SaveLogsAsync(LogData log);
        Task SaveMetricsAsync(MetricsData metrics);
        Task SaveTracesAsync(TraceData trace);
    }
}
