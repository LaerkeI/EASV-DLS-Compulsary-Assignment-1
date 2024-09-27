using MonitoringService.Models;
using MonitoringService.Repository;

namespace MonitoringService.Services
{
       public class MonitorService : IMonitoringService
    {
        private readonly IDatabaseRepository _repository;

        public MonitorService(IDatabaseRepository repository)
        {
            _repository = repository;
        }

        public async Task ProcessMetrics(MetricsData metrics)
        {
            // Process and normalize metrics data.
            await _repository.SaveMetricsAsync(metrics);
        }

        public async Task ProcessLogs(LogData log)
        {
            // Process and normalize log data.
            await _repository.SaveLogsAsync(log);
        }

        public async Task ProcessTraces(TraceData trace)
        {
            // Process and normalize trace data.
            await _repository.SaveTracesAsync(trace);
        }
    }

}
