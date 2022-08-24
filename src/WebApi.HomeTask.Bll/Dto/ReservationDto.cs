namespace WebApi.HomeTask.Bll.Dto;

public class ReservationDto
{
    public string RestaurantName { get; set; }

    public DateTimeOffset ReservationDateTime { get; set; }

    public int NumberOfPeople { get; set; }
}