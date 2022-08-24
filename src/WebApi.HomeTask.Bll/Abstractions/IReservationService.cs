using WebApi.HomeTask.Bll.Dto;

namespace WebApi.HomeTask.Bll.Abstractions;

public interface IReservationService
{
    public Task CreateReservation(ReservationDto reservationDto);
}