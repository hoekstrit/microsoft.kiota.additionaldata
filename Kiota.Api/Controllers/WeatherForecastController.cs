using Asp.Versioning;
using Kiota.Api.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kiota.Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WeatherForecast))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(HttpValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public ActionResult<WeatherForecast> Post([FromBody] WeatherForecast forecast)
        {
            if (forecast.Date < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentOutOfRangeException();
            }

            return Ok(forecast);
        }
    }
}
