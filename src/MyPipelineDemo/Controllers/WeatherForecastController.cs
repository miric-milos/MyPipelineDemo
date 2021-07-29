using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyPipelineDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing",
            "Chilly", "Cool",
             "Mild", "Warm",
             "Balmy", "Hot",
             "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{index}")]
        public IActionResult Get(int index)
        {
            if (index >= Summaries.Length)
            {
                throw new Exception("Index out of range");
            }

            return Ok(Summaries[index]);
        }
    }
}
