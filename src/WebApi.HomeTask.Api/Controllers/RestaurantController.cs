using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.HomeTask.Api.Requests;
using WebApi.HomeTask.Api.ViewModels;
using WebApi.HomeTask.Bll.Abstractions;
using WebApi.HomeTask.Bll.Dto;

namespace WebApi.HomeTask.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RestaurantController : ControllerBase
{
    private IReservationService _reservationService;
    private IMapper _mapper;

    public RestaurantController(IReservationService reservationService, IMapper mapper)
    {
        _reservationService = reservationService;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(RestaurantViewModel), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateReservation([FromBody] ReservationRequest request)
    {
        // Move to fluent api validation
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            return BadRequest(message);
        }

        if (!TryParseReservationTime(request, out DateTime reservationDateTime))
        {
            return BadRequest("The date is in wrong format.");
        }

        var dto = _mapper.Map<ReservationRequestDto>(request);
        dto.ReservationDateTime = new DateTimeOffset(reservationDateTime, TimeSpan.Zero);

        var reservation = await _reservationService.CreateReservation(dto);

        return Ok(_mapper.Map<ReservationViewModel>(reservation));
    }

    private bool TryParseReservationTime(ReservationRequest request, out DateTime reservationDateTime)
    {
        reservationDateTime = new DateTime();
        var isDateParsed = DateTime.TryParse(request.Date, out DateTime date);
        var isTimeParsed = DateTime.TryParse(request.Time, out DateTime time);

        if (isDateParsed == false || isTimeParsed == false)
        {
            return false;
        }

        reservationDateTime = date.Add(time.TimeOfDay);
        return true;
    }
}