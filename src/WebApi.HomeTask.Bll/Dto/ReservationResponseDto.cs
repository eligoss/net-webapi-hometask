namespace WebApi.HomeTask.Bll.Dto;

public class ReservationRequestDto
{
    public string RestaurantName { get; set; }

    public DateTimeOffset ReservationDateTime { get; set; }

    public int NumberOfPeople { get; set; }
}