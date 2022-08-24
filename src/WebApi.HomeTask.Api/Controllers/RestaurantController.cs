using Microsoft.AspNetCore.Mvc;
using WebApi.HomeTask.Api.Requests;

namespace WebApi.HomeTask.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RestaurantController : ControllerBase
{
    
    [HttpPost]
    [ProducesResponseType(typeof(RestaurantViewModel), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult CreateReservation([FromBody] ReservationRequest request)
    {
        return Ok(new[]
        {
            new RestaurantViewModel { Id = 1, Name = "First Restaurant" }
        });
    }
}