using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly PlaceholderService _service;

        public HealthCheckController(PlaceholderService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var message = _service.GetMessage();
            return Ok(new { Status = "Healthy", Message = message });
        }
    }
}
