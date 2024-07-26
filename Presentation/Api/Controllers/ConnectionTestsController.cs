using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace Api.Controllers
{
    [Route("api/test/")]
    [ApiController]
    public class ConnectionTestsController : ControllerBase
    {
        [HttpGet("db-connection")]
        public async Task<IActionResult> TestDbConnection()
        {
            bool isConnected = await ConnectionTestHelper.TestDb();
            string? env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (isConnected) return Ok("Connected To Db. : " + env);
            return BadRequest("Failed To Connect : " + env);
        }
    }
}
