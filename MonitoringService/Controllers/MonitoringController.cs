using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using MonitoringService.Models;
using MonitoringService.Services;

namespace MonitoringService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitoringController : ControllerBase
    {
        private readonly IMonitoringService _monitoringService;

        public MonitoringController(IMonitoringService monitoringService)
        {
            _monitoringService = monitoringService;
        }

        // POST: api/monitoring/metrics
        [HttpPost("metrics")]
        public async Task<IActionResult> PostMetrics([FromBody] MetricsData metrics)
        {
            await _monitoringService.ProcessMetrics(metrics);
            return Ok();
        }

        // POST: api/monitoring/logs
        [HttpPost("logs")]
        public async Task<IActionResult> PostLogs([FromBody] LogData log)
        {
            await _monitoringService.ProcessLogs(log);
            return Ok();
        }

        // POST: api/monitoring/traces
        [HttpPost("traces")]
        public async Task<IActionResult> PostTraces([FromBody] TraceData trace)
        {
            await _monitoringService.ProcessTraces(trace);
            return Ok();
        }
    }
}
