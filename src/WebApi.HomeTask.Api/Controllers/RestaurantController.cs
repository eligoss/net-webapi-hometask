using Microsoft.AspNetCore.Mvc;

namespace WebApi.HomeTask.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RestaurantController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(RestaurantViewModel), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Get()
    {
        return Ok(new[]
        {
            new RestaurantViewModel { Id = 1, Name = "First Restaurant" }
        });
    }
}