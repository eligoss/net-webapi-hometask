using WebApi.HomeTask.Bll.Dto;

namespace WebApi.HomeTask.Bll.Abstractions;

public interface IReservationService
{
    public Task<ReservationResponseDto> CreateReservation(ReservationRequestDto reservationRequestDto);
}