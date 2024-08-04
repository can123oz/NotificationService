using Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Api.Controllers
{
    [Route("/connection")]
    [ApiController]
    public class ConnectionTestsController : ControllerBase
    {
        private readonly HealthCheckService _healthCheckService;
        public ConnectionTestsController(HealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }
        
        [HttpGet]
        [Route("/test-connections")]
        public async Task<IActionResult> GetHealth()
        {
            HealthReport report = await _healthCheckService.CheckHealthAsync();
            return Ok(report.ToDto());
        }
    }
}