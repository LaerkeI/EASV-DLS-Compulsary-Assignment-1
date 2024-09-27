using Microsoft.Data.SqlClient;
using MonitoringService.Models;

namespace MonitoringService.Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string _connectionString;

        // Public constructor
        public DatabaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task SaveMetricsAsync(MetricsData metrics)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Metrics (ServiceName, MetricName, Value, Timestamp) VALUES (@ServiceName, @MetricName, @Value, @Timestamp)", conn))
                {
                    cmd.Parameters.AddWithValue("@ServiceName", metrics.ServiceName);
                    cmd.Parameters.AddWithValue("@MetricName", metrics.MetricName);
                    cmd.Parameters.AddWithValue("@Value", metrics.Value);
                    cmd.Parameters.AddWithValue("@Timestamp", metrics.Timestamp);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task SaveLogsAsync(LogData log)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Logs (ServiceName, LogLevel, Message, Timestamp) VALUES (@ServiceName, @LogLevel, @Message, @Timestamp)", conn))
                {
                    cmd.Parameters.AddWithValue("@ServiceName", log.ServiceName);
                    cmd.Parameters.AddWithValue("@LogLevel", log.LogLevel);
                    cmd.Parameters.AddWithValue("@Message", log.Message);
                    cmd.Parameters.AddWithValue("@Timestamp", log.Timestamp);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task SaveTracesAsync(TraceData trace)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Traces (TraceId, SpanId, ServiceName, OperationName, StartTime, Duration) VALUES (@TraceId, @SpanId, @ServiceName, @OperationName, @StartTime, @Duration)", conn))
                {
                    cmd.Parameters.AddWithValue("@TraceId", trace.TraceId);
                    cmd.Parameters.AddWithValue("@SpanId", trace.SpanId);
                    cmd.Parameters.AddWithValue("@ServiceName", trace.ServiceName);
                    cmd.Parameters.AddWithValue("@OperationName", trace.OperationName);
                    cmd.Parameters.AddWithValue("@StartTime", trace.StartTime);
                    cmd.Parameters.AddWithValue("@Duration", trace.Duration);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
